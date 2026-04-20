using Microsoft.VisualBasic;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    public partial class SightingsPage : UserControl
    {
        public event Action? BackHomeRequested;

        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;
        private string selectedFilePath = "";

        public SightingsPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();

            btnBack.Click += (s, e) => BackHomeRequested?.Invoke();
            btnSubmit.Click += BtnSubmit_Click;
            btnChooseFile.Click += BtnChooseFile_Click;
            lstSightings.SelectedIndexChanged += LstSightings_SelectedIndexChanged;
            this.VisibleChanged += SightingsPage_VisibleChanged;
        }

        private async void InitializeHiddenWebView()
        {
            webViewLoader = new WebView2
            {
                Visible = false,
                Width = 10,
                Height = 10,
                Location = new Point(-1000, -1000)
            };
            Controls.Add(webViewLoader);
            try
            {
                await webViewLoader.EnsureCoreWebView2Async();
                webViewReady = true;
            }
            catch { }
        }

        private async Task WaitForWebViewReady()
        {
            while (!webViewReady)
                await Task.Delay(100);
        }

        private string DecodeJsString(string jsResult)
        {
            if (string.IsNullOrEmpty(jsResult)) return "";
            if (jsResult == "null") return "";
            if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[^1] == '"')
                jsResult = jsResult.Substring(1, jsResult.Length - 2);
            return jsResult
                .Replace("\\r\\n", "\n").Replace("\\n", "\n")
                .Replace("\\r", "\r").Replace("\\t", "\t")
                .Replace("\\\"", "\"").Replace("\\\\", "\\");
        }

        private async Task<string> NavigateAndReadResponseAsync(string url)
        {
            var tcs = new TaskCompletionSource<string>();
            EventHandler<CoreWebView2NavigationCompletedEventArgs>? handler = null;

            handler = async (s, e) =>
            {
                try
                {
                    string result = await webViewLoader.ExecuteScriptAsync(@"
                        (function() {
                            if (document.body)
                                return document.body.innerText || document.body.textContent || '';
                            return '';
                        })();
                    ");
                    string text = DecodeJsString(result);
                    webViewLoader.CoreWebView2.NavigationCompleted -= handler;
                    tcs.TrySetResult(text);
                }
                catch (Exception ex)
                {
                    webViewLoader.CoreWebView2.NavigationCompleted -= handler;
                    tcs.TrySetException(ex);
                }
            };

            webViewLoader.CoreWebView2.NavigationCompleted += handler;
            webViewLoader.CoreWebView2.Navigate(url);
            return await tcs.Task;
        }

        // Load sightings when page becomes visible
        private async void SightingsPage_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                await LoadSightings();
            }
        }

        // Load sightings from server
        private List<SightingData> sightingsList = new();

        private async Task LoadSightings()
        {
            try
            {
                string username = Properties.Settings.Default.Username;
                if (string.IsNullOrWhiteSpace(username)) return;

                await WaitForWebViewReady();

                string url = "http://komodoproject.zya.me/Sighting/get_sightings.php?username=" + Uri.EscapeDataString(username);
                string json = await NavigateAndReadResponseAsync(url);

                List<SightingData>? data = JsonSerializer.Deserialize<List<SightingData>>(json);
                sightingsList = data ?? new List<SightingData>();

                lstSightings.Items.Clear();
                foreach (var s in sightingsList)
                {
                    lstSightings.Items.Add($"{s.species} - {s.location}");
                }

                if (lstSightings.Items.Count == 0)
                {
                    txtSightingDetail.Text = "No sightings found. Submit your first sighting report!";
                }
            }
            catch (Exception ex)
            {
                txtSightingDetail.Text = "Could not load sightings: " + ex.Message;
            }
        }

        // Show detail when selecting a sighting from the list
        private void LstSightings_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstSightings.SelectedIndex >= 0 && lstSightings.SelectedIndex < sightingsList.Count)
            {
                var s = sightingsList[lstSightings.SelectedIndex];
                txtSightingDetail.Text =
                    $"Species: {s.species}\n" +
                    $"Location: {s.location}\n" +
                    $"Date: {s.sighting_date}\n" +
                    $"Reported by: {s.username}\n\n" +
                    $"Description:\n{s.description}";

                if (!string.IsNullOrEmpty(s.image_path))
                {
                    try
                    {
                        picturesighting.Load("http://komodoproject.zya.me/Sighting/" + s.image_path);
                        picturesighting.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch
                    {
                        picturesighting.Image = null;
                    }
                }
                else
                {
                    picturesighting.Image = null;
                }
            }
        }

        // Choose photo file
        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = dlg.FileName;
                btnChooseFile.Text = System.IO.Path.GetFileName(dlg.FileName);
            }
        }

        // Submit sighting report
        private async void BtnSubmit_Click(object? sender, EventArgs e)
        {
            string username = Properties.Settings.Default.Username;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("You must be logged in to submit a sighting.", "Komodo Hub");
                return;
            }

            if (cmbSpecies.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please select a species and enter a location.", "Komodo Hub");
                return;
            }

            btnSubmit.Enabled = false;
            btnSubmit.Text = "Submitting...";

            try
            {
                string imagePath = "";

                // Upload image first if selected
                if (!string.IsNullOrEmpty(selectedFilePath) && System.IO.File.Exists(selectedFilePath))
                {
                    byte[] imageBytes = System.IO.File.ReadAllBytes(selectedFilePath);
                    if (imageBytes.Length < 500000)
                    {
                        string base64 = Convert.ToBase64String(imageBytes);
                        string fname = System.IO.Path.GetFileName(selectedFilePath);

                        string uploadUrl = "http://komodoproject.zya.me/Sighting/upload_image.php?filename="
                            + Uri.EscapeDataString(fname)
                            + "&image_data=" + Uri.EscapeDataString(base64);

                        string uploadResult = await NavigateAndReadResponseAsync(uploadUrl);
                        if (uploadResult.Contains("UPLOAD_OK|"))
                            imagePath = uploadResult.Split('|')[1];
                    }
                    else
                    {
                        MessageBox.Show("Image too large. Use under 500KB.", "Komodo Hub");
                    }
                }

                await WaitForWebViewReady();

                string url = "http://komodoproject.zya.me/Sighting/sumbit_sighting.php?username="
                    + Uri.EscapeDataString(username)
                    + "&species=" + Uri.EscapeDataString(cmbSpecies.Text)
                    + "&location=" + Uri.EscapeDataString(txtLocation.Text)
                    + "&sighting_date=" + dtpDate.Value.ToString("yyyy-MM-dd")
                    + "&description=" + Uri.EscapeDataString(txtDescription.Text)
                    + "&image_path=" + Uri.EscapeDataString(imagePath);

                string webResponse = await NavigateAndReadResponseAsync(url);
                webResponse = webResponse.Trim();

                if (webResponse.Contains("SIGHTING_SUBMITTED"))
                {
                    MessageBox.Show("Sighting report submitted successfully!", "Komodo Hub");
                    cmbSpecies.SelectedIndex = -1;
                    txtLocation.Clear();
                    txtDescription.Clear();
                    btnChooseFile.Text = "Choose file...";
                    selectedFilePath = "";
                    dtpDate.Value = DateTime.Today;
                    await LoadSightings();
                }
                else if (webResponse.Contains("MISSING_FIELDS"))
                {
                    MessageBox.Show("Please fill in all required fields.", "Komodo Hub");
                }
                else
                {
                    MessageBox.Show("Submission failed: " + webResponse, "Komodo Hub");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Komodo Hub");
            }

            btnSubmit.Enabled = true;
            btnSubmit.Text = "Submit Sighting Report";
        }

        private void SightingsPage_Load(object sender, EventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }

        private void picturesighting_Click(object sender, EventArgs e)
        {

        }
    }

    // Data model for sighting JSON
    public class SightingData
    {
        public int id { get; set; }
        public string username { get; set; } = "";
        public string species { get; set; } = "";
        public string location { get; set; } = "";
        public string sighting_date { get; set; } = "";
        public string description { get; set; } = "";
        public string image_path { get; set; } = "";
        public string created_at { get; set; } = "";
    }
}
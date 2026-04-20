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
    public partial class EnrolmentPage : UserControl
    {
        public event Action? BackHomeRequested;

        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;
        private List<ProgramData> allPrograms = new List<ProgramData>();

        public EnrolmentPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();
            btnEnroll.Click += btnEnroll_Click;
            btnBackHome.Click += btnBackHome_Click;
            lstAllPrograms.SelectedIndexChanged += lstAllPrograms_SelectedIndexChanged;
            this.VisibleChanged += async (s, e) =>
            {
                if (this.Visible)
                {
                    await WaitForWebViewReady();
                    await LoadAllPrograms();
                    await LoadMyPrograms();
                }
            };
            ApplyTheme();
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
            await webViewLoader.EnsureCoreWebView2Async();
            webViewReady = true;
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

        private async Task LoadAllPrograms()
        {
            try
            {
                string url = "https://komodoproject.zya.me/get_programs.php";
                string json = await NavigateAndReadResponseAsync(url);
                List<ProgramData>? data = JsonSerializer.Deserialize<List<ProgramData>>(json);
                allPrograms = data ?? new List<ProgramData>();

                lstAllPrograms.Items.Clear();
                foreach (ProgramData p in allPrograms)
                    lstAllPrograms.Items.Add($"[{p.organisation_type}] {p.title}");

                if (lstAllPrograms.Items.Count == 0)
                    lblProgramDetail.Text = "No programs available.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading programs: " + ex.Message);
            }
        }

        private async Task LoadMyPrograms()
        {
            try
            {
                string username = Properties.Settings.Default.Username;
                if (string.IsNullOrWhiteSpace(username)) return;

                string url = "https://komodoproject.zya.me/get_my_programs.php?username="
                             + Uri.EscapeDataString(username);
                string json = await NavigateAndReadResponseAsync(url);
                List<ProgramData>? data = JsonSerializer.Deserialize<List<ProgramData>>(json);
                var myPrograms = data ?? new List<ProgramData>();

                lstMyPrograms.Items.Clear();
                foreach (ProgramData p in myPrograms)
                    lstMyPrograms.Items.Add(p.title);

                if (lstMyPrograms.Items.Count == 0)
                    lstMyPrograms.Items.Add("Not enrolled in any programs yet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading your programs: " + ex.Message);
            }
        }

        private void lstAllPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAllPrograms.SelectedIndex >= 0)
            {
                ProgramData selected = allPrograms[lstAllPrograms.SelectedIndex];
                lblProgramDetail.Text =
                    $"Title: {selected.title}{Environment.NewLine}" +
                    $"Type: {selected.organisation_type}{Environment.NewLine}{Environment.NewLine}" +
                    $"Description:{Environment.NewLine}{selected.description}";
            }
        }

        private async void btnEnroll_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("Please log in to enroll in a program.");
                return;
            }
            if (lstAllPrograms.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a program first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAccessCode.Text))
            {
                MessageBox.Show("Please enter your access code.");
                return;
            }

            ProgramData selected = allPrograms[lstAllPrograms.SelectedIndex];

            try
            {
                string url = "https://komodoproject.zya.me/enroll.php" +
                    "?username=" + Uri.EscapeDataString(Properties.Settings.Default.Username) +
                    "&program_id=" + Uri.EscapeDataString(selected.program_id) +
                    "&access_code=" + Uri.EscapeDataString(txtAccessCode.Text.Trim());

                string response = await NavigateAndReadResponseAsync(url);
                response = response.Trim();

                if (response.Contains("ENROLL_SUCCESS"))
                {
                    MessageBox.Show($"Successfully enrolled in {selected.title}!", "KomodoHub",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAccessCode.Text = "";
                    await LoadMyPrograms();
                }
                else if (response.Contains("ALREADY_ENROLLED"))
                {
                    MessageBox.Show("You are already enrolled in this program.");
                }
                else if (response.Contains("INVALID_ACCESS_CODE"))
                {
                    MessageBox.Show("Invalid or expired access code. Please check with your teacher.");
                }
                else if (response.Contains("USER_NOT_FOUND"))
                {
                    MessageBox.Show("User not found. Please log in again.");
                }
                else
                {
                    MessageBox.Show("Enrollment failed: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            BackHomeRequested?.Invoke();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(20, 40, 25);

            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Text = "Programs & Enrolment";

            lblAvailable.ForeColor = Color.White;
            lblAvailable.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAvailable.BackColor = Color.Transparent;
            lblAvailable.Text = "Available Programs";

            lblMyPrograms.ForeColor = Color.White;
            lblMyPrograms.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMyPrograms.BackColor = Color.Transparent;
            lblMyPrograms.Text = "My Enrolled Programs";

            lblProgramDetail.ForeColor = Color.FromArgb(200, 255, 200);
            lblProgramDetail.BackColor = Color.Transparent;
            lblProgramDetail.Font = new Font("Segoe UI", 10F);

            StyleButton(btnEnroll, Color.FromArgb(46, 139, 87), Color.White);
            btnEnroll.Text = "Enroll in Program";

            StyleButton(btnBackHome, Color.FromArgb(210, 82, 60), Color.White);
            btnBackHome.Text = "Back to Home";
        }

        private void StyleButton(Button btn, Color bgColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bgColor;
            btn.ForeColor = textColor;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 45;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EnrolmentPage_Load(object sender, EventArgs e)
        {

        }
    }

    public class ProgramData
    {
        public string program_id { get; set; } = "";
        public string title { get; set; } = "";
        public string description { get; set; } = "";
        public string organisation_type { get; set; } = "";
        public string enrolled_at { get; set; } = "";
    }
}
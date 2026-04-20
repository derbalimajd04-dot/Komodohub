using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    public partial class SubmissionPage : UserControl
    {
        public event Action? BackHomeRequested;
        private string _selectedImagePath = "";
        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;
        private List<Activity> activities = new List<Activity>();

        public SubmissionPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();
            lstActivities.SelectedIndexChanged += lstActivities_SelectedIndexChanged;
            btnSubmit.Click += btnSubmit_Click;
            btnBackHome.Click += btnBackHome_Click;
            btnChooseImage.Click += btnChooseImage_Click;
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
            await LoadActivities(); // auto-load when ready
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

        private async Task LoadActivities()
        {
            try
            {
                await WaitForWebViewReady();
                string url = "http://komodoproject.zya.me/activities/get_activities.php";
                string json = await NavigateAndReadResponseAsync(url);
                List<Activity>? data = JsonSerializer.Deserialize<List<Activity>>(json);
                activities = data ?? new List<Activity>();

                lstActivities.Items.Clear();
                foreach (Activity a in activities)
                    lstActivities.Items.Add(a.title);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading activities: " + ex.Message);
            }
        }

        private void lstActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstActivities.SelectedIndex >= 0)
            {
                Activity selected = activities[lstActivities.SelectedIndex];
                lblActivityDescription.Text = selected.description;
                lblDueDate.Text = "Due: " + selected.due_date;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("You must be logged in to submit.");
                return;
            }
            if (lstActivities.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an activity first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReportText.Text))
            {
                MessageBox.Show("Please write something in your submission.");
                return;
            }

            Activity selected = activities[lstActivities.SelectedIndex];

            try
            {
                // upload image first if one was chosen
                string imageUrl = "";
                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    imageUrl = await UploadImageAsync(_selectedImagePath);
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        MessageBox.Show("Image upload failed. Please try again.");
                        return;
                    }
                }

                string url = "http://komodoproject.zya.me/submit.php" +
                    "?username=" + Uri.EscapeDataString(Properties.Settings.Default.Username) +
                    "&activity_id=" + Uri.EscapeDataString(selected.activity_id) +
                    "&title=" + Uri.EscapeDataString(txtTitle.Text) +
                    "&report_text=" + Uri.EscapeDataString(txtReportText.Text) +
                    "&image_path=" + Uri.EscapeDataString(imageUrl);

                string response = await NavigateAndReadResponseAsync(url);
                response = response.Trim();

                if (response.Contains("SUBMISSION_SUCCESS"))
                {
                    MessageBox.Show("Submission sent successfully!", "KomodoHub",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTitle.Text = "";
                    txtReportText.Text = "";
                    lstActivities.SelectedIndex = -1;
                    lblActivityDescription.Text = "";
                    lblDueDate.Text = "";
                    _selectedImagePath = "";
                    picPreview.Image = null;
                }
                else
                {
                    MessageBox.Show("Submission failed: " + response);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtReportText_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDueDate_Click(object sender, EventArgs e)
        {

        }

        private void SubmissionPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(20, 40, 25);

            // Labels
            label1.Text = "Submission Title";
            label1.ForeColor = Color.White;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.BackColor = Color.Transparent;

            lblActivityDescription.ForeColor = Color.White;
            lblActivityDescription.BackColor = Color.Transparent;
            lblActivityDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblDueDate.ForeColor = Color.FromArgb(180, 220, 180);
            lblDueDate.BackColor = Color.Transparent;

            // Textboxes
            txtTitle.BackColor = Color.FromArgb(40, 70, 45);
            txtTitle.ForeColor = Color.White;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;

            txtReportText.BackColor = Color.FromArgb(40, 70, 45);
            txtReportText.ForeColor = Color.White;
            txtReportText.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            StyleButton(btnSubmit, Color.FromArgb(46, 139, 87), Color.White);
            StyleButton(btnBackHome, Color.FromArgb(210, 82, 60), Color.White);

            lblPageTitle.Text = "Submit Your Work";
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            lblPageTitle.BackColor = Color.Transparent;
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
        private async Task<string> UploadImageAsync(string filePath)
        {
            try
            {
                byte[] bytes;
                using (var original = Image.FromFile(filePath))
                {
                    int maxSize = 800;
                    int w = original.Width, h = original.Height;
                    if (w > maxSize) { h = h * maxSize / w; w = maxSize; }
                    using (var resized = new Bitmap(original, new Size(w, h)))
                    using (var ms = new System.IO.MemoryStream())
                    {
                        resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytes = ms.ToArray();
                    }
                }
                string base64 = Convert.ToBase64String(bytes);
                var navTcs = new TaskCompletionSource<bool>();
                EventHandler<CoreWebView2NavigationCompletedEventArgs>? navHandler = null;
                navHandler = (s, e) =>
                {
                    webViewLoader.CoreWebView2.NavigationCompleted -= navHandler;
                    navTcs.TrySetResult(true);
                };
                webViewLoader.CoreWebView2.NavigationCompleted += navHandler;
                webViewLoader.CoreWebView2.Navigate("http://komodoproject.zya.me/activities/upload_image.php");
                await navTcs.Task;
                string js = $@"
    window._uploadResult = null;
    (async function() {{
        const byteChars = atob('{base64}');
        const byteArr = new Uint8Array(byteChars.length);
        for (let i = 0; i < byteChars.length; i++)
            byteArr[i] = byteChars.charCodeAt(i);
        const blob = new Blob([byteArr], {{ type: 'image/jpg' }});
        const form = new FormData();
        form.append('image', blob, 'upload.jpg');
        try {{
            const res = await fetch('/activities/upload_image.php', {{
                method: 'POST',
                body: form
            }});
            window._uploadResult = await res.text();
        }} catch(e) {{
            window._uploadResult = 'FETCH_ERROR:' + e.message;
        }}
    }})();
";
                await webViewLoader.ExecuteScriptAsync(js);
                string result = "null";
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(200);
                    result = await webViewLoader.ExecuteScriptAsync("window._uploadResult");
                    if (result != "null") break;
                }
                return DecodeJsString(result).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload error: " + ex.Message);
                return "";
            }
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Select an Image";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    using (var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(_selectedImagePath)))
                    {
                        picPreview.Image = new Bitmap(ms);
                    }
                    picPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
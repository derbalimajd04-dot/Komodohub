using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Drawing;

namespace KomodoHub.Pages
{
    public partial class TeacherPage : UserControl
    {
        public event Action? BackHomeRequested;
        public event Action? OpenFeedbackRequested;
        public event Action? OpenSubscriptionRequested;
        public TeacherPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();
            btnBackHome.Click += btnBackHome_Click;
            btnGoToFeedback.Click += btnGoToFeedback_Click;
            btnManageSubscription.Click += btnManageSubscription_Click;
            button1.Click += button1_Click;
        }


        private WebView2 webViewRegister = null!;
        private string _selectedImagePath = "";
        public bool webViewReady = false;
        private async void InitializeHiddenWebView()
        {
            webViewRegister = new WebView2
            {
                Visible = false,
                Width = 10,
                Height = 10,
                Location = new Point(-1000, -1000)  // we do a little hiding here bhahaha
            };

            Controls.Add(webViewRegister);
            await webViewRegister.EnsureCoreWebView2Async();
            webViewReady = true;

        }

        private string DecodeJsString(string jsResult)
        {
            if (string.IsNullOrEmpty(jsResult))
                return "";

            if (jsResult == "null")
                return "";

            if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[^1] == '"')
                jsResult = jsResult.Substring(1, jsResult.Length - 2);

            jsResult = jsResult
                .Replace("\\r\\n", "\n")
                .Replace("\\n", "\n")
                .Replace("\\r", "\r")
                .Replace("\\t", "\t")
                .Replace("\\\"", "\"")
                .Replace("\\\\", "\\");

            return jsResult;
        }
        private async Task<string> NavigateAndReadResponseAsync(string url, int timeoutMs)
        {
            var tcs = new TaskCompletionSource<string>();

            EventHandler<CoreWebView2NavigationCompletedEventArgs>? handler = null;

            handler = async (s, e) =>
            {
                try
                {
                    // Read page body text
                    string result = await webViewRegister.ExecuteScriptAsync(@"
                        (function() {
                            if (document.body)
                                return document.body.innerText || document.body.textContent || '';
                            return '';
                        })();
                    ");

                    string text = DecodeJsString(result);
                    webViewRegister.CoreWebView2.NavigationCompleted -= handler;
                    tcs.TrySetResult(text);

                }
                catch (Exception ex)
                {
                    webViewRegister.CoreWebView2.NavigationCompleted -= handler;
                    tcs.TrySetException(ex);
                }
            };

            webViewRegister.CoreWebView2.NavigationCompleted += handler;
            webViewRegister.CoreWebView2.Navigate(url);

            return await tcs.Task;
        }


        //http://komodoproject.zya.me/generate_code.php?name=Brian&password=yourpassword&school_id=1&codename=CoolCode&days=7
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string urlbuild = "http://komodoproject.zya.me/generate_code.php?name=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password + "&school_id=" + txtSchoolId.Text + "&codename=" + txtCode.Text + "&days=" + txtDaysExpiry.Text;
                string response = await NavigateAndReadResponseAsync(urlbuild, 15000);

                response = response.Trim();
                if (response.Contains("CODE_CREATED"))
                {
                    MessageBox.Show("Code created, code has been copied!");
                    Clipboard.SetText(txtCode.Text);
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                    MessageBox.Show(response);
                    Application.Exit();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {

        }

        private void txtSchoolId_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelGenerateCode_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void btnCreateActivity_Click(object sender, EventArgs e)
        {
            if (KomodoHub.UserRole != "TEACHER" && KomodoHub.UserRole != "ADMIN")
            {
                MessageBox.Show("Access denied. Only teachers and admins can create activities.", "KomodoHub");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtActivityTitle.Text) ||
                string.IsNullOrWhiteSpace(txtActivityDescription.Text) ||
                string.IsNullOrWhiteSpace(txtActivityType.Text) ||
                string.IsNullOrWhiteSpace(txtDueDate.Text))
            {
                MessageBox.Show("Please fill in all fields.", "KomodoHub");
                return;
            }

            try
            {
                string imageUrl = "";
                if (!string.IsNullOrEmpty(_selectedImagePath))
                {
                    imageUrl = await UploadImageAsync(_selectedImagePath);
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        MessageBox.Show("Image upload failed. Activity not created.", "KomodoHub");
                        return;
                    }
                }

                string url = "http://komodoproject.zya.me/activities/create_activity.php?title=" +
                    Uri.EscapeDataString(txtActivityTitle.Text) +
                    "&description=" + Uri.EscapeDataString(txtActivityDescription.Text) +
                    "&activity_type=" + Uri.EscapeDataString(txtActivityType.Text) +
                    "&due_date=" + Uri.EscapeDataString(txtDueDate.Text) +
                    "&image_path=" + Uri.EscapeDataString(imageUrl);

                string response = await NavigateAndReadResponseAsync(url, 15000);
                response = response.Trim();

                if (response.Contains("ACTIVITY_CREATED"))
                {
                    MessageBox.Show("Activity created successfully!", "KomodoHub");
                    txtActivityTitle.Text = "";
                    txtActivityDescription.Text = "";
                    txtActivityType.Text = "";
                    txtDueDate.Text = "";
                    _selectedImagePath = "";
                    picImagePreview.Image = null;
                }
                else if (response.Contains("MISSING_FIELDS"))
                {
                    MessageBox.Show("Please fill in all fields.", "KomodoHub");
                }
                else
                {
                    MessageBox.Show("Failed to create activity: " + response, "KomodoHub");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            BackHomeRequested?.Invoke();
        }

        private void txtActivityType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDaysExpiry_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelCreateActivity_Paint(object sender, PaintEventArgs e)
        {

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
                        picImagePreview.Image = new Bitmap(ms);
                    }

                    picImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
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
                    webViewRegister.CoreWebView2.NavigationCompleted -= navHandler;
                    navTcs.TrySetResult(true);
                };
                webViewRegister.CoreWebView2.NavigationCompleted += navHandler;
                webViewRegister.CoreWebView2.Navigate("http://komodoproject.zya.me/activities/upload_image.php");
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

                await webViewRegister.ExecuteScriptAsync(js);

                string result = "null";
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(200);
                    result = await webViewRegister.ExecuteScriptAsync("window._uploadResult");
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

        private void btnGoToFeedback_Click(object sender, EventArgs e)
        {
            OpenFeedbackRequested?.Invoke();
        }

        private void btnManageSubscription_Click(object sender, EventArgs e)
        {
            OpenSubscriptionRequested?.Invoke();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


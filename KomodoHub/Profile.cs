using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomodoHub
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private List<Submission> submissionss = new List<Submission>();

        private WebView2 webViewRegister = null!;
        private bool webViewReady = false;

        private async Task InitializeWebViewAsync()
        {
            if (webViewRegister == null)
            {
                webViewRegister = new WebView2
                {
                    Visible = false,
                    Width = 1,
                    Height = 1,
                    Left = -1000,
                    Top = -1000
                };

                Controls.Add(webViewRegister);
            }

            if (!webViewReady)
            {
                await webViewRegister.EnsureCoreWebView2Async(null);
                webViewReady = true;
            }
        }

        private async Task WaitForWebViewReady()
        {
            if (!webViewReady || webViewRegister == null || webViewRegister.CoreWebView2 == null)
            {
                await InitializeWebViewAsync();
            }
        }

        private string DecodeJsString(string jsResult)
        {
            if (string.IsNullOrEmpty(jsResult))
                return "";

            if (jsResult == "null")
                return "";

            if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[jsResult.Length - 1] == '"')
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
            await WaitForWebViewReady();

            var tcs = new TaskCompletionSource<string>();

            EventHandler<CoreWebView2NavigationCompletedEventArgs>? handler = null;

            handler = async (s, e) =>
            {
                try
                {
                    if (!e.IsSuccess)
                    {
                        if (webViewRegister?.CoreWebView2 != null)
                            webViewRegister.CoreWebView2.NavigationCompleted -= handler;

                        tcs.TrySetException(new Exception("Navigation failed."));
                        return;
                    }

                    string result = await webViewRegister.ExecuteScriptAsync(@"
                        (function() {
                            if (document.body)
                                return document.body.innerText || document.body.textContent || '';
                            return '';
                        })();
                    ");

                    string text = DecodeJsString(result);

                    if (webViewRegister?.CoreWebView2 != null)
                        webViewRegister.CoreWebView2.NavigationCompleted -= handler;

                    tcs.TrySetResult(text);
                }
                catch (Exception ex)
                {
                    if (webViewRegister?.CoreWebView2 != null)
                        webViewRegister.CoreWebView2.NavigationCompleted -= handler;

                    tcs.TrySetException(ex);
                }
            };

            webViewRegister.CoreWebView2.NavigationCompleted += handler;
            webViewRegister.CoreWebView2.Navigate(url);

            Task completedTask = await Task.WhenAny(tcs.Task, Task.Delay(timeoutMs));

            if (completedTask != tcs.Task)
            {
                if (webViewRegister?.CoreWebView2 != null)
                    webViewRegister.CoreWebView2.NavigationCompleted -= handler;

                throw new TimeoutException("The request timed out.");
            }

            return await tcs.Task;
        }

        private async Task LoadStudentFindings()
        {
            try
            {
                string currentUsername = Properties.Settings.Default.Username;

                if (string.IsNullOrWhiteSpace(currentUsername))
                {
                    MessageBox.Show("You must be logged in.");
                    return;
                }

                await WaitForWebViewReady();

                string url = "http://komodoproject.zya.me/get_submissions.php?username=" +
                             Uri.EscapeDataString(currentUsername);

                string json = await NavigateAndReadResponseAsync(url, 10000);

                if (string.IsNullOrWhiteSpace(json))
                {
                    submissionss = new List<Submission>();
                    LoadTitlesIntoListBox();
                    return;
                }

                if (json.StartsWith("ERROR", StringComparison.OrdinalIgnoreCase) ||
                    json.StartsWith("Invalid", StringComparison.OrdinalIgnoreCase) ||
                    json.StartsWith("Missing", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(json);
                    return;
                }

                List<Submission>? data = JsonSerializer.Deserialize<List<Submission>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (data != null)
                    submissionss = data;
                else
                    submissionss = new List<Submission>();

                LoadTitlesIntoListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading submissions: " + ex.Message);
            }
        }

        private void LoadTitlesIntoListBox()
        {
            submissionsBoxx.Items.Clear();

            foreach (Submission submission in submissionss)
            {
                submissionsBoxx.Items.Add(submission.title);
            }

            if (submissionsBoxx.Items.Count == 0)
            {
                submissionsBoxx.Items.Add("No submissions found.");
            }
        }

        private async void Profile_Load(object sender, EventArgs e)
        {
            mynameLabel.Text = Properties.Settings.Default.Username;
            await InitializeWebViewAsync();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (checkedListBox1.SelectedIndex)
            {
                case 0:
                    this.BackColor = Color.Red;
                    break;
                case 1:
                    this.BackColor = Color.Purple;
                    break;
                case 2:
                    this.BackColor = Color.Blue;
                    break;
            }
        }

        private void submissionsBoxx_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadStudentFindings();

            string urlbuild = "http://komodoproject.zya.me/messageSystem/read_message.php?username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password;
            string response = await NavigateAndReadResponseAsync(urlbuild, 15000);
            response = response.Trim();

            messageBoxRecieved.Text = response;

        }
    }
}
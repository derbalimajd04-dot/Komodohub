using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.Text.Json;

namespace KomodoHub.Pages
{
    public partial class Library : UserControl
    {
        private List<Submission> submissions = new List<Submission>();
        public event Action? BackHomeRequested;
        public event Action? PublicActivitiesRequested;
        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;

        public Library()
        {
            InitializeComponent();
            InitializeHiddenWebView();
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
            {
                await Task.Delay(100);
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

                string url = "http://komodoproject.zya.me/get_submissions.php?username=" + Uri.EscapeDataString(currentUsername);

                string json = await NavigateAndReadResponseAsync(url);

                List<Submission>? data = JsonSerializer.Deserialize<List<Submission>>(json);

                if (data != null)
                    submissions = data;
                else
                    submissions = new List<Submission>();

                LoadTitlesIntoListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading submissions: " + ex.Message);
            }
        }

        private void LoadTitlesIntoListBox()
        {
            lstItems.Items.Clear();

            foreach (Submission submission in submissions)
            {
                lstItems.Items.Add(submission.title);
            }

            txtAuthor.Text = Properties.Settings.Default.Username;
            txtTitle.Text = "";
            txtContent.Text = "";
            picItem.Image = null;

            if (lstItems.Items.Count == 0)
            {
                txtContent.Text = "No submissions found.";
            }
        }
        private async void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                Submission selectedSubmission = submissions[lstItems.SelectedIndex];

                txtTitle.Text = selectedSubmission.title;
                txtAuthor.Text = selectedSubmission.username;
                txtContent.Text = selectedSubmission.report_text;

                if (!string.IsNullOrEmpty(selectedSubmission.image_path))
                {
                    try { picItem.Load("http://komodoproject.zya.me/" + selectedSubmission.image_path); }
                    catch { picItem.Image = null; }
                }
                else
                {
                    picItem.Image = null;
                }

                await LoadFeedbackForSubmission(selectedSubmission.id);
            }
        }
        private async Task LoadFeedbackForSubmission(string submissionId)
        {
            try
            {
                string url = "http://komodoproject.zya.me/get_feedback.php?submission_id="
                             + Uri.EscapeDataString(submissionId);
                string json = await NavigateAndReadResponseAsync(url);

                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;

                if (root.GetArrayLength() == 0)
                {
                    txtFeedback.Text = "No feedback yet.";
                    return;
                }

                string feedbackText = "";
                foreach (JsonElement note in root.EnumerateArray())
                {
                    string teacher = note.GetProperty("teacher_id").GetString() ?? "";
                    string text = note.GetProperty("note_text").GetString() ?? "";
                    string date = note.GetProperty("created_at").GetString() ?? "";
                    feedbackText += $"Teacher: {teacher}{Environment.NewLine}Date: {date}{Environment.NewLine}Feedback: {text}{Environment.NewLine}{Environment.NewLine}";
                }

                txtFeedback.Text = feedbackText.Trim();
            }
            catch (Exception ex)
            {
                txtFeedback.Text = "Error loading feedback.";
            }
        }



        private void Library_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackHomeRequested?.Invoke();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await LoadStudentFindings();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PublicActivitiesRequested?.Invoke();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void OverViewButton_Click(object sender, EventArgs e)
        {
            publicLibrary pl = new publicLibrary();
            pl.Show();
        }
    }
}

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
    public partial class TeacherFeedbackPage : UserControl
    {
        public event Action? BackHomeRequested;

        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;
        private List<Submission> submissions = new List<Submission>();

        public TeacherFeedbackPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();
            lstSubmissions.SelectedIndexChanged += lstSubmissions_SelectedIndexChanged;
            btnPostFeedback.Click += btnPostFeedback_Click;
            btnBackHome.Click += btnBackHome_Click;
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
            await LoadSubmissions();
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

        private async Task LoadSubmissions()
        {
            try
            {
                await WaitForWebViewReady();
                string url = "http://komodoproject.zya.me/get_all_submissions.php";
                string json = await NavigateAndReadResponseAsync(url);
                List<Submission>? data = JsonSerializer.Deserialize<List<Submission>>(json);
                submissions = data ?? new List<Submission>();

                lstSubmissions.Items.Clear();
                foreach (Submission s in submissions)
                    lstSubmissions.Items.Add(s.username + " — " + s.title);

                if (lstSubmissions.Items.Count == 0)
                    lblSubmissionDetail.Text = "No submissions yet.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading submissions: " + ex.Message);
            }
        }

        private void lstSubmissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubmissions.SelectedIndex >= 0)
            {
                Submission selected = submissions[lstSubmissions.SelectedIndex];
                lblSubmissionDetail.Text =
                    "Student: " + selected.username + "\r\n" +
                    "Title: " + selected.title + "\r\n\r\n" +
                    selected.report_text;
                txtFeedback.Text = "";
            }
        }

        private async void btnPostFeedback_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsTeacherOrAdmin())
            {
                MessageBox.Show("Access denied. Only teachers and admins can post feedback.",
                                "Access Restricted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (lstSubmissions.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a submission first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Please write your feedback before submitting.");
                return;
            }

            Submission selected = submissions[lstSubmissions.SelectedIndex];

            try
            {
                
                string url = "http://komodoproject.zya.me/add_feedback.php" +
                    "?submission_id=" + Uri.EscapeDataString(selected.id) +

                    "&teacher_id=" + Uri.EscapeDataString(Properties.Settings.Default.Username) +
                    "&note_text=" + Uri.EscapeDataString(txtFeedback.Text);

                string response = await NavigateAndReadResponseAsync(url);
                response = response.Trim();

                if (response.Contains("FEEDBACK_SUCCESS"))
                {
                    MessageBox.Show("Feedback posted successfully!", "KomodoHub",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFeedback.Text = "";
                }
                else if (response.Contains("MISSING_FIELDS"))
                {
                    MessageBox.Show("Please fill in all fields.");
                }
                else
                {
                    MessageBox.Show("Failed to post feedback: " + response);
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

            lblPageTitle.Text = "Teacher Feedback";
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            lblPageTitle.BackColor = Color.Transparent;

            lblSubmissionDetail.ForeColor = Color.FromArgb(200, 255, 200);
            lblSubmissionDetail.BackColor = Color.Transparent;
            lblSubmissionDetail.Font = new Font("Segoe UI", 10F);

            txtFeedback.BackColor = Color.FromArgb(40, 70, 45);
            txtFeedback.ForeColor = Color.White;
            txtFeedback.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnPostFeedback, Color.FromArgb(46, 139, 87), Color.White);
            StyleButton(btnBackHome, Color.FromArgb(210, 82, 60), Color.White);
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

        private void btnPostFeedback_Click_1(object sender, EventArgs e)
        {

        }
    }
}
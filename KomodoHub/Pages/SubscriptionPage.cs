using System;
using System.Drawing;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace KomodoHub.Pages
{
    public partial class SubscriptionPage : UserControl
    {
        public event Action? BackHomeRequested;

        private WebView2 webViewRegister = null!;
        public bool webViewReady = false;

        public SubscriptionPage()
        {
            InitializeComponent();
            InitializeHiddenWebView();

            btnBackHome.Click += (s, e) => BackHomeRequested?.Invoke();
            btnUpdate.Click += btnUpdate_Click;
            btnRefresh.Click += btnRefresh_Click;

            this.VisibleChanged += SubscriptionPage_VisibleChanged;
        }

        private async void InitializeHiddenWebView()
        {
            webViewRegister = new WebView2
            {
                Visible = false,
                Width = 10,
                Height = 10,
                Location = new Point(-1000, -1000)
            };
            Controls.Add(webViewRegister);
            await webViewRegister.EnsureCoreWebView2Async();
            webViewReady = true;
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

        private async Task<string> NavigateAndReadResponseAsync(string url, int timeoutMs = 15000)
        {
            var tcs = new TaskCompletionSource<string>();
            EventHandler<CoreWebView2NavigationCompletedEventArgs>? handler = null;

            handler = async (s, e) =>
            {
                try
                {
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

        private async void SubscriptionPage_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
                await LoadSubscriptionAsync();
        }

        private async Task LoadSubscriptionAsync()
        {
            if (!RoleHelper.IsAdmin())
            {
                MessageBox.Show("Access denied. Admins only.", "KomodoHub", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BackHomeRequested?.Invoke();
                return;
            }

            if (!webViewReady) return;

            try
            {
                string url = "https://komodoproject.zya.me/get_subscription.php?school_id=1";
                string response = await NavigateAndReadResponseAsync(url, 15000);
                response = response.Trim();

                using var doc = JsonDocument.Parse(response);
                var root = doc.RootElement;

                lblCurrentPlan.Text = "Plan: " + (root.TryGetProperty("plan", out var plan) ? plan.GetString() ?? "N/A" : "N/A");
                lblCurrentStatus.Text = "Status: " + (root.TryGetProperty("status", out var status) ? status.GetString() ?? "N/A" : "N/A");
                lblStartDate.Text = "Start Date: " + (root.TryGetProperty("start_date", out var startDate) ? startDate.GetString() ?? "N/A" : "N/A");
                lblEndDate.Text = "End Date: " + (root.TryGetProperty("end_date", out var endDate) ? endDate.GetString() ?? "N/A" : "N/A");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load subscription: " + ex.Message, "KomodoHub");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsAdmin())
            {
                MessageBox.Show("Access denied. Admins only.", "KomodoHub", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!webViewReady) return;

            try
            {
                string plan = cmbPlan.SelectedItem?.ToString() ?? "";
                string status = cmbStatus.SelectedItem?.ToString() ?? "";
                string endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(plan) || string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Please select a plan and status.", "KomodoHub");
                    return;
                }

                string url = "https://komodoproject.zya.me/update_subscription.php?school_id=1" +
                    "&plan=" + Uri.EscapeDataString(plan) +
                    "&status=" + Uri.EscapeDataString(status) +
                    "&end_date=" + Uri.EscapeDataString(endDate);

                string response = await NavigateAndReadResponseAsync(url, 15000);
                response = response.Trim();

                if (response.Contains("SUCCESS"))
                {
                    MessageBox.Show("Subscription updated successfully!", "KomodoHub");
                    await LoadSubscriptionAsync();
                }
                else
                {
                    MessageBox.Show("Update failed: " + response, "KomodoHub");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "KomodoHub");
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadSubscriptionAsync();
        }
    }
}

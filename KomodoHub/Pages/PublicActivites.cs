using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Net.Http;
using System.IO;

namespace KomodoHub.Pages
{
    public partial class PublicActivites : UserControl
    {
        public event Action? BackToLibraryRequested;
        public event Action? BackHomeRequested;

        private List<Activity> activities = new List<Activity>();
        private WebView2 webViewLoader = null!;
        private bool webViewReady = false;

        public PublicActivites()
        {
            InitializeComponent();
            InitializeHiddenWebView();
            lstActivities.SelectedIndexChanged += lstActivities_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
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

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadActivities();
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
                LoadActivitiesIntoListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading activities: " + ex.Message);
            }
        }

        private void LoadActivitiesIntoListBox()
        {
            lstActivities.Items.Clear();
            foreach (Activity a in activities)
                lstActivities.Items.Add(a.title);

            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtContent.Text = "";
            picActivities.Image = null;

            if (lstActivities.Items.Count == 0)
                txtContent.Text = "No activities found.";
        }

        private async void lstActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstActivities.SelectedIndex != -1)
            {
                Activity selected = activities[lstActivities.SelectedIndex];
                txtTitle.Text = selected.title;
                txtAuthor.Text = selected.activity_type;
                txtContent.Text = selected.description;
                picActivities.Image = null;

                if (!string.IsNullOrEmpty(selected.image_path))
                    picActivities.Image = await LoadImageFromUrlAsync(selected.image_path);
            }
        }
        private async Task<Image> LoadImageFromUrlAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync(url);
                    var ms = new MemoryStream(bytes);
                    return new Bitmap(ms);
                }
            }
            catch { return null; }
        }

        private void btnBackToLibrary_Click(object sender, EventArgs e)
        {
            BackToLibraryRequested?.Invoke();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            BackHomeRequested?.Invoke();
        }

        private void OverViewButton_Click(object sender, EventArgs e)
        {
            BackToLibraryRequested?.Invoke();
        }

        private void PublicActivites_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void txtContent_TextChanged(object sender, EventArgs e) { }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            lstActivities.Items.Clear();

            foreach (Activity a in activities)
            {
                if (a.title.ToLower().Contains(search))
                    lstActivities.Items.Add(a.title);
            }
        }

        private void picActivities_Click(object sender, EventArgs e)
        {

        }
    }
}
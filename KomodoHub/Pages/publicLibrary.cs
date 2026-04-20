using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    public partial class publicLibrary : Form
    {
        public publicLibrary()
        {
            InitializeComponent();
        }

        private WebView2 webViewHidden = null!;
        private bool webViewReady = false;

        private readonly List<LibraryListEntry> libraryEntries = new List<LibraryListEntry>();

        private class LibraryListEntry
        {
            public int Id { get; set; }
            public string Title { get; set; } = "";

            public override string ToString()
            {
                return Title;
            }
        }

        private async Task InitializeWebViewAsync()
        {
            if (webViewHidden == null)
            {
                webViewHidden = new WebView2
                {
                    Visible = false,
                    Width = 1,
                    Height = 1,
                    Left = -1000,
                    Top = -1000
                };

                Controls.Add(webViewHidden);
            }

            if (!webViewReady)
            {
                await webViewHidden.EnsureCoreWebView2Async(null);
                webViewReady = true;
            }
        }

        private async Task WaitForWebViewReady()
        {
            if (!webViewReady || webViewHidden == null || webViewHidden.CoreWebView2 == null)
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
                        if (webViewHidden?.CoreWebView2 != null)
                            webViewHidden.CoreWebView2.NavigationCompleted -= handler;

                        tcs.TrySetException(new Exception("Navigation failed."));
                        return;
                    }

                    string result = await webViewHidden.ExecuteScriptAsync(@"
                        (function() {
                            if (document.body)
                                return document.body.innerText || document.body.textContent || '';
                            return '';
                        })();
                    ");

                    string text = DecodeJsString(result);

                    if (webViewHidden?.CoreWebView2 != null)
                        webViewHidden.CoreWebView2.NavigationCompleted -= handler;

                    tcs.TrySetResult(text);
                }
                catch (Exception ex)
                {
                    if (webViewHidden?.CoreWebView2 != null)
                        webViewHidden.CoreWebView2.NavigationCompleted -= handler;

                    tcs.TrySetException(ex);
                }
            };

            webViewHidden.CoreWebView2.NavigationCompleted += handler;
            webViewHidden.CoreWebView2.Navigate(url);

            Task completedTask = await Task.WhenAny(tcs.Task, Task.Delay(timeoutMs));

            if (completedTask != tcs.Task)
            {
                if (webViewHidden?.CoreWebView2 != null)
                    webViewHidden.CoreWebView2.NavigationCompleted -= handler;

                throw new TimeoutException("Request timed out.");
            }

            return await tcs.Task;
        }

        private async Task LoadLibraryListAsync()
        {
            try
            {
                string url = "http://komodoproject.zya.me/public_lib/get_public_library_list.php";
                string response = await NavigateAndReadResponseAsync(url, 10000);

                lstItems.Items.Clear();
                libraryEntries.Clear();

                string[] lines = response.Split(
                    new[] { "\r\n", "\n" },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string line in lines)
                {
                    if (line.StartsWith("ERROR", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(line);
                        return;
                    }

                    string[] parts = line.Split('|');
                    if (parts.Length >= 2 && int.TryParse(parts[0], out int id))
                    {
                        string title = parts[1];

                        var entry = new LibraryListEntry
                        {
                            Id = id,
                            Title = title
                        };

                        libraryEntries.Add(entry);
                        lstItems.Items.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading library list: " + ex.Message);
            }
        }

        private async Task LoadLibraryItemAsync(int id)
        {
            try
            {
                string url = "http://komodoproject.zya.me/public_lib/get_public_library_item.php?id=" + id;
                string json = await NavigateAndReadResponseAsync(url, 10000);

                if (string.IsNullOrWhiteSpace(json))
                {
                    MessageBox.Show("No item data returned.");
                    return;
                }

                PublicLibraryItem? item = JsonSerializer.Deserialize<PublicLibraryItem>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (item == null)
                {
                    MessageBox.Show("Failed to load item.");
                    return;
                }

                txtTitle.Text = item.title ?? "";
                txtAuthor.Text = item.author ?? "";

                txtContent.Text =
                    "Animal: " + (item.animal_name ?? "") + Environment.NewLine +
                    "Species: " + (item.species ?? "") + Environment.NewLine +
                    "Habitat: " + (item.habitat ?? "") + Environment.NewLine +
                    "Conservation Status: " + (item.conservation_status ?? "") + Environment.NewLine +
                    Environment.NewLine +
                    (item.content ?? "");

               await LoadImageToPictureBoxAsync(item.image_url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading library item: " + ex.Message);
            }
        }

        private async Task LoadImageToPictureBoxAsync(string imageUrl)
        {
            try
            {
                picItem.ImageLocation = null;
                picItem.Image = null;
                picItem.SizeMode = PictureBoxSizeMode.Zoom;

                if (string.IsNullOrWhiteSpace(imageUrl))
                    return;

                using var client = new System.Net.Http.HttpClient();
                client.Timeout = TimeSpan.FromSeconds(15);

                byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                using var ms = new System.IO.MemoryStream(imageBytes);
                picItem.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                picItem.Image = null;
                MessageBox.Show("Image failed to load: " + ex.Message);
            }
        }

        private async void publicLibrary_Load(object sender, EventArgs e)
        {
            await InitializeWebViewAsync();
            await LoadLibraryListAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadLibraryListAsync();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
        }

        private async void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem is LibraryListEntry selected)
            {
                await LoadLibraryItemAsync(selected.Id);
            }
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
        }

        private void publicLibrary_Load_1(object sender, EventArgs e)
        {

        }
    }
}
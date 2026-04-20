using Microsoft.Web.WebView2.Core;
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

namespace KomodoHub
{
    public partial class msgSystem : Form
    {

        private WebView2 webViewRegister = null!;
        bool webViewReady = false;

        public msgSystem()
        {
            InitializeComponent();
            if (webViewReady == false)
            {
                InitializeHiddenWebView();
                webViewReady = true;
            }
        }

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
        private async void msgSystem_Load(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //http://komodoproject.zya.me/messageSystem/add_message.php?username=myTeacher&password=teacher123&message=hello
            string urlbuild = "http://komodoproject.zya.me/messageSystem/add_message.php?username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password + "&sendTo=" + UserList.SelectedItem.ToString() + "&message=" + MessageSendBox.Text;
            string response = await NavigateAndReadResponseAsync(urlbuild, 15000);
            response = response.Trim();

            if (response.Contains("Message added successfully."))
            {
                MessageBox.Show("Message sent successfully");
            }
            else
            {
                MessageBox.Show("Message did not send");
                MessageBox.Show(response);
                MessageBox.Show(Properties.Settings.Default.Username);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //http://komodoproject.zya.me/messageSystem/read_message.php?username=MyTeacher&password=teacher123
            string urlbuild = "http://komodoproject.zya.me/messageSystem/read_message.php?username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password;
            string response = await NavigateAndReadResponseAsync(urlbuild, 15000);
            response = response.Trim();

            messageBoxRecieved.Text = response;

            //http://komodoproject.zya.me/messageSystem/get_users.php?username=MyTeacher&password=teacher123
            string urlbuild2 = "http://komodoproject.zya.me/messageSystem/get_users.php?username=" + Properties.Settings.Default.Username + "&password=" + Properties.Settings.Default.Password;
            string response2 = await NavigateAndReadResponseAsync(urlbuild2, 15000);
            response2 = response2.Trim();

            UserList.Items.Clear();

            string[] users = response2.Split(
                new[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries
            );

            foreach (string user in users)
            {
                if (!user.StartsWith("ERROR") &&
                    user != "Invalid username." &&
                    user != "Invalid password." &&
                    user != "Missing username or password.")
                {
                    UserList.Items.Add(user);
                }
                else
                {
                    MessageBox.Show(user);
                    break;
                }
            }
        }
    }
}

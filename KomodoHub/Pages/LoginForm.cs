using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace KomodoHub
{
    public partial class LoginForm : UserControl
    {
        // 1. EVENTS AT THE TOP: This makes them easy to find!
        public event Action<int>? LoginStateChanged; // 1 = user, 2 = guest
        public event Action? RegisterRequested;

        private WebView2 webViewRegister = null!;
        private bool webViewReady = false;
        public LoginForm()
        {
            InitializeComponent();
            SetupPlaceholders();
            InitializeHiddenWebView();
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

        private async void btnlogin_Click(object sender, EventArgs e)
        {

            //Properties.Settings.Default.LoggedIn = 1; 
            //Properties.Settings.Default.Save();


            // http://komodoproject.zya.me/login.php?name=Brian&password=1234 is url example.
            try
            {
                string urlbuild = "http://komodoproject.zya.me/authentication/login.php?name=" + txtUsername.Text + "&password=" + txtPassword.Text;
                string response = await NavigateAndReadResponseAsync(urlbuild, 15000);
                response = response.Trim();


                if (response.Contains("LOGIN_SUCCESS"))
                {
                    string[] parts = response.Split('|');
                    KomodoHub.UserRole = parts.Length > 3 ? parts[3].ToUpper() : "STUDENT";
                    
                    MessageBox.Show("Login Success!");
                    Properties.Settings.Default.LoggedIn = 1;
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Save();

                    if (Remember_Me.Checked)
                    {
                        Properties.Settings.Default.RememberMe = true;
                        Properties.Settings.Default.Password = txtPassword.Text;
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.Password = "";
                    }

                    Properties.Settings.Default.Save();

                }
                else
                {
                    MessageBox.Show("Login failed. Please check your username and password.");
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Login error: " + error.Message);
                return;
            }




            LoginStateChanged?.Invoke(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Guest login
            Properties.Settings.Default.LoggedIn = 2;
            Properties.Settings.Default.Save();

            LoginStateChanged?.Invoke(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterRequested?.Invoke();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            if (Properties.Settings.Default.RememberMe)
            {
                Remember_Me.Checked = true;
                txtUsername.Text = Properties.Settings.Default.Username;
                txtUsername.ForeColor = Color.Black;
                txtPassword.Text = Properties.Settings.Default.Password;
                txtPassword.ForeColor = Color.Black;
                LoginStateChanged?.Invoke(1);
            }
        }

        private void SetupPlaceholders()
        {
            // Username Placeholder
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Text = "Username";

            txtUsername.GotFocus += (s, e) =>
            {
                if (txtUsername.ForeColor == Color.Gray)
                {
                    txtUsername.Text = "";
                    txtUsername.ForeColor = Color.Black;
                }
            };

            txtUsername.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Text = "Username";
                    txtUsername.ForeColor = Color.Gray;
                }
            };

            // Password Placeholder
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "Password";

            txtPassword.GotFocus += (s, e) =>
            {
                if (txtPassword.ForeColor == Color.Gray)
                {
                    txtPassword.Text = "";
                    txtPassword.ForeColor = Color.Black;
                }
            };

            txtPassword.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.Text = "Password";
                    txtPassword.ForeColor = Color.Gray;
                }
            };
        }

        private void Remember_Me_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
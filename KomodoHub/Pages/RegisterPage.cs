using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace KomodoHub.Pages
{
    public partial class RegisterPage : UserControl
    {
        public event Action? BackToLoginRequested;
        public event Action? RegisterCompleted;

        private WebView2 webViewRegister = null!;
        private bool webViewReady = false;

        public RegisterPage()
        {
            InitializeComponent();
            SetupUI();
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

        private void SetupUI()
        {
            BackColor = Color.FromArgb(30, 30, 30);
            txtNewUsername.ForeColor = Color.Gray;
            txtNewUsername.Text = "Username";
            txtNewUsername.Enter += (s, e) =>
            {
                if (txtNewUsername.Text == "Username")
                {
                    txtNewUsername.Text = "";
                    txtNewUsername.ForeColor = Color.Black;
                }
            };
            txtNewUsername.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNewUsername.Text))
                {
                    txtNewUsername.Text = "Username";
                    txtNewUsername.ForeColor = Color.Gray;
                }
            };
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Text = "Email";
            txtEmail.Enter += (s, e) =>
            {
                if (txtEmail.Text == "Email")
                {
                    txtEmail.Text = "";
                    txtEmail.ForeColor = Color.Black;
                }
            };
            txtEmail.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Text = "Email";
                    txtEmail.ForeColor = Color.Gray;
                }
            };
            txtNewPassword.ForeColor = Color.Gray;
            txtNewPassword.Text = "Password";
            txtNewPassword.UseSystemPasswordChar = false;

            txtNewPassword.Enter += (s, e) =>
            {
                if (txtNewPassword.Text == "Password")
                {
                    txtNewPassword.Text = "";
                    txtNewPassword.ForeColor = Color.Black;
                    txtNewPassword.UseSystemPasswordChar = true;
                }
            };

            txtNewPassword.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    txtNewPassword.UseSystemPasswordChar = false;
                    txtNewPassword.Text = "Password";
                    txtNewPassword.ForeColor = Color.Gray;
                }
            };
            txtConfirmPassword.ForeColor = Color.Gray;
            txtConfirmPassword.Text = "Confirm Password";
            txtConfirmPassword.UseSystemPasswordChar = false;

            txtConfirmPassword.Enter += (s, e) =>
            {
                if (txtConfirmPassword.Text == "Confirm Password")
                {
                    txtConfirmPassword.Text = "";
                    txtConfirmPassword.ForeColor = Color.Black;
                    txtConfirmPassword.UseSystemPasswordChar = true;
                }
            };

            txtConfirmPassword.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    txtConfirmPassword.UseSystemPasswordChar = false;
                    txtConfirmPassword.Text = "Confirm Password";
                    txtConfirmPassword.ForeColor = Color.Gray;
                }
            };
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            BackToLoginRequested?.Invoke();
        }

        private async void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string name = txtNewUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!ValidateInputs(name, email, password, confirmPassword))
                return;

            if (!webViewReady || webViewRegister.CoreWebView2 == null)
            {
                MessageBox.Show("WebView2 is not ready yet.");
                return;
            }

            btnCreateAccount.Enabled = false;

            try
            {
                string url = "http://komodoproject.zya.me/authentication/register.php?name="
                    + Uri.EscapeDataString(name)
                    + "&email="
                    + Uri.EscapeDataString(email)
                    + "&password="
                    + Uri.EscapeDataString(password);

                string response = await NavigateAndReadResponseAsync(url, 15000);

                response = response.Trim();

                if (response.Contains("REGISTER_SUCCESS"))
                {
                    MessageBox.Show("Account created successfully.");
                    ClearFields();
                    RegisterCompleted?.Invoke();
                }
                else if (response.Contains("ALREADY_EXISTS"))
                {
                    MessageBox.Show("Username or email is already taken!", "KomodoHub");
                }
                else if (response.Contains("REGISTER_FAILED"))
                {
                    MessageBox.Show("Registration failed.");
                }
                else if (response.Contains("DB_ERROR"))
                {
                    MessageBox.Show("Database connection failed.");
                }
                else if (response.Contains("MISSING_FIELDS"))
                {
                    MessageBox.Show("Missing fields.");
                }
                else if (response.Contains("EMPTY_FIELDS"))
                {
                    MessageBox.Show("Please fill in all fields.");
                }
                else
                {
                    MessageBox.Show("Registration failed: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to server.\n" + ex.Message);
            }
            btnCreateAccount.Enabled = true;
        }

        private bool ValidateInputs(string name, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(name) || name == "Username" ||
                string.IsNullOrWhiteSpace(email) || email == "Email" ||
                string.IsNullOrWhiteSpace(password) || password == "Password" ||
                string.IsNullOrWhiteSpace(confirmPassword) || confirmPassword == "Confirm Password")
            {
                MessageBox.Show("Please fill in all fields.", "KomodoHub");
                return false;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Please input a valid email", "KomodoHub");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "KomodoHub");
                return false;
            }

            return true;
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

                    if (text.Contains("REGISTER_SUCCESS") ||
                        text.Contains("REGISTER_FAILED") ||
                        text.Contains("DB_ERROR") ||
                        text.Contains("MISSING_FIELDS") ||
                        text.Contains("EMPTY_FIELDS") ||
                        text.Contains("ALREADY_EXISTS"))
                    {
                        webViewRegister.CoreWebView2.NavigationCompleted -= handler;
                        tcs.TrySetResult(text);
                    }
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

        private void ClearFields()
        {
            txtNewUsername.Text = "Username";
            txtNewUsername.ForeColor = Color.Gray;

            txtEmail.Text = "Email";
            txtEmail.ForeColor = Color.Gray;

            txtNewPassword.UseSystemPasswordChar = false;
            txtNewPassword.Text = "Password";
            txtNewPassword.ForeColor = Color.Gray;

            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.Text = "Confirm Password";
            txtConfirmPassword.ForeColor = Color.Gray;
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }
    }
}
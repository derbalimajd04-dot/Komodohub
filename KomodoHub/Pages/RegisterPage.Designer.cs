namespace KomodoHub.Pages
{
    partial class RegisterPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPage));
            pictureBox2 = new PictureBox();
            txtNewUsername = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnCreateAccount = new Button();
            btnBackToLogin = new Button();
            txtEmail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(397, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(229, 196);
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new Point(397, 240);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(229, 23);
            txtNewUsername.TabIndex = 21;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(397, 328);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(229, 23);
            txtNewPassword.TabIndex = 22;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(397, 379);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(229, 23);
            txtConfirmPassword.TabIndex = 23;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(397, 437);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(229, 47);
            btnCreateAccount.TabIndex = 24;
            btnCreateAccount.Text = "Creat a new account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.Location = new Point(448, 507);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(126, 23);
            btnBackToLogin.TabIndex = 25;
            btnBackToLogin.Text = "back to login";
            btnBackToLogin.UseVisualStyleBackColor = true;
            btnBackToLogin.Click += btnBackToLogin_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(397, 284);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(229, 23);
            txtEmail.TabIndex = 26;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(txtEmail);
            Controls.Add(btnBackToLogin);
            Controls.Add(btnCreateAccount);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtNewUsername);
            Controls.Add(pictureBox2);
            Name = "RegisterPage";
            Size = new Size(1097, 789);
            Load += RegisterPage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private TextBox txtNewUsername;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnCreateAccount;
        private Button btnBackToLogin;
        private TextBox txtEmail;
    }
}

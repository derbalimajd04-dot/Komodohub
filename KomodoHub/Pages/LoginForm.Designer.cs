namespace KomodoHub
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnlogin = new Button();
            label2 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            colorDialog1 = new ColorDialog();
            button1 = new Button();
            button2 = new Button();
            Remember_Me = new CheckBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnlogin
            // 
            btnlogin.Anchor = AnchorStyles.Top;
            btnlogin.BackColor = Color.SeaGreen;
            btnlogin.FlatAppearance.BorderColor = Color.FromArgb(65, 65, 65);
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnlogin.ForeColor = Color.White;
            btnlogin.Image = (Image)resources.GetObject("btnlogin.Image");
            btnlogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnlogin.Location = new Point(34, 324);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(344, 44);
            btnlogin.TabIndex = 12;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(34, 193);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(230, 240, 230);
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(34, 216);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(344, 33);
            txtPassword.TabIndex = 10;
            txtPassword.Text = "textbox2";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(230, 240, 230);
            txtUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(34, 154);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(344, 33);
            txtUsername.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ScrollBar;
            label1.Location = new Point(34, 131);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 8;
            label1.Text = "Username";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(35, 100, 65);
            button1.FlatAppearance.BorderColor = Color.FromArgb(65, 65, 65);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(34, 374);
            button1.Name = "button1";
            button1.Size = new Size(344, 44);
            button1.TabIndex = 16;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(60, 60, 60);
            button2.FlatAppearance.BorderColor = Color.FromArgb(65, 65, 65);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(34, 424);
            button2.Name = "button2";
            button2.Size = new Size(344, 44);
            button2.TabIndex = 17;
            button2.Text = "Continue as Guest";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Remember_Me
            // 
            Remember_Me.AutoSize = true;
            Remember_Me.BackColor = Color.Transparent;
            Remember_Me.FlatAppearance.BorderColor = Color.Lime;
            Remember_Me.FlatStyle = FlatStyle.Flat;
            Remember_Me.ForeColor = SystemColors.ScrollBar;
            Remember_Me.Location = new Point(34, 295);
            Remember_Me.Name = "Remember_Me";
            Remember_Me.Size = new Size(101, 19);
            Remember_Me.TabIndex = 18;
            Remember_Me.Text = "Remember Me";
            Remember_Me.UseVisualStyleBackColor = false;
            Remember_Me.CheckedChanged += Remember_Me_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(222, 79);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 196);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(241, 283);
            label3.Name = "label3";
            label3.Size = new Size(193, 40);
            label3.TabIndex = 20;
            label3.Text = "KomodoHub";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(166, 323);
            label4.Name = "label4";
            label4.Size = new Size(351, 30);
            label4.TabIndex = 21;
            label4.Text = "Bringing Endangered Species Back";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(27, 67, 50);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Remember_Me);
            panel1.Controls.Add(btnlogin);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(847, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 540);
            panel1.TabIndex = 22;
            panel1.Paint += panel1_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ScrollBar;
            label6.Location = new Point(12, 63);
            label6.Name = "label6";
            label6.Size = new Size(391, 20);
            label6.TabIndex = 20;
            label6.Text = "Enter your email and password to access your account.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(98, 26);
            label5.Name = "label5";
            label5.Size = new Size(218, 37);
            label5.TabIndex = 19;
            label5.Text = "Welcome back!";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlDarkDark;
            Name = "LoginForm";
            Size = new Size(1287, 695);
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlogin;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private ColorDialog colorDialog1;
        private Button button1;
        private Button button2;
        private CheckBox Remember_Me;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label6;
        private Label label5;
    }
}

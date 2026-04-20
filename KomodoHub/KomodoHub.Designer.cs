using KomodoHub.Pages;

namespace KomodoHub
{
    partial class KomodoHub
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KomodoHub));
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            label5 = new Label();
            button4 = new Button();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            LibraryButton = new Button();
            OverViewButton = new Button();
            panel3 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            loginForm2 = new LoginForm();
            library1 = new Pages.Library();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            BackgroundChecker = new System.Windows.Forms.Timer(components);
            bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
            homePage1 = new Pages.HomePage();
            registerPage1 = new Pages.RegisterPage();
            teacherPage1 = new Pages.TeacherPage();
            teacherFeedbackPage1 = new Pages.TeacherFeedbackPage();
            submissionPage1 = new Pages.SubmissionPage();
            publicActivites1 = new Pages.PublicActivites();
            sightingsPage1 = new Pages.SightingsPage();
            enrolmentPage1 = new Pages.EnrolmentPage();
            subscriptionPage1 = new Pages.SubscriptionPage();
            button5 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 65, 65);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 37);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Lime;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(1210, 9);
            button3.Name = "button3";
            button3.Size = new Size(27, 23);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Lime;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(1245, 9);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Lime;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1280, 9);
            button1.Name = "button1";
            button1.Size = new Size(27, 23);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(65, 65, 65);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(LibraryButton);
            panel2.Controls.Add(OverViewButton);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, -3);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 781);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(60, 60, 60);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(button4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(0, 619);
            panel4.Name = "panel4";
            panel4.Size = new Size(212, 114);
            panel4.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(35, 83);
            label5.Name = "label5";
            label5.Size = new Size(42, 13);
            label5.TabIndex = 7;
            label5.Text = "Online";
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.Lime;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(13, 77);
            button4.Name = "button4";
            button4.Size = new Size(27, 23);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(73, 31);
            label3.Name = "label3";
            label3.Size = new Size(100, 13);
            label3.TabIndex = 4;
            label3.Text = "Brian Kruczkowski";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(17, 19);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(125, 56);
            label4.Name = "label4";
            label4.Size = new Size(48, 13);
            label4.TabIndex = 5;
            label4.Text = "Student";
            // 
            // LibraryButton
            // 
            LibraryButton.BackColor = Color.FromArgb(60, 60, 60);
            LibraryButton.FlatAppearance.BorderSize = 0;
            LibraryButton.FlatStyle = FlatStyle.Flat;
            LibraryButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LibraryButton.ForeColor = Color.White;
            LibraryButton.Location = new Point(13, 144);
            LibraryButton.Name = "LibraryButton";
            LibraryButton.Size = new Size(187, 40);
            LibraryButton.TabIndex = 7;
            LibraryButton.Text = "Library";
            LibraryButton.UseVisualStyleBackColor = false;
            LibraryButton.Click += LibraryButton_Click;
            // 
            // OverViewButton
            // 
            OverViewButton.BackColor = Color.FromArgb(60, 60, 60);
            OverViewButton.FlatAppearance.BorderSize = 0;
            OverViewButton.FlatStyle = FlatStyle.Flat;
            OverViewButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OverViewButton.ForeColor = Color.White;
            OverViewButton.Location = new Point(13, 98);
            OverViewButton.Name = "OverViewButton";
            OverViewButton.Size = new Size(187, 40);
            OverViewButton.TabIndex = 2;
            OverViewButton.Text = "OverView";
            OverViewButton.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(60, 60, 60);
            panel3.Location = new Point(212, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(13, 752);
            panel3.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(62, 49);
            label2.Name = "label2";
            label2.Size = new Size(148, 13);
            label2.TabIndex = 3;
            label2.Text = "Saving Endangered Species";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(5, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 10);
            label1.Name = "label1";
            label1.Size = new Size(150, 32);
            label1.TabIndex = 2;
            label1.Text = "KomodoHub";
            // 
            // loginForm2
            // 
            loginForm2.ForeColor = SystemColors.ControlDarkDark;
            loginForm2.Location = new Point(216, 35);
            loginForm2.Name = "loginForm2";
            loginForm2.Size = new Size(1097, 695);
            loginForm2.TabIndex = 2;
            // 
            // library1
            // 
            library1.BackColor = Color.FromArgb(65, 65, 65);
            library1.BackgroundImage = (Image)resources.GetObject("library1.BackgroundImage");
            library1.BackgroundImageLayout = ImageLayout.Stretch;
            library1.Location = new Point(216, 35);
            library1.Name = "library1";
            library1.Size = new Size(1097, 695);
            library1.TabIndex = 3;
            library1.Visible = false;
            // enrolmentPage1
            enrolmentPage1.BackColor = Color.FromArgb(20, 40, 25);
            enrolmentPage1.Location = new Point(216, 35);
            enrolmentPage1.Name = "enrolmentPage1";
            enrolmentPage1.Size = new Size(1097, 695);
            enrolmentPage1.TabIndex = 13;
            enrolmentPage1.Visible = false;
            // subscriptionPage1
            subscriptionPage1.BackColor = Color.FromArgb(20, 40, 25);
            subscriptionPage1.Location = new Point(216, 35);
            subscriptionPage1.Name = "subscriptionPage1";
            subscriptionPage1.Size = new Size(1097, 695);
            subscriptionPage1.TabIndex = 14;
            subscriptionPage1.Visible = false;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 10;
            bunifuElipse1.TargetControl = LibraryButton;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 20;
            bunifuElipse2.TargetControl = OverViewButton;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 10;
            bunifuElipse3.TargetControl = this;
            // 
            // BackgroundChecker
            // 
            BackgroundChecker.Enabled = true;
            BackgroundChecker.Tick += BackgroundChecker_Tick;
            // 
            // bunifuDragControl1
            // 
            bunifuDragControl1.Fixed = true;
            bunifuDragControl1.Horizontal = true;
            bunifuDragControl1.TargetControl = panel1;
            bunifuDragControl1.Vertical = true;
            // 
            // homePage1
            // 
            homePage1.BackColor = Color.FromArgb(60, 60, 60);
            homePage1.BackgroundImageLayout = ImageLayout.Zoom;
            homePage1.Location = new Point(216, 35);
            homePage1.Name = "homePage1";
            homePage1.Size = new Size(1097, 695);
            homePage1.TabIndex = 4;
            homePage1.Visible = false;
            // 
            // registerPage1
            // 
            registerPage1.BackColor = SystemColors.ControlDarkDark;
            registerPage1.Location = new Point(215, 35);
            registerPage1.Name = "registerPage1";
            registerPage1.Size = new Size(1097, 789);
            registerPage1.TabIndex = 5;
            registerPage1.Visible = false;
            // 
            // teacherPage1
            // 
            teacherPage1.BackColor = Color.FromArgb(20, 40, 25);
            teacherPage1.Location = new Point(216, 35);
            teacherPage1.Name = "teacherPage1";
            teacherPage1.Size = new Size(1097, 695);
            teacherPage1.TabIndex = 6;
            teacherPage1.Visible = false;
            teacherPage1.Load += teacherPage1_Load;

            // teacherFeedbackPage1
            teacherFeedbackPage1.BackColor = Color.FromArgb(50, 50, 50);
            teacherFeedbackPage1.Location = new Point(216, 35);
            teacherFeedbackPage1.Name = "teacherFeedbackPage1";
            teacherFeedbackPage1.Size = new Size(1097, 695);
            teacherFeedbackPage1.TabIndex = 11;
            teacherFeedbackPage1.Visible = false;

            submissionPage1.BackColor = Color.FromArgb(50, 50, 50);
            submissionPage1.Location = new Point(216, 35);
            submissionPage1.Name = "submissionPage1";
            submissionPage1.Size = new Size(1097, 695);
            submissionPage1.TabIndex = 10;
            submissionPage1.Visible = false;
            // 
            // publicActivites1
            // 
            publicActivites1.Location = new Point(216, 35);
            publicActivites1.Name = "publicActivites1";
            publicActivites1.Size = new Size(1097, 695);
            publicActivites1.TabIndex = 7;
            publicActivites1.Visible = false;
            //
            // sightingsPage1
            //
            sightingsPage1.Location = new Point(216, 35);
            sightingsPage1.Name = "sightingsPage1";
            sightingsPage1.Size = new Size(1097, 695);
            sightingsPage1.TabIndex = 12;
            sightingsPage1.Visible = false;
            //
            // button5
            // 
            button5.BackColor = Color.FromArgb(60, 60, 60);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(13, 562);
            button5.Name = "button5";
            button5.Size = new Size(187, 40);
            button5.TabIndex = 9;
            button5.Text = "Teacher Tools";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // KomodoHub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(1314, 728);
            Controls.Add(teacherPage1);
            Controls.Add(teacherFeedbackPage1);
            Controls.Add(submissionPage1);
            Controls.Add(sightingsPage1);
            Controls.Add(publicActivites1);
            Controls.Add(registerPage1);
            Controls.Add(homePage1);
            Controls.Add(library1);
            Controls.Add(panel1);
            Controls.Add(loginForm2);
            Controls.Add(panel2);
            Controls.Add(enrolmentPage1);
            Controls.Add(subscriptionPage1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KomodoHub";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KomodoHub";
            Load += KomodoHub_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);




        }

        #endregion

        private Panel panel1;
        private LoginForm loginForm1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button OverViewButton;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition1;
        private Button LibraryButton;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private LoginForm loginForm2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Timer BackgroundChecker;
        private Pages.Library library1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Panel panel4;
        private Label label5;
        private Button button4;
        private global::KomodoHub.Pages.HomePage homePage1;
        //private global::KomodoHub.Pages.MessagingSystem messagingPage1;
        private global::KomodoHub.Pages.RegisterPage registerPage1;
        private Pages.TeacherPage teacherPage1;
        private Pages.TeacherFeedbackPage teacherFeedbackPage1;
        private Pages.SubmissionPage submissionPage1;
        private Pages.PublicActivites publicActivites1;
        private Pages.SightingsPage sightingsPage1;
        private Pages.EnrolmentPage enrolmentPage1;
        private Pages.SubscriptionPage subscriptionPage1;
        private Button button5;
    }
}
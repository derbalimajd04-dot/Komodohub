namespace KomodoHub.Pages
{
    partial class TeacherPage
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
            txtCode = new TextBox();
            txtDaysExpiry = new TextBox();
            button1 = new Button();
            txtSchoolId = new TextBox();
            panelGenerateCode = new Panel();
            label1 = new Label();
            panelCreateActivity = new Panel();
            picImagePreview = new PictureBox();
            btnChooseImage = new Button();
            lblImage = new Label();
            btnCreateActivity = new Button();
            txtDueDate = new TextBox();
            label9 = new Label();
            txtActivityType = new TextBox();
            label8 = new Label();
            txtActivityDescription = new TextBox();
            label7 = new Label();
            txtActivityTitle = new TextBox();
            label6 = new Label();
            label2 = new Label();
            label10 = new Label();
            panel1 = new Panel();
            btnGoToFeedback = new Button();
            btnManageSubscription = new Button();
            btnBackHome = new Button();
            panelGenerateCode.SuspendLayout();
            panelCreateActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImagePreview).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(88, 129);
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "Code";
            txtCode.Size = new Size(265, 23);
            txtCode.TabIndex = 0;
            // 
            // txtDaysExpiry
            // 
            txtDaysExpiry.Location = new Point(88, 173);
            txtDaysExpiry.Name = "txtDaysExpiry";
            txtDaysExpiry.PlaceholderText = "1";
            txtDaysExpiry.Size = new Size(265, 23);
            txtDaysExpiry.TabIndex = 1;
            txtDaysExpiry.TextChanged += txtDaysExpiry_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.Location = new Point(88, 262);
            button1.Name = "button1";
            button1.Size = new Size(265, 38);
            button1.TabIndex = 2;
            button1.Text = "Generate Code";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtSchoolId
            // 
            txtSchoolId.Location = new Point(88, 217);
            txtSchoolId.Name = "txtSchoolId";
            txtSchoolId.PlaceholderText = "school id ";
            txtSchoolId.Size = new Size(265, 23);
            txtSchoolId.TabIndex = 3;
            txtSchoolId.TextChanged += txtSchoolId_TextChanged;
            // 
            // panelGenerateCode
            // 
            panelGenerateCode.BackColor = Color.FromArgb(35, 55, 40);
            panelGenerateCode.Controls.Add(button1);
            panelGenerateCode.Controls.Add(label1);
            panelGenerateCode.Controls.Add(txtCode);
            panelGenerateCode.Controls.Add(txtSchoolId);
            panelGenerateCode.Controls.Add(txtDaysExpiry);
            panelGenerateCode.Location = new Point(22, 62);
            panelGenerateCode.Name = "panelGenerateCode";
            panelGenerateCode.Size = new Size(522, 566);
            panelGenerateCode.TabIndex = 4;
            panelGenerateCode.Paint += panelGenerateCode_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(103, 83);
            label1.Name = "label1";
            label1.Size = new Size(227, 30);
            label1.TabIndex = 4;
            label1.Text = "Generate Access Code";
            // 
            // panelCreateActivity
            // 
            panelCreateActivity.BackColor = Color.FromArgb(35, 55, 40);
            panelCreateActivity.Controls.Add(picImagePreview);
            panelCreateActivity.Controls.Add(btnChooseImage);
            panelCreateActivity.Controls.Add(lblImage);
            panelCreateActivity.Controls.Add(btnCreateActivity);
            panelCreateActivity.Controls.Add(txtDueDate);
            panelCreateActivity.Controls.Add(label9);
            panelCreateActivity.Controls.Add(txtActivityType);
            panelCreateActivity.Controls.Add(label8);
            panelCreateActivity.Controls.Add(txtActivityDescription);
            panelCreateActivity.Controls.Add(label7);
            panelCreateActivity.Controls.Add(txtActivityTitle);
            panelCreateActivity.Controls.Add(label6);
            panelCreateActivity.Controls.Add(label2);
            panelCreateActivity.Location = new Point(550, 62);
            panelCreateActivity.Name = "panelCreateActivity";
            panelCreateActivity.Size = new Size(523, 566);
            panelCreateActivity.TabIndex = 5;
            panelCreateActivity.Paint += panelCreateActivity_Paint;
            // 
            // picImagePreview
            // 
            picImagePreview.BorderStyle = BorderStyle.FixedSingle;
            picImagePreview.Location = new Point(132, 382);
            picImagePreview.Name = "picImagePreview";
            picImagePreview.Size = new Size(265, 86);
            picImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picImagePreview.TabIndex = 17;
            picImagePreview.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.Teal;
            btnChooseImage.ForeColor = Color.White;
            btnChooseImage.Location = new Point(132, 348);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(265, 23);
            btnChooseImage.TabIndex = 16;
            btnChooseImage.Text = "Choose Image";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblImage.ForeColor = Color.White;
            lblImage.Location = new Point(132, 331);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(88, 15);
            lblImage.TabIndex = 15;
            lblImage.Text = "Activity Image";
            // 
            // btnCreateActivity
            // 
            btnCreateActivity.BackColor = Color.Teal;
            btnCreateActivity.Location = new Point(132, 474);
            btnCreateActivity.Name = "btnCreateActivity";
            btnCreateActivity.Size = new Size(265, 39);
            btnCreateActivity.TabIndex = 14;
            btnCreateActivity.Text = "Create Activity";
            btnCreateActivity.UseVisualStyleBackColor = false;
            btnCreateActivity.Click += btnCreateActivity_Click;
            // 
            // txtDueDate
            // 
            txtDueDate.Location = new Point(132, 305);
            txtDueDate.Name = "txtDueDate";
            txtDueDate.PlaceholderText = "2026-07-20";
            txtDueDate.Size = new Size(265, 23);
            txtDueDate.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(132, 287);
            label9.Name = "label9";
            label9.Size = new Size(149, 15);
            label9.TabIndex = 12;
            label9.Text = "Due Date (YYYY-MM-DD)";
            // 
            // txtActivityType
            // 
            txtActivityType.Location = new Point(132, 261);
            txtActivityType.Name = "txtActivityType";
            txtActivityType.PlaceholderText = "name";
            txtActivityType.Size = new Size(265, 23);
            txtActivityType.TabIndex = 11;
            txtActivityType.TextChanged += txtActivityType_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(132, 243);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 10;
            label8.Text = "Sumbitted by";
            // 
            // txtActivityDescription
            // 
            txtActivityDescription.Location = new Point(132, 113);
            txtActivityDescription.Multiline = true;
            txtActivityDescription.Name = "txtActivityDescription";
            txtActivityDescription.PlaceholderText = "Describe the activity";
            txtActivityDescription.Size = new Size(265, 127);
            txtActivityDescription.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(132, 95);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 8;
            label7.Text = "Description";
            // 
            // txtActivityTitle
            // 
            txtActivityTitle.Location = new Point(132, 69);
            txtActivityTitle.Name = "txtActivityTitle";
            txtActivityTitle.PlaceholderText = "e.g. javan rhino";
            txtActivityTitle.Size = new Size(265, 23);
            txtActivityTitle.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(132, 51);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 6;
            label6.Text = "Activity Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(160, 21);
            label2.Name = "label2";
            label2.Size = new Size(207, 30);
            label2.TabIndex = 0;
            label2.Text = "Create New Activity";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(33, 21);
            label10.Name = "label10";
            label10.Size = new Size(168, 32);
            label10.TabIndex = 6;
            label10.Text = "Teacher Tools";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 55, 40);
            panel1.Controls.Add(btnManageSubscription);
            panel1.Controls.Add(btnGoToFeedback);
            panel1.Controls.Add(btnBackHome);
            panel1.Location = new Point(0, 642);
            panel1.Name = "panel1";
            panel1.Size = new Size(1097, 53);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            //
            // btnManageSubscription
            //
            btnManageSubscription.BackColor = Color.FromArgb(60, 60, 60);
            btnManageSubscription.FlatAppearance.BorderSize = 0;
            btnManageSubscription.FlatStyle = FlatStyle.Flat;
            btnManageSubscription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnManageSubscription.ForeColor = Color.White;
            btnManageSubscription.Location = new Point(480, 6);
            btnManageSubscription.Name = "btnManageSubscription";
            btnManageSubscription.Size = new Size(187, 40);
            btnManageSubscription.TabIndex = 18;
            btnManageSubscription.Text = "Manage Subscription";
            btnManageSubscription.UseVisualStyleBackColor = true;
            btnManageSubscription.Click += btnManageSubscription_Click;
            //
            // btnGoToFeedback
            //
            btnGoToFeedback.BackColor = Color.FromArgb(60, 60, 60);
            btnGoToFeedback.FlatAppearance.BorderSize = 0;
            btnGoToFeedback.FlatStyle = FlatStyle.Flat;
            btnGoToFeedback.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGoToFeedback.ForeColor = Color.White;
            btnGoToFeedback.Location = new Point(683, 6);
            btnGoToFeedback.Name = "btnGoToFeedback";
            btnGoToFeedback.Size = new Size(187, 40);
            btnGoToFeedback.TabIndex = 17;
            btnGoToFeedback.Text = "View Student submissions";
            btnGoToFeedback.UseVisualStyleBackColor = true;
            btnGoToFeedback.Click += btnGoToFeedback_Click;
            // 
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.FromArgb(60, 60, 60);
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(886, 6);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(187, 40);
            btnBackHome.TabIndex = 16;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = true;
            btnBackHome.Click += btnBackHome_Click;
            // 
            // TeacherPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 40, 25);
            Controls.Add(panel1);
            Controls.Add(label10);
            Controls.Add(panelCreateActivity);
            Controls.Add(panelGenerateCode);
            Name = "TeacherPage";
            Size = new Size(1097, 695);
            Load += TeacherPage_Load;
            panelGenerateCode.ResumeLayout(false);
            panelGenerateCode.PerformLayout();
            panelCreateActivity.ResumeLayout(false);
            panelCreateActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImagePreview).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCode;
        private TextBox txtDaysExpiry;
        private Button button1;
        private TextBox txtSchoolId;
        private Panel panelGenerateCode;
        private Panel panelCreateActivity;
        private Label label1;
        private Label label2;
        private TextBox txtActivityTitle;
        private Label label6;
        private Button btnCreateActivity;
        private TextBox txtDueDate;
        private Label label9;
        private TextBox txtActivityType;
        private Label label8;
        private TextBox txtActivityDescription;
        private Label label7;
        private Label label10;
        private Panel panel1;
        private Button btnBackHome;
        private PictureBox picImagePreview;
        private Button btnChooseImage;
        private Label lblImage;
        private Button btnGoToFeedback;
        private Button btnManageSubscription;
    }
}

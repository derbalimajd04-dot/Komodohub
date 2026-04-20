namespace KomodoHub.Pages
{
    partial class SubmissionPage
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
            lstActivities = new ListBox();
            lblActivityDescription = new Label();
            lblDueDate = new Label();
            txtTitle = new TextBox();
            txtReportText = new TextBox();
            btnSubmit = new Button();
            btnBackHome = new Button();
            label1 = new Label();
            lblPageTitle = new Label();
            picPreview = new PictureBox();
            btnChooseImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // lstActivities
            // 
            lstActivities.FormattingEnabled = true;
            lstActivities.ItemHeight = 15;
            lstActivities.Location = new Point(25, 86);
            lstActivities.Name = "lstActivities";
            lstActivities.Size = new Size(236, 469);
            lstActivities.TabIndex = 0;
            lstActivities.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // lblActivityDescription
            // 
            lblActivityDescription.AutoSize = true;
            lblActivityDescription.Location = new Point(322, 242);
            lblActivityDescription.Name = "lblActivityDescription";
            lblActivityDescription.Size = new Size(110, 15);
            lblActivityDescription.TabIndex = 1;
            lblActivityDescription.Text = "Activity Description";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(322, 86);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(55, 15);
            lblDueDate.TabIndex = 2;
            lblDueDate.Text = "Due Date";
            lblDueDate.Click += lblDueDate_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(322, 212);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(395, 23);
            txtTitle.TabIndex = 3;
            // 
            // txtReportText
            // 
            txtReportText.Location = new Point(322, 260);
            txtReportText.Multiline = true;
            txtReportText.Name = "txtReportText";
            txtReportText.Size = new Size(395, 295);
            txtReportText.TabIndex = 4;
            txtReportText.TextChanged += txtReportText_TextChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(733, 532);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 11;
            // 
            // btnBackHome
            // 
            btnBackHome.Location = new Point(921, 532);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(136, 23);
            btnBackHome.TabIndex = 6;
            btnBackHome.Text = "back to home";
            btnBackHome.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 182);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 7;
            label1.Text = "Submission title ";
            label1.Click += label1_Click;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Location = new Point(25, 20);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(103, 15);
            lblPageTitle.TabIndex = 8;
            lblPageTitle.Text = "Submit Your Work";
            lblPageTitle.Click += label2_Click;
            // 
            // picPreview
            // 
            picPreview.Location = new Point(723, 260);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(202, 142);
            picPreview.TabIndex = 9;
            picPreview.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(742, 408);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(150, 23);
            btnChooseImage.TabIndex = 10;
            btnChooseImage.Text = "Choose Image";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // SubmissionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(btnChooseImage);
            Controls.Add(picPreview);
            Controls.Add(lblPageTitle);
            Controls.Add(label1);
            Controls.Add(btnBackHome);
            Controls.Add(btnSubmit);
            Controls.Add(txtReportText);
            Controls.Add(txtTitle);
            Controls.Add(lblDueDate);
            Controls.Add(lblActivityDescription);
            Controls.Add(lstActivities);
            Name = "SubmissionPage";
            Size = new Size(1114, 704);
            Load += SubmissionPage_Load;
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstActivities;
        private Label lblActivityDescription;
        private Label lblDueDate;
        private TextBox txtTitle;
        private TextBox txtReportText;
        private Button btnSubmit;
        private Button btnBackHome;
        private Label label1;
        private Label lblPageTitle;
        private PictureBox picPreview;
        private Button btnChooseImage;
    }
}

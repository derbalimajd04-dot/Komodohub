namespace KomodoHub.Pages
{
    partial class TeacherFeedbackPage
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
            btnPostFeedback = new Button();
            btnBackHome = new Button();
            lstSubmissions = new ListBox();
            txtFeedback = new TextBox();
            lblPageTitle = new Label();
            lblSubmissionDetail = new Label();
            SuspendLayout();
            // 
            // btnPostFeedback
            // 
            btnPostFeedback.Location = new Point(793, 494);
            btnPostFeedback.Name = "btnPostFeedback";
            btnPostFeedback.Size = new Size(149, 23);
            btnPostFeedback.TabIndex = 0;
            btnPostFeedback.Text = "Post feedback";
            btnPostFeedback.UseVisualStyleBackColor = true;
            btnPostFeedback.Click += btnPostFeedback_Click_1;
            // 
            // btnBackHome
            // 
            btnBackHome.Location = new Point(793, 590);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(149, 23);
            btnBackHome.TabIndex = 1;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = true;
            // 
            // lstSubmissions
            // 
            lstSubmissions.FormattingEnabled = true;
            lstSubmissions.ItemHeight = 15;
            lstSubmissions.Location = new Point(18, 94);
            lstSubmissions.Name = "lstSubmissions";
            lstSubmissions.Size = new Size(260, 544);
            lstSubmissions.TabIndex = 2;
            // 
            // txtFeedback
            // 
            txtFeedback.Location = new Point(325, 378);
            txtFeedback.Multiline = true;
            txtFeedback.Name = "txtFeedback";
            txtFeedback.Size = new Size(431, 260);
            txtFeedback.TabIndex = 3;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Location = new Point(325, 94);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(38, 15);
            lblPageTitle.TabIndex = 4;
            lblPageTitle.Text = "label1";
            lblPageTitle.Click += label1_Click;
            // 
            // lblSubmissionDetail
            // 
            lblSubmissionDetail.AutoSize = true;
            lblSubmissionDetail.Location = new Point(325, 172);
            lblSubmissionDetail.Name = "lblSubmissionDetail";
            lblSubmissionDetail.Size = new Size(101, 15);
            lblSubmissionDetail.TabIndex = 5;
            lblSubmissionDetail.Text = "Submission Detail";
            // 
            // TeacherFeedbackPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSubmissionDetail);
            Controls.Add(lblPageTitle);
            Controls.Add(txtFeedback);
            Controls.Add(lstSubmissions);
            Controls.Add(btnBackHome);
            Controls.Add(btnPostFeedback);
            Name = "TeacherFeedbackPage";
            Size = new Size(1029, 719);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPostFeedback;
        private Button btnBackHome;
        private ListBox lstSubmissions;
        private TextBox txtFeedback;
        private Label lblPageTitle;
        private Label lblSubmissionDetail;
    }
}

namespace KomodoHub.Pages
{
    partial class EnrolmentPage
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
            lblPageTitle = new Label();
            label2 = new Label();
            lblMyPrograms = new Label();
            lblProgramDetail = new Label();
            txtAccessCode = new TextBox();
            lblAvailable = new Label();
            btnEnroll = new Button();
            btnBackHome = new Button();
            lstAllPrograms = new ListBox();
            lstMyPrograms = new ListBox();
            SuspendLayout();
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Location = new Point(417, 23);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(38, 15);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "label1";
            lblPageTitle.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(280, 346);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 1;
            label2.Text = "Access Code";
            label2.Click += label2_Click;
            // 
            // lblMyPrograms
            // 
            lblMyPrograms.AutoSize = true;
            lblMyPrograms.Location = new Point(16, 411);
            lblMyPrograms.Name = "lblMyPrograms";
            lblMyPrograms.Size = new Size(38, 15);
            lblMyPrograms.TabIndex = 2;
            lblMyPrograms.Text = "label3";
            // 
            // lblProgramDetail
            // 
            lblProgramDetail.AutoSize = true;
            lblProgramDetail.Location = new Point(229, 81);
            lblProgramDetail.Name = "lblProgramDetail";
            lblProgramDetail.Size = new Size(86, 15);
            lblProgramDetail.TabIndex = 3;
            lblProgramDetail.Text = "Program Detail";
            // 
            // txtAccessCode
            // 
            txtAccessCode.Location = new Point(257, 374);
            txtAccessCode.Name = "txtAccessCode";
            txtAccessCode.Size = new Size(126, 23);
            txtAccessCode.TabIndex = 6;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Location = new Point(16, 53);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(38, 15);
            lblAvailable.TabIndex = 7;
            lblAvailable.Text = "label1";
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(417, 374);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(75, 23);
            btnEnroll.TabIndex = 8;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = true;
            // 
            // btnBackHome
            // 
            btnBackHome.Location = new Point(406, 616);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(107, 23);
            btnBackHome.TabIndex = 9;
            btnBackHome.Text = "back to home";
            btnBackHome.UseVisualStyleBackColor = true;
            // 
            // lstAllPrograms
            // 
            lstAllPrograms.FormattingEnabled = true;
            lstAllPrograms.ItemHeight = 15;
            lstAllPrograms.Location = new Point(16, 76);
            lstAllPrograms.Name = "lstAllPrograms";
            lstAllPrograms.Size = new Size(207, 319);
            lstAllPrograms.TabIndex = 10;
            // 
            // lstMyPrograms
            // 
            lstMyPrograms.FormattingEnabled = true;
            lstMyPrograms.ItemHeight = 15;
            lstMyPrograms.Location = new Point(16, 434);
            lstMyPrograms.Name = "lstMyPrograms";
            lstMyPrograms.Size = new Size(939, 154);
            lstMyPrograms.TabIndex = 11;
            // 
            // EnrolmentPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lstMyPrograms);
            Controls.Add(lstAllPrograms);
            Controls.Add(btnBackHome);
            Controls.Add(btnEnroll);
            Controls.Add(lblAvailable);
            Controls.Add(txtAccessCode);
            Controls.Add(lblProgramDetail);
            Controls.Add(lblMyPrograms);
            Controls.Add(label2);
            Controls.Add(lblPageTitle);
            Name = "EnrolmentPage";
            Size = new Size(997, 700);
            Load += EnrolmentPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPageTitle;
        private Label label2;
        private Label lblMyPrograms;
        private Label lblProgramDetail;
        private TextBox txtAccessCode;
        private Label lblAvailable;
        private Button btnEnroll;
        private Button btnBackHome;
        private ListBox lstAllPrograms;
        private ListBox lstMyPrograms;
    }
}

namespace KomodoHub.Pages
{
    partial class PublicActivites
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
            btnBackToLibrary = new Button();
            lstActivities = new ListBox();
            btnBackHome = new Button();
            button1 = new Button();
            button4 = new Button();
            OverViewButton = new Button();
            Title = new Label();
            picActivities = new PictureBox();
            btnLoad = new Button();
            label1 = new Label();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            label2 = new Label();
            txtContent = new RichTextBox();
            label3 = new Label();
            txtSearch = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)picActivities).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBackToLibrary
            // 
            btnBackToLibrary.Location = new Point(952, 6);
            btnBackToLibrary.Name = "btnBackToLibrary";
            btnBackToLibrary.Size = new Size(132, 23);
            btnBackToLibrary.TabIndex = 0;
            btnBackToLibrary.Text = "Back To Library";
            btnBackToLibrary.UseVisualStyleBackColor = true;
            btnBackToLibrary.Click += btnBackToLibrary_Click;
            // 
            // lstActivities
            // 
            lstActivities.FormattingEnabled = true;
            lstActivities.ItemHeight = 15;
            lstActivities.Location = new Point(9, 136);
            lstActivities.Name = "lstActivities";
            lstActivities.Size = new Size(229, 499);
            lstActivities.TabIndex = 1;
            // 
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.FromArgb(60, 60, 60);
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(588, 18);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(187, 40);
            btnBackHome.TabIndex = 15;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = true;
            btnBackHome.Click += btnBackHome_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(60, 60, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(395, 18);
            button1.Name = "button1";
            button1.Size = new Size(187, 40);
            button1.TabIndex = 14;
            button1.Text = "Public Activities";
            button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(60, 60, 60);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(202, 18);
            button4.Name = "button4";
            button4.Size = new Size(187, 40);
            button4.TabIndex = 13;
            button4.Text = "Student Findings";
            button4.UseVisualStyleBackColor = false;
            // 
            // OverViewButton
            // 
            OverViewButton.BackColor = Color.FromArgb(60, 60, 60);
            OverViewButton.FlatAppearance.BorderSize = 0;
            OverViewButton.FlatStyle = FlatStyle.Flat;
            OverViewButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OverViewButton.ForeColor = Color.White;
            OverViewButton.Location = new Point(9, 18);
            OverViewButton.Name = "OverViewButton";
            OverViewButton.Size = new Size(187, 40);
            OverViewButton.TabIndex = 12;
            OverViewButton.Text = "Public Library";
            OverViewButton.UseVisualStyleBackColor = false;
            OverViewButton.Click += OverViewButton_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.BackColor = Color.Transparent;
            Title.ForeColor = SystemColors.ButtonFace;
            Title.Location = new Point(244, 76);
            Title.Name = "Title";
            Title.Size = new Size(30, 15);
            Title.TabIndex = 17;
            Title.Text = "Title";
            Title.Click += label1_Click;
            // 
            // picActivities
            // 
            picActivities.BorderStyle = BorderStyle.FixedSingle;
            picActivities.Location = new Point(908, 154);
            picActivities.Name = "picActivities";
            picActivities.Size = new Size(160, 118);
            picActivities.SizeMode = PictureBoxSizeMode.Zoom;
            picActivities.TabIndex = 18;
            picActivities.TabStop = false;
            picActivities.Click += picActivities_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(60, 60, 60);
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(897, 18);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(187, 40);
            btnLoad.TabIndex = 20;
            btnLoad.Text = "Load Activities";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(787, 76);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 21;
            label1.Text = "Submitted By";
            label1.Click += label1_Click_1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(787, 94);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(281, 23);
            txtAuthor.TabIndex = 22;
            txtAuthor.TextChanged += textBox1_TextChanged;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(244, 94);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(537, 23);
            txtTitle.TabIndex = 23;
            txtTitle.TextChanged += textBox1_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(244, 136);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 24;
            label2.Text = "Description";
            label2.Click += label2_Click;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(244, 154);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(647, 483);
            txtContent.TabIndex = 25;
            txtContent.Text = "";
            txtContent.TextChanged += txtContent_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(908, 136);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 26;
            label3.Text = "Image";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(9, 94);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search activities";
            txtSearch.Size = new Size(229, 23);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 60, 60);
            panel1.Controls.Add(btnBackToLibrary);
            panel1.Location = new Point(0, 656);
            panel1.Name = "panel1";
            panel1.Size = new Size(1097, 39);
            panel1.TabIndex = 28;
            // 
            // PublicActivites
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 40, 25);
            Controls.Add(panel1);
            Controls.Add(txtSearch);
            Controls.Add(label3);
            Controls.Add(txtContent);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Controls.Add(label1);
            Controls.Add(btnLoad);
            Controls.Add(picActivities);
            Controls.Add(Title);
            Controls.Add(btnBackHome);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(OverViewButton);
            Controls.Add(lstActivities);
            Name = "PublicActivites";
            Size = new Size(1097, 695);
            Load += PublicActivites_Load;
            ((System.ComponentModel.ISupportInitialize)picActivities).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBackToLibrary;
        private ListBox lstActivities;
        private Button btnBackHome;
        private Button button1;
        private Button button4;
        private Button OverViewButton;
        private Label Title;
        private PictureBox picActivities;
        private Button btnLoad;
        private Label label1;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private Label label2;
        private RichTextBox txtContent;
        private Label label3;
        private TextBox txtSearch;
        private Panel panel1;
    }
}

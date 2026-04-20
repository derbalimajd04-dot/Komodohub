namespace KomodoHub.Pages
{
    partial class Library
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Library));
            lstItems = new ListBox();
            picItem = new PictureBox();
            txtContent = new RichTextBox();
            panel1 = new Panel();
            OverViewButton = new Button();
            button4 = new Button();
            button1 = new Button();
            label1 = new Label();
            btnBackHome = new Button();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            txtFeedback = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // lstItems
            // 
            lstItems.BackColor = Color.Gray;
            lstItems.BorderStyle = BorderStyle.FixedSingle;
            lstItems.ForeColor = Color.White;
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 15;
            lstItems.Location = new Point(24, 124);
            lstItems.Margin = new Padding(3, 2, 3, 2);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(251, 542);
            lstItems.TabIndex = 2;
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // picItem
            // 
            picItem.BackgroundImage = (Image)resources.GetObject("picItem.BackgroundImage");
            picItem.BackgroundImageLayout = ImageLayout.Stretch;
            picItem.Location = new Point(942, 77);
            picItem.Margin = new Padding(3, 2, 3, 2);
            picItem.Name = "picItem";
            picItem.Size = new Size(141, 122);
            picItem.TabIndex = 3;
            picItem.TabStop = false;
            // 
            // txtContent
            // 
            txtContent.BackColor = Color.Gray;
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.ForeColor = Color.White;
            txtContent.Location = new Point(281, 124);
            txtContent.Margin = new Padding(3, 2, 3, 2);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(655, 418);
            txtContent.TabIndex = 4;
            txtContent.Text = resources.GetString("txtContent.Text");
            txtContent.TextChanged += txtContent_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Location = new Point(-25, 690);
            panel1.Name = "panel1";
            panel1.Size = new Size(1188, 94);
            panel1.TabIndex = 6;
            // 
            // OverViewButton
            // 
            OverViewButton.BackColor = Color.FromArgb(60, 60, 60);
            OverViewButton.FlatAppearance.BorderSize = 0;
            OverViewButton.FlatStyle = FlatStyle.Flat;
            OverViewButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OverViewButton.ForeColor = Color.White;
            OverViewButton.Location = new Point(24, 11);
            OverViewButton.Name = "OverViewButton";
            OverViewButton.Size = new Size(187, 40);
            OverViewButton.TabIndex = 7;
            OverViewButton.Text = "Public Library";
            OverViewButton.UseVisualStyleBackColor = false;
            OverViewButton.Click += OverViewButton_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(60, 60, 60);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(217, 11);
            button4.Name = "button4";
            button4.Size = new Size(187, 40);
            button4.TabIndex = 8;
            button4.Text = "My Submissions";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(60, 60, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(410, 11);
            button1.Name = "button1";
            button1.Size = new Size(187, 40);
            button1.TabIndex = 9;
            button1.Text = "Public Activities";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(963, 47);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 10;
            label1.Text = "Image Of Animal";
            // 
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.FromArgb(60, 60, 60);
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(603, 11);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(187, 40);
            btnBackHome.TabIndex = 11;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = true;
            btnBackHome.Click += button2_Click;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(24, 77);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(251, 42);
            txtAuthor.TabIndex = 12;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(281, 77);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(655, 42);
            txtTitle.TabIndex = 13;
            // 
            // txtFeedback
            // 
            txtFeedback.Location = new Point(281, 547);
            txtFeedback.Multiline = true;
            txtFeedback.Name = "txtFeedback";
            txtFeedback.Size = new Size(655, 119);
            txtFeedback.TabIndex = 14;
            // 
            // Library
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(65, 65, 65);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(txtFeedback);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Controls.Add(btnBackHome);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(OverViewButton);
            Controls.Add(panel1);
            Controls.Add(txtContent);
            Controls.Add(picItem);
            Controls.Add(lstItems);
            Name = "Library";
            Size = new Size(1097, 695);
            Load += Library_Load;
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstItems;
        private PictureBox picItem;
        private RichTextBox txtContent;
        private Panel panel1;
        private Button OverViewButton;
        private Button button4;
        private Button button1;
        private Label label1;
        private Button btnBackHome;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtFeedback;
    }
}

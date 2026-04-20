namespace KomodoHub.Pages
{
    partial class publicLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(publicLibrary));
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            label1 = new Label();
            txtContent = new RichTextBox();
            picItem = new PictureBox();
            lstItems = new ListBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(265, 14);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(655, 42);
            txtTitle.TabIndex = 20;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(8, 14);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(251, 42);
            txtAuthor.TabIndex = 19;
            txtAuthor.TextChanged += txtAuthor_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(947, -16);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 18;
            label1.Text = "Image Of Animal";
            // 
            // txtContent
            // 
            txtContent.BackColor = Color.Gray;
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.ForeColor = Color.White;
            txtContent.Location = new Point(265, 61);
            txtContent.Margin = new Padding(3, 2, 3, 2);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(655, 542);
            txtContent.TabIndex = 17;
            txtContent.Text = resources.GetString("txtContent.Text");
            txtContent.TextChanged += txtContent_TextChanged;
            // 
            // picItem
            // 
            picItem.BackgroundImageLayout = ImageLayout.Stretch;
            picItem.Location = new Point(926, 14);
            picItem.Margin = new Padding(3, 2, 3, 2);
            picItem.Name = "picItem";
            picItem.Size = new Size(141, 122);
            picItem.TabIndex = 16;
            picItem.TabStop = false;
            // 
            // lstItems
            // 
            lstItems.BackColor = Color.Gray;
            lstItems.BorderStyle = BorderStyle.FixedSingle;
            lstItems.ForeColor = Color.White;
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 15;
            lstItems.Location = new Point(8, 61);
            lstItems.Margin = new Padding(3, 2, 3, 2);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(251, 542);
            lstItems.TabIndex = 15;
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(926, 152);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 22;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // publicLibrary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1076, 619);
            Controls.Add(button1);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(picItem);
            Controls.Add(lstItems);
            Name = "publicLibrary";
            Text = "publicLibrary";
            Load += publicLibrary_Load_1;
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private Label label1;
        private RichTextBox txtContent;
        private PictureBox picItem;
        private ListBox lstItems;
        private Button button1;
    }
}
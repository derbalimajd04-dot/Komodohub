namespace KomodoHub
{
    partial class Profile
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
            myschool = new Label();
            mynameLabel = new Label();
            checkedListBox1 = new CheckedListBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            submissionsBoxx = new ListBox();
            button1 = new Button();
            messageBoxRecieved = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // myschool
            // 
            myschool.AutoSize = true;
            myschool.Location = new Point(187, 51);
            myschool.Name = "myschool";
            myschool.Size = new Size(23, 15);
            myschool.TabIndex = 17;
            myschool.Text = "n.a";
            // 
            // mynameLabel
            // 
            mynameLabel.AutoSize = true;
            mynameLabel.Location = new Point(183, 27);
            mynameLabel.Name = "mynameLabel";
            mynameLabel.Size = new Size(23, 15);
            mynameLabel.TabIndex = 16;
            mynameLabel.Text = "n.a";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Red", "Purple", "Blue" });
            checkedListBox1.Location = new Point(589, 12);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(187, 130);
            checkedListBox1.TabIndex = 15;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 51);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 14;
            label3.Text = "School";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 27);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 13;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 10;
            label1.Text = "Profile Picture";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.jew;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(9, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 89);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // submissionsBoxx
            // 
            submissionsBoxx.FormattingEnabled = true;
            submissionsBoxx.ItemHeight = 15;
            submissionsBoxx.Location = new Point(8, 183);
            submissionsBoxx.Name = "submissionsBoxx";
            submissionsBoxx.Size = new Size(262, 94);
            submissionsBoxx.TabIndex = 18;
            submissionsBoxx.SelectedIndexChanged += submissionsBoxx_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(9, 154);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 19;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // messageBoxRecieved
            // 
            messageBoxRecieved.Location = new Point(8, 283);
            messageBoxRecieved.Name = "messageBoxRecieved";
            messageBoxRecieved.Size = new Size(262, 90);
            messageBoxRecieved.TabIndex = 20;
            messageBoxRecieved.Text = "";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 390);
            Controls.Add(messageBoxRecieved);
            Controls.Add(button1);
            Controls.Add(submissionsBoxx);
            Controls.Add(myschool);
            Controls.Add(mynameLabel);
            Controls.Add(checkedListBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Profile";
            Text = "Profile";
            Load += Profile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label myschool;
        private Label mynameLabel;
        private CheckedListBox checkedListBox1;
        private Label label3;
        private Label label2;
        private ListBox submissions;
        private Label label1;
        private PictureBox pictureBox1;
        private ListBox submissionsBoxx;
        private Button button1;
        private RichTextBox messageBoxRecieved;
    }
}
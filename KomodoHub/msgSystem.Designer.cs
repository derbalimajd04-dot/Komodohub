namespace KomodoHub
{
    partial class msgSystem
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
            button1 = new Button();
            UserList = new ListBox();
            MessageSendBox = new RichTextBox();
            messageBoxRecieved = new RichTextBox();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(25, 234);
            button1.Name = "button1";
            button1.Size = new Size(114, 36);
            button1.TabIndex = 7;
            button1.Text = "send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserList
            // 
            UserList.FormattingEnabled = true;
            UserList.ItemHeight = 15;
            UserList.Location = new Point(369, 32);
            UserList.Name = "UserList";
            UserList.Size = new Size(129, 199);
            UserList.TabIndex = 6;
            // 
            // MessageSendBox
            // 
            MessageSendBox.Location = new Point(25, 203);
            MessageSendBox.Name = "MessageSendBox";
            MessageSendBox.Size = new Size(338, 25);
            MessageSendBox.TabIndex = 5;
            MessageSendBox.Text = "Hello";
            // 
            // messageBoxRecieved
            // 
            messageBoxRecieved.Location = new Point(25, 30);
            messageBoxRecieved.Name = "messageBoxRecieved";
            messageBoxRecieved.Size = new Size(338, 167);
            messageBoxRecieved.TabIndex = 4;
            messageBoxRecieved.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(369, 237);
            button2.Name = "button2";
            button2.Size = new Size(129, 36);
            button2.TabIndex = 8;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 9;
            label1.Text = "Your Messages";
            // 
            // msgSystem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(525, 290);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(UserList);
            Controls.Add(MessageSendBox);
            Controls.Add(messageBoxRecieved);
            MaximizeBox = false;
            Name = "msgSystem";
            Text = "Messaging System";
            Load += msgSystem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox UserList;
        private RichTextBox MessageSendBox;
        private RichTextBox messageBoxRecieved;
        private Button button2;
        private Label label1;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    partial class SpeciesPage
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code


        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnBackHome = new Button();
            cardsPanel = new FlowLayoutPanel();
            detailPanel = new Panel();
            txtDetail = new RichTextBox();
            lblDetailStatus = new Label();
            lblDetailTitle = new Label();
            detailPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(535, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Indonesian Endangered Endemic Species";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(3, 58);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "search bar to filter by name or region";
            txtSearch.Size = new Size(282, 29);
            txtSearch.TabIndex = 1;
            // 
            // btnBackHome
            // 
            btnBackHome.BackColor = Color.SeaGreen;
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.Location = new Point(896, 14);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new Size(187, 40);
            btnBackHome.TabIndex = 16;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = false;
            // 
            // cardsPanel
            // 
            cardsPanel.AutoScroll = true;
            cardsPanel.Location = new Point(3, 93);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Size = new Size(532, 578);
            cardsPanel.TabIndex = 17;
            // 
            // detailPanel
            // 
            detailPanel.Controls.Add(txtDetail);
            detailPanel.Controls.Add(lblDetailStatus);
            detailPanel.Controls.Add(lblDetailTitle);
            detailPanel.ForeColor = Color.White;
            detailPanel.Location = new Point(550, 93);
            detailPanel.Name = "detailPanel";
            detailPanel.Size = new Size(533, 578);
            detailPanel.TabIndex = 18;
            // 
            // txtDetail
            // 
            txtDetail.BackColor = Color.FromArgb(20, 40, 25);
            txtDetail.BorderStyle = BorderStyle.None;
            txtDetail.Location = new Point(13, 80);
            txtDetail.Name = "txtDetail";
            txtDetail.ReadOnly = true;
            txtDetail.Size = new Size(510, 270);
            txtDetail.TabIndex = 2;
            txtDetail.Text = "";
            txtDetail.TextChanged += txtDetail_TextChanged;
            // 
            // lblDetailStatus
            // 
            lblDetailStatus.AutoSize = true;
            lblDetailStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetailStatus.ForeColor = Color.White;
            lblDetailStatus.Location = new Point(13, 52);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Size = new Size(0, 25);
            lblDetailStatus.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(13, 9);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(0, 25);
            lblDetailTitle.TabIndex = 0;
            // 
            // SpeciesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 40, 25);
            Controls.Add(detailPanel);
            Controls.Add(cardsPanel);
            Controls.Add(btnBackHome);
            Controls.Add(txtSearch);
            Controls.Add(lblTitle);
            ForeColor = Color.FromArgb(20, 40, 25);
            Name = "SpeciesPage";
            Size = new Size(1097, 695);
            detailPanel.ResumeLayout(false);
            detailPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnBackHome;
        private FlowLayoutPanel cardsPanel;
        private Panel detailPanel;
        private RichTextBox txtDetail;
        private Label lblDetailStatus;
        private Label lblDetailTitle;
    }
}

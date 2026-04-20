namespace KomodoHub.Pages
{
    partial class SightingsPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblRecent = new Label();
            lstSightings = new ListBox();
            txtSightingDetail = new RichTextBox();
            btnBack = new Button();
            panelForm = new Panel();
            lblFormTitle = new Label();
            lblSpecies = new Label();
            cmbSpecies = new ComboBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblUpload = new Label();
            btnChooseFile = new Button();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSubmit = new Button();
            picturesighting = new PictureBox();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturesighting).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sighting Reports";
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.BackColor = Color.Transparent;
            lblRecent.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblRecent.ForeColor = Color.FromArgb(100, 255, 100);
            lblRecent.Location = new Point(20, 55);
            lblRecent.Name = "lblRecent";
            lblRecent.Size = new Size(126, 20);
            lblRecent.TabIndex = 1;
            lblRecent.Text = "Recent Sightings";
            // 
            // lstSightings
            // 
            lstSightings.BackColor = Color.FromArgb(35, 55, 40);
            lstSightings.BorderStyle = BorderStyle.None;
            lstSightings.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstSightings.ForeColor = Color.White;
            lstSightings.FormattingEnabled = true;
            lstSightings.ItemHeight = 17;
            lstSightings.Location = new Point(20, 80);
            lstSightings.Name = "lstSightings";
            lstSightings.Size = new Size(350, 119);
            lstSightings.TabIndex = 2;
            // 
            // txtSightingDetail
            // 
            txtSightingDetail.BackColor = Color.FromArgb(35, 55, 40);
            txtSightingDetail.BorderStyle = BorderStyle.None;
            txtSightingDetail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSightingDetail.ForeColor = Color.White;
            txtSightingDetail.Location = new Point(20, 205);
            txtSightingDetail.Name = "txtSightingDetail";
            txtSightingDetail.ReadOnly = true;
            txtSightingDetail.Size = new Size(350, 253);
            txtSightingDetail.TabIndex = 3;
            txtSightingDetail.Text = "";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(60, 60, 60);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(900, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(170, 35);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back to Home";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.FromArgb(35, 55, 40);
            panelForm.Controls.Add(lblFormTitle);
            panelForm.Controls.Add(lblSpecies);
            panelForm.Controls.Add(cmbSpecies);
            panelForm.Controls.Add(lblLocation);
            panelForm.Controls.Add(txtLocation);
            panelForm.Controls.Add(lblDate);
            panelForm.Controls.Add(dtpDate);
            panelForm.Controls.Add(lblUpload);
            panelForm.Controls.Add(btnChooseFile);
            panelForm.Controls.Add(lblDescription);
            panelForm.Controls.Add(txtDescription);
            panelForm.Controls.Add(btnSubmit);
            panelForm.Location = new Point(411, 55);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(669, 625);
            panelForm.TabIndex = 5;
            panelForm.Paint += panelForm_Paint;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(20, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(268, 25);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Submit New Sighting Report";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.BackColor = Color.Transparent;
            lblSpecies.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSpecies.ForeColor = Color.White;
            lblSpecies.Location = new Point(20, 60);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(59, 19);
            lblSpecies.TabIndex = 1;
            lblSpecies.Text = "Species";
            // 
            // cmbSpecies
            // 
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecies.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSpecies.FormattingEnabled = true;
            cmbSpecies.Items.AddRange(new object[] { "Sumatran Tiger", "Sumatran Elephant", "Javan Rhinoceros", "Banteng", "Javan Gibbon", "Orangutan", "Bekantan", "Komodo Dragon", "Bali Myna", "Maleo", "Babirusa", "Anoa", "Javan Eagle", "Tarsius", "Celebes Crested Macaque" });
            cmbSpecies.Location = new Point(20, 82);
            cmbSpecies.Name = "cmbSpecies";
            cmbSpecies.Size = new Size(300, 25);
            cmbSpecies.TabIndex = 2;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.BackColor = Color.Transparent;
            lblLocation.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(340, 60);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(66, 19);
            lblLocation.TabIndex = 3;
            lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtLocation.Location = new Point(340, 82);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(300, 25);
            txtLocation.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(20, 120);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(40, 19);
            lblDate.TabIndex = 5;
            lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.Location = new Point(20, 142);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 25);
            dtpDate.TabIndex = 6;
            // 
            // lblUpload
            // 
            lblUpload.AutoSize = true;
            lblUpload.BackColor = Color.Transparent;
            lblUpload.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblUpload.ForeColor = Color.White;
            lblUpload.Location = new Point(340, 120);
            lblUpload.Name = "lblUpload";
            lblUpload.Size = new Size(102, 19);
            lblUpload.TabIndex = 7;
            lblUpload.Text = "Upload Photo";
            // 
            // btnChooseFile
            // 
            btnChooseFile.BackColor = Color.FromArgb(60, 80, 60);
            btnChooseFile.Cursor = Cursors.Hand;
            btnChooseFile.FlatAppearance.BorderColor = Color.FromArgb(100, 150, 100);
            btnChooseFile.FlatStyle = FlatStyle.Flat;
            btnChooseFile.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnChooseFile.ForeColor = Color.White;
            btnChooseFile.Location = new Point(340, 142);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(300, 30);
            btnChooseFile.TabIndex = 8;
            btnChooseFile.Text = "Choose file...";
            btnChooseFile.UseVisualStyleBackColor = false;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(20, 185);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 19);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(20, 207);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(620, 328);
            txtDescription.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(46, 139, 87);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(20, 558);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(300, 45);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Submit Sighting Report";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click_1;
            // 
            // picturesighting
            // 
            picturesighting.Location = new Point(20, 464);
            picturesighting.Name = "picturesighting";
            picturesighting.Size = new Size(350, 194);
            picturesighting.SizeMode = PictureBoxSizeMode.Zoom;
            picturesighting.TabIndex = 6;
            picturesighting.TabStop = false;
            picturesighting.Click += picturesighting_Click;
            // 
            // SightingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 40, 25);
            Controls.Add(picturesighting);
            Controls.Add(lblTitle);
            Controls.Add(lblRecent);
            Controls.Add(lstSightings);
            Controls.Add(txtSightingDetail);
            Controls.Add(btnBack);
            Controls.Add(panelForm);
            Name = "SightingsPage";
            Size = new Size(1097, 695);
            Load += SightingsPage_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturesighting).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblRecent;
        private ListBox lstSightings;
        private RichTextBox txtSightingDetail;
        private Button btnBack;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblSpecies;
        private ComboBox cmbSpecies;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblUpload;
        private Button btnChooseFile;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnSubmit;
        private PictureBox picturesighting;
    }
}

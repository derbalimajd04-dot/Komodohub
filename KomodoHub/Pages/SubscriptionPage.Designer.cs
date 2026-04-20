namespace KomodoHub.Pages
{
    partial class SubscriptionPage
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
                components.Dispose();
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
            panelInfo = new Panel();
            lblInfoHeader = new Label();
            lblCurrentPlan = new Label();
            lblCurrentStatus = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            btnRefresh = new Button();
            panelUpdate = new Panel();
            lblUpdateHeader = new Label();
            lblPlanSelect = new Label();
            cmbPlan = new ComboBox();
            lblStatusSelect = new Label();
            cmbStatus = new ComboBox();
            lblEndDateSelect = new Label();
            dtpEndDate = new DateTimePicker();
            btnUpdate = new Button();
            panelBottom = new Panel();
            btnBackHome = new Button();
            panelInfo.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            //
            // lblPageTitle
            //
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblPageTitle.ForeColor = System.Drawing.Color.White;
            lblPageTitle.Location = new System.Drawing.Point(22, 18);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new System.Drawing.Size(320, 32);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Subscription Management";
            //
            // panelInfo
            //
            panelInfo.BackColor = System.Drawing.Color.FromArgb(35, 55, 40);
            panelInfo.Controls.Add(btnRefresh);
            panelInfo.Controls.Add(lblEndDate);
            panelInfo.Controls.Add(lblStartDate);
            panelInfo.Controls.Add(lblCurrentStatus);
            panelInfo.Controls.Add(lblCurrentPlan);
            panelInfo.Controls.Add(lblInfoHeader);
            panelInfo.Location = new System.Drawing.Point(22, 62);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new System.Drawing.Size(500, 566);
            panelInfo.TabIndex = 1;
            //
            // lblInfoHeader
            //
            lblInfoHeader.AutoSize = true;
            lblInfoHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblInfoHeader.ForeColor = System.Drawing.Color.White;
            lblInfoHeader.Location = new System.Drawing.Point(110, 40);
            lblInfoHeader.Name = "lblInfoHeader";
            lblInfoHeader.Size = new System.Drawing.Size(280, 30);
            lblInfoHeader.TabIndex = 0;
            lblInfoHeader.Text = "Current Subscription Info";
            //
            // lblCurrentPlan
            //
            lblCurrentPlan.AutoSize = true;
            lblCurrentPlan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCurrentPlan.ForeColor = System.Drawing.Color.White;
            lblCurrentPlan.Location = new System.Drawing.Point(88, 110);
            lblCurrentPlan.Name = "lblCurrentPlan";
            lblCurrentPlan.Size = new System.Drawing.Size(60, 21);
            lblCurrentPlan.TabIndex = 1;
            lblCurrentPlan.Text = "Plan: --";
            //
            // lblCurrentStatus
            //
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCurrentStatus.ForeColor = System.Drawing.Color.White;
            lblCurrentStatus.Location = new System.Drawing.Point(88, 160);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new System.Drawing.Size(74, 21);
            lblCurrentStatus.TabIndex = 2;
            lblCurrentStatus.Text = "Status: --";
            //
            // lblStartDate
            //
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStartDate.ForeColor = System.Drawing.Color.White;
            lblStartDate.Location = new System.Drawing.Point(88, 210);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(104, 21);
            lblStartDate.TabIndex = 3;
            lblStartDate.Text = "Start Date: --";
            //
            // lblEndDate
            //
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblEndDate.ForeColor = System.Drawing.Color.White;
            lblEndDate.Location = new System.Drawing.Point(88, 260);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(99, 21);
            lblEndDate.TabIndex = 4;
            lblEndDate.Text = "End Date: --";
            //
            // btnRefresh
            //
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(117, 340);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(265, 45);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            //
            // panelUpdate
            //
            panelUpdate.BackColor = System.Drawing.Color.FromArgb(35, 55, 40);
            panelUpdate.Controls.Add(btnUpdate);
            panelUpdate.Controls.Add(dtpEndDate);
            panelUpdate.Controls.Add(lblEndDateSelect);
            panelUpdate.Controls.Add(cmbStatus);
            panelUpdate.Controls.Add(lblStatusSelect);
            panelUpdate.Controls.Add(cmbPlan);
            panelUpdate.Controls.Add(lblPlanSelect);
            panelUpdate.Controls.Add(lblUpdateHeader);
            panelUpdate.Location = new System.Drawing.Point(550, 62);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new System.Drawing.Size(523, 566);
            panelUpdate.TabIndex = 2;
            //
            // lblUpdateHeader
            //
            lblUpdateHeader.AutoSize = true;
            lblUpdateHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblUpdateHeader.ForeColor = System.Drawing.Color.White;
            lblUpdateHeader.Location = new System.Drawing.Point(145, 40);
            lblUpdateHeader.Name = "lblUpdateHeader";
            lblUpdateHeader.Size = new System.Drawing.Size(233, 30);
            lblUpdateHeader.TabIndex = 0;
            lblUpdateHeader.Text = "Update Subscription";
            //
            // lblPlanSelect
            //
            lblPlanSelect.AutoSize = true;
            lblPlanSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblPlanSelect.ForeColor = System.Drawing.Color.White;
            lblPlanSelect.Location = new System.Drawing.Point(129, 110);
            lblPlanSelect.Name = "lblPlanSelect";
            lblPlanSelect.Size = new System.Drawing.Size(32, 15);
            lblPlanSelect.TabIndex = 1;
            lblPlanSelect.Text = "Plan";
            //
            // cmbPlan
            //
            cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPlan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbPlan.Items.AddRange(new object[] { "BASIC", "PREMIUM" });
            cmbPlan.Location = new System.Drawing.Point(129, 130);
            cmbPlan.Name = "cmbPlan";
            cmbPlan.Size = new System.Drawing.Size(265, 25);
            cmbPlan.TabIndex = 2;
            //
            // lblStatusSelect
            //
            lblStatusSelect.AutoSize = true;
            lblStatusSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblStatusSelect.ForeColor = System.Drawing.Color.White;
            lblStatusSelect.Location = new System.Drawing.Point(129, 175);
            lblStatusSelect.Name = "lblStatusSelect";
            lblStatusSelect.Size = new System.Drawing.Size(42, 15);
            lblStatusSelect.TabIndex = 3;
            lblStatusSelect.Text = "Status";
            //
            // cmbStatus
            //
            cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbStatus.Items.AddRange(new object[] { "ACTIVE", "EXPIRED", "SUSPENDED" });
            cmbStatus.Location = new System.Drawing.Point(129, 195);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new System.Drawing.Size(265, 25);
            cmbStatus.TabIndex = 4;
            //
            // lblEndDateSelect
            //
            lblEndDateSelect.AutoSize = true;
            lblEndDateSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblEndDateSelect.ForeColor = System.Drawing.Color.White;
            lblEndDateSelect.Location = new System.Drawing.Point(129, 240);
            lblEndDateSelect.Name = "lblEndDateSelect";
            lblEndDateSelect.Size = new System.Drawing.Size(78, 15);
            lblEndDateSelect.TabIndex = 5;
            lblEndDateSelect.Text = "New End Date";
            //
            // dtpEndDate
            //
            dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpEndDate.Location = new System.Drawing.Point(129, 260);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new System.Drawing.Size(265, 25);
            dtpEndDate.TabIndex = 6;
            //
            // btnUpdate
            //
            btnUpdate.BackColor = System.Drawing.Color.Teal;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.Location = new System.Drawing.Point(129, 340);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(265, 45);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update Subscription";
            btnUpdate.UseVisualStyleBackColor = false;
            //
            // panelBottom
            //
            panelBottom.BackColor = System.Drawing.Color.FromArgb(35, 55, 40);
            panelBottom.Controls.Add(btnBackHome);
            panelBottom.Location = new System.Drawing.Point(0, 642);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(1097, 53);
            panelBottom.TabIndex = 3;
            //
            // btnBackHome
            //
            btnBackHome.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackHome.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnBackHome.ForeColor = System.Drawing.Color.White;
            btnBackHome.Location = new System.Drawing.Point(886, 6);
            btnBackHome.Name = "btnBackHome";
            btnBackHome.Size = new System.Drawing.Size(187, 40);
            btnBackHome.TabIndex = 0;
            btnBackHome.Text = "Back to Home";
            btnBackHome.UseVisualStyleBackColor = false;
            //
            // SubscriptionPage
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 40, 25);
            Controls.Add(panelBottom);
            Controls.Add(panelUpdate);
            Controls.Add(panelInfo);
            Controls.Add(lblPageTitle);
            Name = "SubscriptionPage";
            Size = new System.Drawing.Size(1097, 695);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblInfoHeader;
        private System.Windows.Forms.Label lblCurrentPlan;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Label lblUpdateHeader;
        private System.Windows.Forms.Label lblPlanSelect;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label lblStatusSelect;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblEndDateSelect;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnBackHome;
    }
}

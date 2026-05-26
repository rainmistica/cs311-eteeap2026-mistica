namespace cs311_eteeap2026_mistica
{
    partial class frmUpdateEquipment
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.Branch = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYearModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssetNumber = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.rbWorking = new System.Windows.Forms.RadioButton();
            this.rbOnRepair = new System.Windows.Forms.RadioButton();
            this.rbRetired = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectedStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(45, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "Allied Medical Services",
            "Hospitality Management",
            "Arts and Sciences",
            "Business Administration",
            "Computer Science",
            "Education",
            "Nursing",
            "Criminal Justice",
            "Accountancy",
            "Information Technology"});
            this.cmbDepartment.Location = new System.Drawing.Point(131, 297);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(216, 21);
            this.cmbDepartment.TabIndex = 30;
            // 
            // Branch
            // 
            this.Branch.AutoSize = true;
            this.Branch.Location = new System.Drawing.Point(26, 279);
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(99, 13);
            this.Branch.TabIndex = 29;
            this.Branch.Text = "Department Branch";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(131, 169);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 101);
            this.txtDescription.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Description";
            // 
            // txtYearModel
            // 
            this.txtYearModel.Location = new System.Drawing.Point(131, 143);
            this.txtYearModel.MaxLength = 4;
            this.txtYearModel.Name = "txtYearModel";
            this.txtYearModel.Size = new System.Drawing.Size(216, 20);
            this.txtYearModel.TabIndex = 26;
            this.txtYearModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYearModel_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Year Model";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(131, 117);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(216, 20);
            this.txtManufacturer.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Manufacturer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Type";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(131, 40);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(216, 20);
            this.txtSerialNumber.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Serial Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Asset Number";
            // 
            // lblAssetNumber
            // 
            this.lblAssetNumber.AutoSize = true;
            this.lblAssetNumber.Location = new System.Drawing.Point(128, 17);
            this.lblAssetNumber.Name = "lblAssetNumber";
            this.lblAssetNumber.Size = new System.Drawing.Size(0, 13);
            this.lblAssetNumber.TabIndex = 32;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Monitor",
            "CPU",
            "Keyboard",
            "Mouse",
            "AVR",
            "MAC",
            "Printer",
            "Projector"});
            this.cmbType.Location = new System.Drawing.Point(131, 90);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(216, 21);
            this.cmbType.TabIndex = 22;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(134, 69);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 13);
            this.lblType.TabIndex = 33;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(131, 279);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(0, 13);
            this.lblDepartment.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(134, 329);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 36;
            // 
            // rbWorking
            // 
            this.rbWorking.AutoSize = true;
            this.rbWorking.Location = new System.Drawing.Point(131, 353);
            this.rbWorking.Name = "rbWorking";
            this.rbWorking.Size = new System.Drawing.Size(65, 17);
            this.rbWorking.TabIndex = 37;
            this.rbWorking.TabStop = true;
            this.rbWorking.Text = "Working";
            this.rbWorking.UseVisualStyleBackColor = true;
            this.rbWorking.CheckedChanged += new System.EventHandler(this.rbWorking_CheckedChanged);
            // 
            // rbOnRepair
            // 
            this.rbOnRepair.AutoSize = true;
            this.rbOnRepair.Location = new System.Drawing.Point(131, 376);
            this.rbOnRepair.Name = "rbOnRepair";
            this.rbOnRepair.Size = new System.Drawing.Size(68, 17);
            this.rbOnRepair.TabIndex = 38;
            this.rbOnRepair.TabStop = true;
            this.rbOnRepair.Text = "On-repair";
            this.rbOnRepair.UseVisualStyleBackColor = true;
            this.rbOnRepair.CheckedChanged += new System.EventHandler(this.rbOnRepair_CheckedChanged);
            // 
            // rbRetired
            // 
            this.rbRetired.AutoSize = true;
            this.rbRetired.Location = new System.Drawing.Point(131, 399);
            this.rbRetired.Name = "rbRetired";
            this.rbRetired.Size = new System.Drawing.Size(59, 17);
            this.rbRetired.TabIndex = 39;
            this.rbRetired.TabStop = true;
            this.rbRetired.Text = "Retired";
            this.rbRetired.UseVisualStyleBackColor = true;
            this.rbRetired.CheckedChanged += new System.EventHandler(this.rbRetired_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSelectedStatus
            // 
            this.lblSelectedStatus.AutoSize = true;
            this.lblSelectedStatus.Location = new System.Drawing.Point(218, 378);
            this.lblSelectedStatus.Name = "lblSelectedStatus";
            this.lblSelectedStatus.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedStatus.TabIndex = 41;
            this.lblSelectedStatus.Visible = false;
            // 
            // frmUpdateEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(372, 473);
            this.Controls.Add(this.lblSelectedStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbRetired);
            this.Controls.Add(this.rbOnRepair);
            this.Controls.Add(this.rbWorking);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblAssetNumber);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.Branch);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtYearModel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdateEquipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Equipment";
            this.Load += new System.EventHandler(this.frmUpdateEquipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label Branch;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYearModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssetNumber;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbRetired;
        private System.Windows.Forms.RadioButton rbOnRepair;
        private System.Windows.Forms.RadioButton rbWorking;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSelectedStatus;
    }
}
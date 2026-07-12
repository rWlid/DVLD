namespace DVLD
{
    partial class frmManagePeople
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.cmManagePerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
            this.cmManagePerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 121);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1204, 37);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Manage People";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvAllPeople
            // 
            this.dgvAllPeople.AllowUserToAddRows = false;
            this.dgvAllPeople.AllowUserToDeleteRows = false;
            this.dgvAllPeople.AllowUserToOrderColumns = true;
            this.dgvAllPeople.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPeople.ContextMenuStrip = this.cmManagePerson;
            this.dgvAllPeople.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllPeople.Location = new System.Drawing.Point(12, 213);
            this.dgvAllPeople.MultiSelect = false;
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllPeople.Size = new System.Drawing.Size(1180, 273);
            this.dgvAllPeople.TabIndex = 2;
            this.dgvAllPeople.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShowPersonDetails);
            this.dgvAllPeople.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllPeople_DataBindingComplete);
            // 
            // cmManagePerson
            // 
            this.cmManagePerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.toolStripSeparator1,
            this.tsmAddNewPerson,
            this.tsmEditPerson,
            this.tsmDelete,
            this.toolStripSeparator2,
            this.tsmSendEmail,
            this.tsmPhoneCall});
            this.cmManagePerson.Name = "contextMenuStrip1";
            this.cmManagePerson.Size = new System.Drawing.Size(163, 148);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(162, 22);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.ShowPersonDetails);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmAddNewPerson
            // 
            this.tsmAddNewPerson.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.tsmAddNewPerson.Name = "tsmAddNewPerson";
            this.tsmAddNewPerson.Size = new System.Drawing.Size(162, 22);
            this.tsmAddNewPerson.Text = "Add New Person";
            this.tsmAddNewPerson.Click += new System.EventHandler(this.AddNewPerson);
            // 
            // tsmEditPerson
            // 
            this.tsmEditPerson.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmEditPerson.Name = "tsmEditPerson";
            this.tsmEditPerson.Size = new System.Drawing.Size(162, 22);
            this.tsmEditPerson.Text = "Edit";
            this.tsmEditPerson.Click += new System.EventHandler(this.tsmEditPerson_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::DVLD.Properties.Resources.Delete_32;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(162, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmSendEmail
            // 
            this.tsmSendEmail.Image = global::DVLD.Properties.Resources.send_email_32;
            this.tsmSendEmail.Name = "tsmSendEmail";
            this.tsmSendEmail.Size = new System.Drawing.Size(162, 22);
            this.tsmSendEmail.Text = "Send Email";
            this.tsmSendEmail.Click += new System.EventHandler(this.FeatureStubError);
            // 
            // tsmPhoneCall
            // 
            this.tsmPhoneCall.Image = global::DVLD.Properties.Resources.call_32;
            this.tsmPhoneCall.Name = "tsmPhoneCall";
            this.tsmPhoneCall.Size = new System.Drawing.Size(162, 22);
            this.tsmPhoneCall.Text = "Phone Call";
            this.tsmPhoneCall.Click += new System.EventHandler(this.FeatureStubError);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cmbFilterBy.Location = new System.Drawing.Point(94, 186);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterBy.TabIndex = 3;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(221, 187);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(137, 20);
            this.txtFilterValue.TabIndex = 4;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(12, 185);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 5;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "# Records:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(101, 498);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(18, 20);
            this.lblNumberOfRecords.TabIndex = 9;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1077, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1141, 163);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(51, 44);
            this.btnAddNewPerson.TabIndex = 6;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.AddNewPerson);
            // 
            // pbHeader
            // 
            this.pbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbHeader.Image = global::DVLD.Properties.Resources.People_400;
            this.pbHeader.Location = new System.Drawing.Point(0, 0);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(1204, 121);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeader.TabIndex = 0;
            this.pbHeader.TabStop = false;
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 542);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvAllPeople);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pbHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).EndInit();
            this.cmManagePerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.DataGridView dgvAllPeople;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ContextMenuStrip cmManagePerson;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmPhoneCall;
    }
}
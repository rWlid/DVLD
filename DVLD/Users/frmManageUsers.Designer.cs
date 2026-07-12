namespace DVLD.Users
{
    partial class frmManageUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvAllUsers = new System.Windows.Forms.DataGridView();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.cmbActiveFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "# Records:";
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(12, 191);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 14;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(221, 193);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(137, 20);
            this.txtFilterValue.TabIndex = 13;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "User Name",
            "Person ID",
            "Full Name",
            "Is Active"});
            this.cmbFilterBy.Location = new System.Drawing.Point(94, 192);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterBy.TabIndex = 12;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // dgvAllUsers
            // 
            this.dgvAllUsers.AllowUserToAddRows = false;
            this.dgvAllUsers.AllowUserToDeleteRows = false;
            this.dgvAllUsers.AllowUserToOrderColumns = true;
            this.dgvAllUsers.AllowUserToResizeColumns = false;
            this.dgvAllUsers.AllowUserToResizeRows = false;
            this.dgvAllUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllUsers.Location = new System.Drawing.Point(12, 219);
            this.dgvAllUsers.MultiSelect = false;
            this.dgvAllUsers.Name = "dgvAllUsers";
            this.dgvAllUsers.ReadOnly = true;
            this.dgvAllUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllUsers.Size = new System.Drawing.Size(652, 273);
            this.dgvAllUsers.TabIndex = 11;
            this.dgvAllUsers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllUsers_DataBindingComplete);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 121);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(674, 37);
            this.lblFormTitle.TabIndex = 10;
            this.lblFormTitle.Text = "Manage Users";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(549, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 38);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbHeader
            // 
            this.pbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbHeader.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.pbHeader.Location = new System.Drawing.Point(0, 0);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(674, 121);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeader.TabIndex = 9;
            this.pbHeader.TabStop = false;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.Add_New_User_72;
            this.btnAddNewPerson.Location = new System.Drawing.Point(584, 139);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(80, 74);
            this.btnAddNewPerson.TabIndex = 15;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(100, 505);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(18, 20);
            this.lblNumberOfRecords.TabIndex = 18;
            this.lblNumberOfRecords.Text = "0";
            // 
            // cmbActiveFilter
            // 
            this.cmbActiveFilter.FormattingEnabled = true;
            this.cmbActiveFilter.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbActiveFilter.Location = new System.Drawing.Point(221, 193);
            this.cmbActiveFilter.Name = "cmbActiveFilter";
            this.cmbActiveFilter.Size = new System.Drawing.Size(66, 21);
            this.cmbActiveFilter.TabIndex = 19;
            this.cmbActiveFilter.Visible = false;
            this.cmbActiveFilter.SelectedIndexChanged += new System.EventHandler(this.cmbActiveFilter_SelectedIndexChanged);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 542);
            this.Controls.Add(this.cmbActiveFilter);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvAllUsers);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pbHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.DataGridView dgvAllUsers;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ComboBox cmbActiveFilter;
    }
}
namespace DVLD.Users
{
    partial class frmListUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvAllUsers = new System.Windows.Forms.DataGridView();
            this.cmManageUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.cmbActiveFilter = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).BeginInit();
            this.cmManageUser.SuspendLayout();
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
            this.dgvAllUsers.ContextMenuStrip = this.cmManageUser;
            this.dgvAllUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllUsers.Location = new System.Drawing.Point(12, 219);
            this.dgvAllUsers.MultiSelect = false;
            this.dgvAllUsers.Name = "dgvAllUsers";
            this.dgvAllUsers.ReadOnly = true;
            this.dgvAllUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllUsers.Size = new System.Drawing.Size(652, 273);
            this.dgvAllUsers.TabIndex = 11;
            this.dgvAllUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowUserDetails);
            this.dgvAllUsers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllUsers_DataBindingComplete);
            // 
            // cmManageUser
            // 
            this.cmManageUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowDetails,
            this.toolStripSeparator1,
            this.tsmiAddNewUser,
            this.tsmiEditUser,
            this.tsmiDeleteUser,
            this.tsmiChangePass,
            this.toolStripSeparator2,
            this.tsmiSendEmail,
            this.tsmiPhoneCall});
            this.cmManageUser.Name = "cmManageUser";
            this.cmManageUser.Size = new System.Drawing.Size(185, 282);
            // 
            // tsmiShowDetails
            // 
            this.tsmiShowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmiShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowDetails.Name = "tsmiShowDetails";
            this.tsmiShowDetails.Size = new System.Drawing.Size(184, 38);
            this.tsmiShowDetails.Text = "Show Details";
            this.tsmiShowDetails.Click += new System.EventHandler(this.ShowUserDetails);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmiAddNewUser
            // 
            this.tsmiAddNewUser.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.tsmiAddNewUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiAddNewUser.Name = "tsmiAddNewUser";
            this.tsmiAddNewUser.Size = new System.Drawing.Size(184, 38);
            this.tsmiAddNewUser.Text = "Add New User";
            this.tsmiAddNewUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tsmiEditUser
            // 
            this.tsmiEditUser.Image = global::DVLD.Properties.Resources.Edit_User_32;
            this.tsmiEditUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEditUser.Name = "tsmiEditUser";
            this.tsmiEditUser.Size = new System.Drawing.Size(184, 38);
            this.tsmiEditUser.Text = "Edit";
            this.tsmiEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Image = global::DVLD.Properties.Resources.Delete_User_32;
            this.tsmiDeleteUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(184, 38);
            this.tsmiDeleteUser.Text = "Delete";
            this.tsmiDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // tsmiChangePass
            // 
            this.tsmiChangePass.Image = global::DVLD.Properties.Resources.Password_32;
            this.tsmiChangePass.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiChangePass.Name = "tsmiChangePass";
            this.tsmiChangePass.Size = new System.Drawing.Size(184, 38);
            this.tsmiChangePass.Text = "Change Password";
            this.tsmiChangePass.Click += new System.EventHandler(this.tsmiChangePass_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Image = global::DVLD.Properties.Resources.send_email_32;
            this.tsmiSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(184, 38);
            this.tsmiSendEmail.Text = "Send Email";
            this.tsmiSendEmail.Click += new System.EventHandler(this.FeatureStubError);
            // 
            // tsmiPhoneCall
            // 
            this.tsmiPhoneCall.Image = global::DVLD.Properties.Resources.call_32;
            this.tsmiPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiPhoneCall.Name = "tsmiPhoneCall";
            this.tsmiPhoneCall.Size = new System.Drawing.Size(184, 38);
            this.tsmiPhoneCall.Text = "Phone Call";
            this.tsmiPhoneCall.Click += new System.EventHandler(this.FeatureStubError);
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
            this.cmbActiveFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // btnAddUser
            // 
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_New_User_72;
            this.btnAddUser.Location = new System.Drawing.Point(584, 139);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(80, 74);
            this.btnAddUser.TabIndex = 15;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
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
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 542);
            this.Controls.Add(this.cmbActiveFilter);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvAllUsers);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pbHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).EndInit();
            this.cmManageUser.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ComboBox cmbActiveFilter;
        private System.Windows.Forms.ContextMenuStrip cmManageUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePass;
    }
}
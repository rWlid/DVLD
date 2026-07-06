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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePeople));
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.tBFilter = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
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
            this.dgvAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAllPeople.Location = new System.Drawing.Point(12, 213);
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.Size = new System.Drawing.Size(1180, 273);
            this.dgvAllPeople.TabIndex = 2;
            this.dgvAllPeople.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAllPeople_CellMouseDoubleClick);
            this.dgvAllPeople.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllPeople_DataBindingComplete);
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
            // tBFilter
            // 
            this.tBFilter.Location = new System.Drawing.Point(221, 187);
            this.tBFilter.Name = "tBFilter";
            this.tBFilter.Size = new System.Drawing.Size(137, 20);
            this.tBFilter.TabIndex = 4;
            this.tBFilter.Visible = false;
            this.tBFilter.TextChanged += new System.EventHandler(this.tBFilter_TextChanged);
            this.tBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBFilter_KeyPress);
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
            // btnCloseForm
            // 
            this.btnCloseForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseForm.Image")));
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(1077, 492);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(115, 38);
            this.btnCloseForm.TabIndex = 7;
            this.btnCloseForm.Text = "    Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPerson.Image")));
            this.btnAddNewPerson.Location = new System.Drawing.Point(1141, 163);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(51, 44);
            this.btnAddNewPerson.TabIndex = 6;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pbHeader
            // 
            this.pbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbHeader.Image = ((System.Drawing.Image)(resources.GetObject("pbHeader.Image")));
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
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.tBFilter);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvAllPeople);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pbHeader);
            this.Name = "frmManagePeople";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.DataGridView dgvAllPeople;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.TextBox tBFilter;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecords;
    }
}
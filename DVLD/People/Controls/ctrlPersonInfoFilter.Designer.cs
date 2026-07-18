namespace DVLD.People.Controls
{
    partial class ctrlPersonInfoFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersonInfo = new DVLD.People.Controls.ctrlPersonInfo();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonInfo
            // 
            this.ctrlPersonInfo.Location = new System.Drawing.Point(-1, 65);
            this.ctrlPersonInfo.Name = "ctrlPersonInfo";
            this.ctrlPersonInfo.Size = new System.Drawing.Size(703, 251);
            this.ctrlPersonInfo.TabIndex = 12;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(608, 11);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(40, 40);
            this.btnFind.TabIndex = 10;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnPersonLookUp_Click);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(6, 20);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 9;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(211, 20);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(137, 20);
            this.txtFilterValue.TabIndex = 8;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBFilter_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.tBFilter_Validating);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(84, 20);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterBy.TabIndex = 7;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAdd.Location = new System.Drawing.Point(654, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblFilterBy);
            this.gbFilter.Controls.Add(this.btnAdd);
            this.gbFilter.Controls.Add(this.cmbFilterBy);
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Controls.Add(this.txtFilterValue);
            this.gbFilter.Location = new System.Drawing.Point(0, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(703, 58);
            this.gbFilter.TabIndex = 13;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // ctrlPersonInfoFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlPersonInfo);
            this.Name = "ctrlPersonInfoFilter";
            this.Size = new System.Drawing.Size(703, 316);
            this.Load += new System.EventHandler(this.ctrlPersonInfoFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD.People.Controls.ctrlPersonInfo ctrlPersonInfo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbFilter;
    }
}

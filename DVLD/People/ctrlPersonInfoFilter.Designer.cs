namespace DVLD
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
            this.ctrlPersonInfo1 = new DVLD.ctrlPersonInfo();
            this.btnPersonLookUp = new System.Windows.Forms.Button();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.tBFilter = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlPersonInfo1
            //
            // 
            // btnPersonLookUp
            // 
            this.btnPersonLookUp.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btnPersonLookUp.Location = new System.Drawing.Point(614, 0);
            this.btnPersonLookUp.Name = "btnPersonLookUp";
            this.btnPersonLookUp.Size = new System.Drawing.Size(40, 40);
            this.btnPersonLookUp.TabIndex = 10;
            this.btnPersonLookUp.UseVisualStyleBackColor = true;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(0, 11);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 9;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // tBFilter
            // 
            this.tBFilter.Location = new System.Drawing.Point(205, 11);
            this.tBFilter.Name = "tBFilter";
            this.tBFilter.Size = new System.Drawing.Size(137, 20);
            this.tBFilter.TabIndex = 8;
            this.tBFilter.Visible = false;
            this.tBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBFilter_KeyPress);
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
            this.cmbFilterBy.Location = new System.Drawing.Point(78, 11);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterBy.TabIndex = 7;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.Location = new System.Drawing.Point(660, 0);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(40, 40);
            this.btnAddNewPerson.TabIndex = 11;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonInfoFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnPersonLookUp);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.tBFilter);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Name = "ctrlPersonInfoFilter";
            this.Size = new System.Drawing.Size(703, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.Button btnPersonLookUp;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox tBFilter;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
    }
}

namespace DVLD
{
    partial class frmPersonDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonDetails));
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.ctrlPersonDetails1 = new DVLD.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormTitle.Location = new System.Drawing.Point(259, 29);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(229, 47);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Person Details";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseForm.Image")));
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(610, 349);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(115, 38);
            this.btnCloseForm.TabIndex = 8;
            this.btnCloseForm.Text = "    Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Address = "???";
            this.ctrlPersonDetails1.Country = "???";
            this.ctrlPersonDetails1.DOB = "???";
            this.ctrlPersonDetails1.Email = "???";
            this.ctrlPersonDetails1.FullName = "???";
            this.ctrlPersonDetails1.Gender = "???";
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(22, 92);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = "???";
            this.ctrlPersonDetails1.PersonID = "???";
            this.ctrlPersonDetails1.Phone = "???";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(703, 251);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 396);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "frmPersonDetails";
            this.Text = "Person Details";
            this.Load += new System.EventHandler(this.frmPersonDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnCloseForm;
    }
}
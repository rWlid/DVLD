namespace DVLD
{
    partial class frmAddEditPerson
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
            this.lblPersonID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llblSetImage = new System.Windows.Forms.LinkLabel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.pbPersonPicture = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.label18 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.lblFormTitle.TabIndex = 3;
            this.lblFormTitle.Text = "Add New Person";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(171, 64);
            this.lblPersonID.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(33, 16);
            this.lblPersonID.TabIndex = 23;
            this.lblPersonID.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(351, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Phone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(307, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Date of Birth:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gender:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "National No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Person ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Country:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llRemoveImage);
            this.panel1.Controls.Add(this.llblSetImage);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCloseForm);
            this.panel1.Controls.Add(this.cbCountry);
            this.panel1.Controls.Add(this.dtpDOB);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtNationalNo);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.txtSecondName);
            this.panel1.Controls.Add(this.txtThirdName);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.rbFemale);
            this.panel1.Controls.Add(this.rdMale);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.pbPersonPicture);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 295);
            this.panel1.TabIndex = 12;
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Location = new System.Drawing.Point(635, 206);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(47, 13);
            this.llRemoveImage.TabIndex = 14;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove";
            this.llRemoveImage.Visible = false;
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llblSetImage
            // 
            this.llblSetImage.AutoSize = true;
            this.llblSetImage.Location = new System.Drawing.Point(632, 184);
            this.llblSetImage.Name = "llblSetImage";
            this.llblSetImage.Size = new System.Drawing.Size(55, 13);
            this.llblSetImage.TabIndex = 13;
            this.llblSetImage.TabStop = true;
            this.llblSetImage.Text = "Set Image";
            this.llblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSetImage_LinkClicked);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(164, 156);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(417, 89);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(466, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(345, 254);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(115, 38);
            this.btnCloseForm.TabIndex = 16;
            this.btnCloseForm.Text = "    Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(455, 123);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(126, 21);
            this.cbCountry.TabIndex = 11;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Checked = false;
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(455, 58);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(126, 20);
            this.dtpDOB.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(455, 93);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(126, 20);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Digit_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(164, 123);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(126, 20);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Location = new System.Drawing.Point(164, 58);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(126, 20);
            this.txtNationalNo.TabIndex = 5;
            this.txtNationalNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterOrDigit_KeyPress);
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(164, 26);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(126, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtSecondName
            // 
            this.txtSecondName.Location = new System.Drawing.Point(312, 26);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(126, 20);
            this.txtSecondName.TabIndex = 2;
            this.txtSecondName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtThirdName
            // 
            this.txtThirdName.Location = new System.Drawing.Point(455, 26);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(126, 20);
            this.txtThirdName.TabIndex = 3;
            this.txtThirdName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(641, 11);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 16);
            this.label23.TabIndex = 33;
            this.label23.Text = "Last";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(596, 26);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(126, 20);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Letter_KeyPress);
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(498, 11);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 16);
            this.label22.TabIndex = 31;
            this.label22.Text = "Third";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(349, 10);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 16);
            this.label21.TabIndex = 29;
            this.label21.Text = "Second";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(211, 10);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 16);
            this.label20.TabIndex = 27;
            this.label20.Text = "First";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Image = global::DVLD.Properties.Resources.Woman_32;
            this.label19.Location = new System.Drawing.Point(198, 82);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 33);
            this.label19.TabIndex = 25;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(231, 94);
            this.rbFemale.Margin = new System.Windows.Forms.Padding(0);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 8;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Checked = true;
            this.rdMale.Location = new System.Drawing.Point(150, 94);
            this.rdMale.Margin = new System.Windows.Forms.Padding(0);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(48, 17);
            this.rdMale.TabIndex = 7;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            this.rdMale.CheckedChanged += new System.EventHandler(this.rdMale_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVLD.Properties.Resources.Person_32;
            this.label10.Location = new System.Drawing.Point(116, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 34);
            this.label10.TabIndex = 15;
            // 
            // pbPersonPicture
            // 
            this.pbPersonPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonPicture.Image = global::DVLD.Properties.Resources.Male_512;
            this.pbPersonPicture.Location = new System.Drawing.Point(596, 53);
            this.pbPersonPicture.Margin = new System.Windows.Forms.Padding(5);
            this.pbPersonPicture.Name = "pbPersonPicture";
            this.pbPersonPicture.Size = new System.Drawing.Size(126, 126);
            this.pbPersonPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonPicture.TabIndex = 15;
            this.pbPersonPicture.TabStop = false;
            this.pbPersonPicture.Tag = "";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::DVLD.Properties.Resources.Man_32;
            this.label12.Location = new System.Drawing.Point(117, 82);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 33);
            this.label12.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Image = global::DVLD.Properties.Resources.Country_32;
            this.label17.Location = new System.Drawing.Point(418, 119);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 34);
            this.label17.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::DVLD.Properties.Resources.Number_32;
            this.label11.Location = new System.Drawing.Point(117, 53);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 33);
            this.label11.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Image = global::DVLD.Properties.Resources.Phone_32;
            this.label16.Location = new System.Drawing.Point(418, 85);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 34);
            this.label16.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::DVLD.Properties.Resources.Email_32;
            this.label13.Location = new System.Drawing.Point(117, 119);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 33);
            this.label13.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.label15.Location = new System.Drawing.Point(418, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 34);
            this.label15.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Image = global::DVLD.Properties.Resources.Address_32;
            this.label14.Location = new System.Drawing.Point(117, 156);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 33);
            this.label14.TabIndex = 19;
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialogImage";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Image = global::DVLD.Properties.Resources.Number_32;
            this.label18.Location = new System.Drawing.Point(128, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 33);
            this.label18.TabIndex = 23;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 396);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPersonID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPerson";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditPerson";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddEditPerson_FormClosing);
            this.Load += new System.EventHandler(this.frmAddEditPerson_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.PictureBox pbPersonPicture;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.LinkLabel llblSetImage;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
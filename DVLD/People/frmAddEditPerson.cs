using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DVLD.BL;
using DVLD.Properties;

namespace DVLD.People
{
    public partial class frmAddEditPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);
        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender{ Male = 0, Female = 1 };

        private enMode _Mode;
        int _PersonID;
        clsPerson _Person;
        bool _EditNotSaved = false;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;

        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();
           
            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add Person";
                this.Text = "Add Person";
                _Person = new clsPerson();
            }
            else
            {
                lblFormTitle.Text = "Update Person";
                this.Text = "Update Person";
            }
            pbPersonPicture.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;
            llRemoveImage.Visible = false;

            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            dtpDOB.MinDate = DateTime.Now.AddYears(-80);

            lblPersonID.Text = "N/A";
            txtNationalNo.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            rbMale.Checked = true;
            dtpDOB.Value = dtpDOB.MaxDate;
            cbCountry.SelectedIndex = cbCountry.FindString("Saudi Arabia");

        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonPicture.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonPicture.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonPicture.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void _EditMaded(object sender, EventArgs e) { _EditNotSaved = true; }
        private void _AttachChangeEvents()
        {
            txtNationalNo.TextChanged += _EditMaded;
            txtFirstName.TextChanged += _EditMaded;
            txtSecondName.TextChanged += _EditMaded;
            txtThirdName.TextChanged += _EditMaded;
            txtLastName.TextChanged += _EditMaded;
            txtAddress.TextChanged += _EditMaded;
            txtEmail.TextChanged += _EditMaded;
            txtPhone.TextChanged += _EditMaded;
            dtpDOB.ValueChanged += _EditMaded;
            cbCountry.SelectedIndexChanged += _EditMaded;
            rbMale.CheckedChanged += _EditMaded;
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }

        }
        private void _SetDefaultImage()
        {
            pbPersonPicture.Image = rbMale.Checked == true ? DVLD.Properties.Resources.Male_512 : DVLD.Properties.Resources.Female_512;
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if(_Person  == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID,"Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.ID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone; 
            dtpDOB.Value = _Person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            if (_Person.Gender == 0) { rbMale.Checked = true; } else { rbFemale.Checked = true; }
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _Person.ImagePath;
                llRemoveImage.Visible = true;
            }


        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Update)
                _LoadData();

            _AttachChangeEvents();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_EditNotSaved)
            {
                MessageBox.Show("Nothing to Save", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!this.ValidateChildren()) { return; }

            if (!_HandlePersonImage()) { return; }

            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDOB.Value;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.CountryID = clsCountry.Find(cbCountry.Text).ID;
            _Person.Gender = rbMale.Checked ? (short)enGender.Male : (short)enGender.Female;
            _Person.ImagePath = pbPersonPicture.ImageLocation != null ? pbPersonPicture.ImageLocation.ToString() : "";


            if (_Person.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Person";
                this.Text = "Update Person";
                lblPersonID.Text = _Person.ID.ToString();
                _EditNotSaved = false;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                //DataBack?.Invoke(this, _Person.ID);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialogImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialogImage.Title = "Choose a Profile Image";
            openFileDialogImage.FileName = string.Empty;
            openFileDialogImage.FilterIndex = 1;
            openFileDialogImage.RestoreDirectory = true;

            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialogImage.FileName;
                pbPersonPicture.Load(selectedImagePath);
                _EditNotSaved = true;
                llRemoveImage.Visible = true;
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonPicture.ImageLocation = null;
            _SetDefaultImage();
            _EditNotSaved = true;
            llRemoveImage.Visible = false;
        }
        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            if (_Person.ImagePath == "")
                _SetDefaultImage();
        }
        private void frmAddEditPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_EditNotSaved && MessageBox.Show("You have unsaved changes. Are you sure you want to close?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            DataBack?.Invoke(this, _Person.ID);
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "Required field");
            }
            else
            {
                errorProvider1.SetError(txt, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider1.SetError(txtEmail,null);
                return;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid email format");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "Required field");
            }
            else if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }
        private void LetterOrDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void Letter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
    }
}

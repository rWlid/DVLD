using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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

        public enum Mode { AddNew = 0, Update = 1 }
        public enum Gender { Male = 0, Female = 1 }

        private Mode _mode;
        private readonly int _personID;
        private Person _person;
        private bool _editNotSaved = false;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _mode = Mode.AddNew;

        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _personID = PersonID;
            _mode = Mode.Update;

        }
        private void ResetDefaultValues()
        {
            FillCountriesInComboBox();

            if (_mode == Mode.AddNew)
            {
                lblFormTitle.Text = "Add Person";
                Text = "Add Person";
                _person = new Person();
            }
            else
            {
                lblFormTitle.Text = "Update Person";
                Text = "Update Person";
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
        private bool HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_person.ImagePath != pbPersonPicture.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_person.ImagePath);
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

                    if (Utils.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void EditMade(object sender, EventArgs e) { _editNotSaved = true; }
        private void AttachChangeEvents()
        {
            txtNationalNo.TextChanged += EditMade;
            txtFirstName.TextChanged += EditMade;
            txtSecondName.TextChanged += EditMade;
            txtThirdName.TextChanged += EditMade;
            txtLastName.TextChanged += EditMade;
            txtAddress.TextChanged += EditMade;
            txtEmail.TextChanged += EditMade;
            txtPhone.TextChanged += EditMade;
            dtpDOB.ValueChanged += EditMade;
            cbCountry.SelectedIndexChanged += EditMade;
            rbMale.CheckedChanged += EditMade;
        }
        private void FillCountriesInComboBox()
        {
            DataTable dtCountries = Country.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }

        }
        private void SetDefaultImage()
        {
            pbPersonPicture.Image = rbMale.Checked == true
                ? DVLD.Properties.Resources.Male_512
                : DVLD.Properties.Resources.Female_512;
        }
        private void LoadData()
        {
            _person = Person.Find(_personID);

            if (_person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _personID,
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblPersonID.Text = _person.ID.ToString();
            txtNationalNo.Text = _person.NationalNo;
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtAddress.Text = _person.Address;
            txtEmail.Text = _person.Email;
            txtPhone.Text = _person.Phone;
            dtpDOB.Value = _person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(_person.CountryInfo.CountryName);
            if (_person.Gender == 0) { rbMale.Checked = true; } else { rbFemale.Checked = true; }
            if (!string.IsNullOrEmpty(_person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _person.ImagePath;
                llRemoveImage.Visible = true;
            }


        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if (_mode == Mode.Update)
            {
                LoadData();
            }

            AttachChangeEvents();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_editNotSaved)
            {
                MessageBox.Show("Nothing to Save", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateChildren()) { return; }

            if (!HandlePersonImage()) { return; }

            _person.NationalNo = txtNationalNo.Text;
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.Address = txtAddress.Text;
            _person.DateOfBirth = dtpDOB.Value;
            _person.Email = txtEmail.Text;
            _person.Phone = txtPhone.Text;
            _person.CountryID = Country.Find(cbCountry.Text).ID;
            _person.Gender = rbMale.Checked ? (short)Gender.Male : (short)Gender.Female;
            _person.ImagePath = pbPersonPicture.ImageLocation != null ? pbPersonPicture.ImageLocation.ToString() : "";


            if (_person.Save())
            {
                _mode = Mode.Update;
                lblFormTitle.Text = "Update Person";
                Text = "Update Person";
                lblPersonID.Text = _person.ID.ToString();
                _editNotSaved = false;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                //DataBack?.Invoke(this, _person.ID);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
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
                _editNotSaved = true;
                llRemoveImage.Visible = true;
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonPicture.ImageLocation = null;
            SetDefaultImage();
            _editNotSaved = true;
            llRemoveImage.Visible = false;
        }
        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            if (_person.ImagePath == "")
            {
                SetDefaultImage();
            }
        }
        private void frmAddEditPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_editNotSaved && MessageBox.Show("You have unsaved changes. Are you sure you want to close?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            DataBack?.Invoke(this, _person.ID);
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
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
                errorProvider1.SetError(txtEmail, null);
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
            else if (txtNationalNo.Text.Trim() != _person.NationalNo && Person.IsPersonExist(txtNationalNo.Text.Trim()))
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

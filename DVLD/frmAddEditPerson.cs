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
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        int _PersonID;
        clsPerson _Person;
        string ImagePath = null;
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = _PersonID == -1 ? enMode.AddNew : enMode.Update;

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
            pbPersonPicture.Image = rdMale.Checked == true ? (Image)DVLD.Properties.Resources.Male_512.Clone() : (Image)DVLD.Properties.Resources.Female_512.Clone();
        }
        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = cbCountry.FindString("Saudi Arabia");

            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add Person";
                this.Text = "Add Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if(_Person  == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();
                return;
            }

            lblFormTitle.Text = "Update Person";
            this.Text = "Update Person";

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
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.CountryID).CountryName);
            if (_Person.Gender == (byte)0) { rdMale.Checked = true; } else { rbFemale.Checked = true; }
            if (_Person.ImagePath != null && _Person.ImagePath != "")
            {
                Image temp = Image.FromFile(_Person.ImagePath);
                pbPersonPicture.Image = new Bitmap(temp);
                temp.Dispose();
                // The file is unlocked because the Image in PictureBox 
                // is now an independent copy in memory.
            }
            else
            {
                _SetDefaultImage();
            }


        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
            _Person.Gender = rdMale.Checked == true ? (byte)0 : (byte)1;

            if (ImagePath != null)
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                {
                    File.Delete(_Person.ImagePath);
                }
                _Person.ImagePath = ImagePath;
            }

            if (_Person.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Person";
                this.Text = "Update Person";
                lblPersonID.Text = _Person.ID.ToString();
                ImagePath = null;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                const string targetFolder = @"C:\DVLD-People-Images\";
                string selectedImagePath = openFileDialogImage.FileName;
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                string targetImagePath = Path.Combine(targetFolder, ImageName);

                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                try
                {
                    File.Copy(selectedImagePath, targetImagePath);

                    Image temp = Image.FromFile(targetImagePath);
                    pbPersonPicture.Image = new Bitmap(temp);
                    temp.Dispose();

                    ImagePath = targetImagePath;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while saving new image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (File.Exists(targetImagePath))
                    {
                        File.Delete(targetImagePath);
                    }
                }
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImagePath = string.Empty;
            _SetDefaultImage();
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_Person.ImagePath == "")
                    _SetDefaultImage();
        }
    }
}

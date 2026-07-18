using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;
using DVLD.Properties;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonInfo : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        private void _SetDefaultImage()
        {
            pbPersonPicture.Image = _Person.Gender == 0 ? (Image)DVLD.Properties.Resources.Male_512.Clone() : (Image)DVLD.Properties.Resources.Female_512.Clone();
        }
        private void _LoadPersonImage()
        {
            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _Person.ImagePath;
            }
            else { _SetDefaultImage(); }
        }
        private void _LoadData()
        {
            llblEditPersonInfo.Enabled = true;
            _PersonID = _Person.ID;
            lblPersonID.Text = _Person.ID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
                lblGenderIcon.Image = (Image)DVLD.Properties.Resources.Man_32.Clone();
            }
            else
            {
                lblGender.Text = "Female";
                lblGenderIcon.Image = (Image)DVLD.Properties.Resources.Woman_32.Clone();
            }
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDOB.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            _LoadPersonImage();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGenderIcon.Image = Resources.Man_32;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDOB.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonPicture.Image = Resources.Male_512;

        }
        public bool LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if( _Person == null ) 
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with ID: " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }

            _LoadData();
            return true;
        }
        public bool LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National Number: " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _LoadData();
            return true;
        }
        public bool LoadPersonInfo(clsPerson Perosn)
        {
            _Person = Perosn;

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National Number: " + Perosn.NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _LoadData();
            return true;
        }
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_Person.ID);
            frm.ShowDialog();

            //Load new edited data
            LoadPersonInfo(_Person.ID);
        }
    }
}

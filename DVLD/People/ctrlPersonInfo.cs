using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD
{
    public partial class ctrlPersonInfo : UserControl
    {
        private int _PersonID;
        private clsPerson _Person;
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
        private void _LoadData()
        {
            lblPersonID.Text = _PersonID.ToString();
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
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _Person.ImagePath;
            }
            else { _SetDefaultImage(); }
        }
        public bool LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.Find(_PersonID);

            _LoadData();
            return _Person != null;
        }
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();

            //Load new edited data
            LoadPersonInfo(_PersonID);
        }
    }
}

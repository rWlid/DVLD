using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD
{
    
    public partial class frmPersonDetails : Form
    {
        private int _PersonID;
        private clsPerson _Person;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _SetDefaultImage()
        {
            ctrlPersonInfo.PersonImage = _Person.Gender == 0 ? (Image)DVLD.Properties.Resources.Male_512.Clone() : (Image)DVLD.Properties.Resources.Female_512.Clone();
        }
        private void _LoadData()
        {
            ctrlPersonInfo.PersonID = _PersonID.ToString();
            ctrlPersonInfo.FullName = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            ctrlPersonInfo.NationalNo = _Person.NationalNo;
            ctrlPersonInfo.Gender = _Person.Gender == 0 ? "Male" : "Female";
            ctrlPersonInfo.Email = _Person.Email;
            ctrlPersonInfo.Address = _Person.Address;
            ctrlPersonInfo.DOB = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            ctrlPersonInfo.Phone = _Person.Phone;
            ctrlPersonInfo.Country = clsCountry.Find(_Person.CountryID).CountryName;
            if (_Person.ImagePath != "")
            {
                Image temp = Image.FromFile(_Person.ImagePath);
                ctrlPersonInfo.PersonImage = new Bitmap(temp);
                temp.Dispose();
            }
            else { _SetDefaultImage(); }
        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                this.Close();
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                return;
            }

            _LoadData();


        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();
            _Person = clsPerson.Find(_PersonID);
            _LoadData();
        }
    }
}

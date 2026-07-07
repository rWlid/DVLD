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
        private void _LoadData()
        {
            ctrlPersonDetails1.PersonID = _PersonID.ToString();
            ctrlPersonDetails1.FullName = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            ctrlPersonDetails1.NationalNo = _Person.NationalNo;
            ctrlPersonDetails1.Gender = _Person.Gender == 0 ? "Male" : "Female";
            ctrlPersonDetails1.Email = _Person.Email;
            ctrlPersonDetails1.Address = _Person.Address;
            ctrlPersonDetails1.DOB = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            ctrlPersonDetails1.Phone = _Person.Phone;
            ctrlPersonDetails1.Country = clsCountry.Find(_Person.CountryID).CountryName;
            if (_Person.ImagePath != "")
            {
                Image temp = Image.FromFile(_Person.ImagePath);
                ctrlPersonDetails1.PersonImage = new Bitmap(temp);
                temp.Dispose();
            }
            else { ctrlPersonDetails1.Gender = ctrlPersonDetails1.Gender.Equals("Male") ? "Male" : "Female"; }
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

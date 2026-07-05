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
        int _PersonID;
        clsPerson _Person;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }

            ctrlPersonDetails1.PersonID = _PersonID.ToString();
            ctrlPersonDetails1.FullName = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            ctrlPersonDetails1.NationalNo = _Person.NationalNo;
            switch (_Person.Gender) { case 1: ctrlPersonDetails1.Gender = "Male"; break; case 0: ctrlPersonDetails1.Gender = "Female"; break;}
            ctrlPersonDetails1.Email = _Person.Email;
            ctrlPersonDetails1.Address = _Person.Address;
            ctrlPersonDetails1.DOB = _Person.DateOfBirth.ToString();

            if (_Person.ImagePath != "")
            {
               // pictureBox1.Load(_Person.ImagePath);
            }
        }
    }
}

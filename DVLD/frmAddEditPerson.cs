using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
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
            _Person.CountryID = clsCountry.Find(cbCountry.Text).ID;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.CountryID).CountryName);
            rdMale.Checked = _Person.Gender == (byte)0 ? true : false;
            pbPersonPicture.ImageLocation = _Person.ImagePath != null ? _Person.ImagePath : "";
            if(_Person.ImagePath != null && _Person.ImagePath != "")
            {
               pbPersonPicture.Load(_Person.ImagePath);
            }
            else
            {
                pbPersonPicture.Image = _Person.Gender == (byte)0 ? DVLD.Properties.Resources.Male_512 : DVLD.Properties.Resources.Female_512;
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
            _Person.ImagePath = pbPersonPicture.ImageLocation != null ? pbPersonPicture.ImageLocation : "";

            if (_Person.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Person";
                this.Text = "Update Person";
                lblPersonID.Text = _Person.ID.ToString();
            }


        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

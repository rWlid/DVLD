using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonDetails : UserControl
    {
        public string PersonID {
            get { return lblPersonID.Text; }
            set {  lblPersonID.Text = value; } 
        }
        public string FullName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string NationalNo
        {
            get { return lblNationalNo.Text; }
            set { lblNationalNo.Text = value; }
        }
        public string Gender
        {
            get { return lblGender.Text; }
            set { lblGender.Text = value; }
        }
        public string Email
        {
            get { return lblEmail.Text; }
            set { lblEmail.Text = value; }
        }
        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }
        public string DOB
        {
            get { return lblDOB.Text; }
            set { lblDOB.Text = value; }
        }
        public string Phone
        {
            get { return lblPhone.Text; }
            set { lblPhone.Text = value; }
        }
        public string Country
        {
            get { return lblCountry.Text; }
            set { lblCountry.Text = value; }
        }

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
    }
}

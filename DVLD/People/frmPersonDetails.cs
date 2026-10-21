using System;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.People
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            if (!ctrlPersonInfo.LoadPersonInfo(PersonID))
            {
                MessageBox.Show("No Person is found with ID: " + PersonID);
                Close();
            }
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            if (!ctrlPersonInfo.LoadPersonInfo(NationalNo))
            {
                MessageBox.Show("No Person is found with National Number: " + NationalNo);
                Close();
            }
        }
        public frmPersonDetails(Person Person)
        {
            InitializeComponent();
            if (!ctrlPersonInfo.LoadPersonInfo(Person))
            {
                MessageBox.Show("No Person is found with ID: " + Person.ID);
                Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

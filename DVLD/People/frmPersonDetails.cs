using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                this.Close();
            }
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            if (!ctrlPersonInfo.LoadPersonInfo(NationalNo))
            {
                MessageBox.Show("No Person is found with National Number: " + NationalNo);
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

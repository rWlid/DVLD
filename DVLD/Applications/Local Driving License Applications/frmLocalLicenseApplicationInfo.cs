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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Local_Driving_License_Applications
{
    public partial class frmLocalLicenseApplicationInfo : Form
    {
        private int _ApplicationID;
        public frmLocalLicenseApplicationInfo(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void frmLocalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if (!ctrlApplicationInfo1.LoadApplicationInfo(_ApplicationID))
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

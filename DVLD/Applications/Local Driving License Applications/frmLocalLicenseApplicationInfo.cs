using System;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License_Applications
{
    public partial class frmLocalLicenseApplicationInfo : Form
    {
        private readonly int _applicationID;
        public frmLocalLicenseApplicationInfo(int applicationID)
        {
            InitializeComponent();
            _applicationID = applicationID;
        }

        private void frmLocalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if (!ctrlApplicationInfo1.LoadApplicationInfo(_applicationID))
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

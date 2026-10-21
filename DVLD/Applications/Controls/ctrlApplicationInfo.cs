using System.Windows.Forms;
using DVLD.BL;
using DVLD.People;

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationInfo : UserControl
    {
        private LocalLicenseApplication _application;
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void llViewPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmPersonDetails(_application.ApplicantInfo);
            frm.ShowDialog();
            LoadApplicationInfo(_application.ID);
        }

        public bool LoadApplicationInfo(int ApplicationID)
        {
            _application = LocalLicenseApplication.Find(ApplicationID);
            if (_application == null) { return false; }

            lblLDLAID.Text = _application.LocalID.ToString();
            lblLicenseClass.Text = _application.LicenseClass.Name;
            lblPassedTest.Text = $"{_application.GetNumberOfPassedTests()}/3";
            lblBaseID.Text = _application.ID.ToString();
            lblStatus.Text = _application.LastStatus.ToString();
            lblFees.Text = _application.Fees.ToString();
            lblApplicationType.Text = _application.Type.Title;
            lblApplicationDate.Text = _application.Date.ToString();
            lblStatusDate.Text = _application.LastStatusDate.ToString();
            lblCreatorID.Text = _application.CreatorUsername;
            lblApplicantFullName.Text = _application.ApplicantInfo.FullName;
            return true;
        }
    }
}

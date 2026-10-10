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
using DVLD.People;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationInfo : UserControl
    {
        private clsLocalLicenseApplicaiton _Application;
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void llViewPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.ApplicantInfo);
            frm.ShowDialog();
            LoadApplicationInfo(_Application.ID);
        }

        public bool LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsLocalLicenseApplicaiton.Find(ApplicationID);
            if (_Application == null) { return false; }

            lblLDLAID.Text = _Application.LocalID.ToString();
            lblLicenseClass.Text = _Application.LicenseClass.Name;
            lblPassedTest.Text = $"{_Application.GetNumberOfPassedTests()}/3";
            lblBaseID.Text = _Application.ID.ToString();
            lblStatus.Text = _Application.LastStatus.ToString();
            lblFees.Text = _Application.Fees.ToString();
            lblApplicationType.Text = _Application.Type.Title;
            lblApplicationDate.Text = _Application.Date.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatorID.Text = _Application.CreatorUsername;
            lblApplicantFullName.Text = _Application.ApplicantInfo.FullName;
            return true;
        }
    }
}

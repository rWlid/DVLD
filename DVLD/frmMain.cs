using System;
using System.Windows.Forms;
using DVLD.Applications;
using DVLD.Applications.Local_Driving_License_Applications;
using DVLD.BL;
using DVLD.People;
using DVLD.Tests.TestTypes;
using DVLD.Users;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUserDetails(Globals.CurrentUser.ID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword(Globals.CurrentUser.ID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListApplicationsTypes();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.CurrentUser = null;
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListLDLApplications();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAddNewLocalLicenseApplication();
            frm.ShowDialog();
        }
    }
}

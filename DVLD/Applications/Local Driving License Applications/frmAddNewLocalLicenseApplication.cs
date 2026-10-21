using System;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Applications
{
    public partial class frmAddNewLocalLicenseApplication : Form
    {
        public enum Mode { AddNew = 0, Update = 1 }
        public enum Status { New = 1, Cancelled = 2, Completed = 3 }
        public enum LicenseClass
        {
            Class1SmallMotorcycle = 1,
            Class2HeavyMotorcycleLicense = 2,
            Class3OrdinaryDrivinglicense = 3,
            Class4Commercial = 4,
            Class5Agricultural = 5,
            Class6SmallandMediumBus = 6,
            Class7TruckAndHeavyVehicle = 7
        }

        private Mode _mode;
        private readonly int _dlApplicationID;
        private LocalLicenseApplication _dlApplication;
        public frmAddNewLocalLicenseApplication()
        {
            InitializeComponent();
            _mode = Mode.AddNew;
        }
        public frmAddNewLocalLicenseApplication(int DLApplicationID)
        {
            InitializeComponent();
            _dlApplicationID = DLApplicationID;
            _mode = Mode.Update;
        }
        private void ResetDefaultValues()
        {

            if (_mode == Mode.AddNew)
            {
                _dlApplication = new LocalLicenseApplication();
                tabApplicationInfo.Enabled = false;
            }
            else
            {
                lblFormTitle.Text = "Update Local Driving License Application";
                Text = "Update Local License Application";
            }
            lblDLApplicationID.Text = "???";
            lblFees.Text = ((int)ApplicationType.GetApplicationType(1).Fees).ToString();
            lblDate.Text = DateTime.Now.ToString();
            lblCreatorUsername.Text = Globals.CurrentUser.UserName;
            cbLicenseClasses.SelectedIndex = (int)LicenseClass.Class3OrdinaryDrivinglicense - 1;
            ctrlPersonInfoFilter1.ResetPersonInfo();
        }
        private void LoadData()
        {
            _dlApplication = LocalLicenseApplication.Find(_dlApplicationID);

            if (_dlApplication == null)
            {
                MessageBox.Show("This form will be closed because No Application with ID = " + _dlApplicationID,
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblDLApplicationID.Text = _dlApplication.ID.ToString();
            lblFees.Text = _dlApplication.Type.Fees.ToString();
            lblDate.Text = _dlApplication.Date.ToString();
            lblCreatorUsername.Text = _dlApplication.CreatorUsername;
            cbLicenseClasses.SelectedIndex = _dlApplication.LicenseClassID - 1; // since ID of First Class is 1
            ctrlPersonInfoFilter1.LoadPersonInfo(_dlApplication.ApplicantInfo.ID);
        }

        private void frmAddNewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if (_mode == Mode.Update)
            {
                LoadData();
                ctrlPersonInfoFilter1.FilterEnabled = false;
                tabApplicationInfo.Enabled = true;
            }
        }

        private void ctrlPersonInfoFilter1_OnPersonSelected(int obj)
        {
            btnNext.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please Select a Person to Apply for License", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
            cbLicenseClasses.Focus();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check if there is license with the same class

            //Check if there is an active application for the same class
            int ActiveApplicationID = _dlApplication.GetActiveApplicationIDForLicenseClass(
                ctrlPersonInfoFilter1.PersonID, cbLicenseClasses.SelectedIndex + 1);
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show($"Choose another License Class, The selected Person already has an active " +
                    $"application for the selected class with ID: {ActiveApplicationID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _dlApplication.Type = ApplicationType.GetApplicationType(1); //1 = New Local Driving License Service 
            _dlApplication.ApplicantID = ctrlPersonInfoFilter1.PersonID;
            _dlApplication.Date = DateTime.Parse(lblDate.Text);
            _dlApplication.Fees = decimal.Parse(lblFees.Text);
            _dlApplication.CreatorID = User.Find(lblCreatorUsername.Text).ID;
            _dlApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;

            if (_dlApplication.Save())
            {
                _mode = Mode.Update;
                lblFormTitle.Text = "Update Local Driving License Application";
                Text = "Update Local License Application";
                lblDLApplicationID.Text = _dlApplication.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

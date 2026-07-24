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

namespace DVLD.Applications
{
    public partial class frmAddNewLocalLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enLicenseClass 
        {
            Class1SmallMotorcycle = 1,
            Class2HeavyMotorcycleLicense = 2,
            Class3OrdinaryDrivinglicense = 3,
            Class4Commercial = 4,
            Class5Agricultural = 5,
            Class6SmallandMediumBus = 6,
            Class7TruckAndHeavyVehicle = 7
        };

        private enMode _Mode;
        int _DLApplicationID;
        clsLocalLicenseApplicaiton _DLApplication;
        public frmAddNewLocalLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddNewLocalLicenseApplication(int DLApplicationID)
        {
            InitializeComponent();
            _DLApplicationID = DLApplicationID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {

            if (_Mode == enMode.AddNew)
            {
                _DLApplication = new clsLocalLicenseApplicaiton();
                tabApplicationInfo.Enabled = false;
            }
            else
            {
                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local License Application";
            }
            lblDLApplicationID.Text = "???";
            lblFees.Text = ((int)clsApplicationType.GetApplicationType(1).Fees).ToString();
            lblDate.Text = DateTime.Now.ToString();
            lblCreatorUsername.Text = Globals.CurrentUser.UserName;
            cbLicenseClasses.SelectedIndex = (int)enLicenseClass.Class3OrdinaryDrivinglicense - 1;
            ctrlPersonInfoFilter1.ResetPersonInfo();
        }
        private void _LoadData()
        {
            _DLApplication = clsLocalLicenseApplicaiton.Find(_DLApplicationID); ;

            if (_DLApplication == null)
            {
                MessageBox.Show("This form will be closed because No Application with ID = " + _DLApplicationID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblDLApplicationID.Text = _DLApplication.ID.ToString();
            lblFees.Text = _DLApplication.ApplicationInfo.Type.Fees.ToString() ;
            lblDate.Text = _DLApplication.ApplicationInfo.Date.ToString();
            lblCreatorUsername.Text = _DLApplication.ApplicationInfo.CreatorUsername;
            cbLicenseClasses.SelectedIndex = _DLApplication.LicenseClassID - 1; // since ID of First Class is 1
            ctrlPersonInfoFilter1.LoadPersonInfo(_DLApplication.ApplicationInfo.ApplicantInfo.ID);
        }

        private void frmAddNewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
                ctrlPersonInfoFilter1.FilterEnabled = false;
                tabApplicationInfo.Enabled = true;
            }
        }

        private void ctrlPersonInfoFilter1_OnPersonSelected(int obj)
        {
            btnNext.Focus();
            btnSave.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please Select a Person to Apply for License", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
            cbLicenseClasses.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check if there is license with the same class

            //Check if there is an active application for the same class
            int ActiveApplicationID = _DLApplication.GetActiveApplicationIDForLicenseClass(ctrlPersonInfoFilter1.PersonID, cbLicenseClasses.SelectedIndex + 1);
            if(ActiveApplicationID != -1) { MessageBox.Show($"Choose another License Class, The selected Person already has an active application for the selected class with ID: {ActiveApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  return; }

            _DLApplication.ApplicationInfo.Type = clsApplicationType.GetApplicationType(1); //1 = New Local Driving License Service 
            _DLApplication.ApplicationInfo.ApplicantID = ctrlPersonInfoFilter1.PersonID;
            _DLApplication.ApplicationInfo.Date = DateTime.Parse(lblDate.Text);
            _DLApplication.ApplicationInfo.Fees = decimal.Parse(lblFees.Text);
            _DLApplication.ApplicationInfo.CreatorID = clsUser.Find(lblCreatorUsername.Text).ID;
            _DLApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;

            if (_DLApplication.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local License Application";
                lblDLApplicationID.Text = _DLApplication.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlPersonInfoFilter1.FilterEnabled = false;
            tabApplicationInfo.Enabled = true;
        }
    }
}

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
        public enum enLicenseClass 
        {
            Class1SmallMotorcycle = 0,
            Class2HeavyMotorcycleLicense = 1,
            Class3OrdinaryDrivinglicense = 2,
            Class4Commercial = 3,
            Class5Agricultural = 4,
            Class6SmallandMediumBus = 5,
            Class7TruckAndHeavyVehicle = 6
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
            }
            else
            {
                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local License Application";
            }
            lblDLApplicationID.Text = "???";
            lblFees.Text = clsApplicationType.GetApplicationType(1).Fees.ToString();
            lblDate.Text = DateTime.Now.ToString();
            lblCreatorUsername.Text = Globals.CurrentUser.UserName;
            cbLicenseClasses.SelectedIndex = (int)enLicenseClass.Class3OrdinaryDrivinglicense;
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
            ctrlPersonInfoFilter1.LoadPersonInfo(_DLApplication.ApplicationInfo.ApplicantInfo);
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
            _DLApplication.ApplicationInfo.ApplicantID = ctrlPersonInfoFilter1.PersonID;
            _DLApplication.ApplicationInfo.Date = DateTime.Parse(lblDate.Text);
            _DLApplication.ApplicationInfo.Fees = decimal.Parse(lblFees.Text);
            _DLApplication.ApplicationInfo.CreatorID = clsUser.Find(lblCreatorUsername.Text).ID;
            _DLApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;

            if (_DLApplication.ApplicationInfo.Save() && _DLApplication.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local License Application";
                ctrlPersonInfoFilter1.FilterEnabled = false;
                lblDLApplicationID.Text = _DLApplication.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Applications.Local_Driving_License_Applications
{
    public partial class frmListLDLApplications : Form
    {

        public frmListLDLApplications()
        {
            InitializeComponent();
        }

        private void dgvApplications_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvApplications.Rows.Count <= 0) { return; }
            dgvApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L Application ID";
            dgvApplications.Columns["LocalDrivingLicenseApplicationID"].Width = 125;

            dgvApplications.Columns["ClassName"].HeaderText = "Class Name";
            dgvApplications.Columns["ClassName"].Width = 225;

            dgvApplications.Columns["NationalNo"].HeaderText = "National No";

            dgvApplications.Columns["FullName"].HeaderText = "Full Name";
            dgvApplications.Columns["FullName"].Width = 275;

            dgvApplications.Columns["ApplicationDate"].HeaderText = "Date";
            dgvApplications.Columns["ApplicationDate"].Width = 150;

            dgvApplications.Columns["PassedTests"].HeaderText = "Passed Tests";
            dgvApplications.Columns["PassedTests"].Width = 100;

            dgvApplications.Columns["ApplicationStatus"].HeaderText = "Status";
            dgvApplications.Columns["ApplicationStatus"].Width = 75;
        }

        private void frmListLDLApplications_Load(object sender, EventArgs e)
        {
            dgvApplications.DataSource = clsLocalLicenseApplicaiton.GetAllApplications().DefaultView;
            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
            cmbFilterBy.SelectedIndex = 0;
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.Text.Equals("License Class Name"))
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();
                cbStatusFilter.Visible = false;
                cbStatusFilter.SelectedIndex = 0;

                cbLicenseClassFilter.Visible = true;
                cbLicenseClassFilter.SelectedIndex = 0;
                cbLicenseClassFilter.Focus();
            }
            else if (cmbFilterBy.Text.Equals("Status"))
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();
                cbLicenseClassFilter.Visible = false;
                cbLicenseClassFilter.SelectedIndex = 0;

                cbStatusFilter.Visible = true;
                cbStatusFilter.SelectedIndex = 0;
                cbStatusFilter.Focus();
            }
            else
            {
                cbStatusFilter.Visible = false;
                cbStatusFilter.SelectedIndex = 0;
                cbLicenseClassFilter.Visible = false;
                cbLicenseClassFilter.SelectedIndex = 0;

                txtFilterValue.Visible = cmbFilterBy.SelectedIndex != 0;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvApplications.DataSource;

            string column = cmbFilterBy.Text.Replace(" ", ""); // "Person ID" → "PersonID"
            if(cmbFilterBy.Text.Equals("L.D.L Application ID"))
            {
                column = "LocalDrivingLicenseApplicationID";
            }
            string searchValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(searchValue)) // Reset view
            {
                dv.RowFilter = "";
                lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
                return;
            }

            //Handel filtering by IDs
            if (dv.Table.Columns[column].DataType == typeof(int))
            {
                dv.RowFilter = $"CONVERT([{column}], System.String) LIKE '{searchValue}%'";
            }
            else
            {
                dv.RowFilter = $"[{column}] LIKE '{searchValue}%'";
            }

            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }

        private void cbLicenseClassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvApplications.DataSource;

            if (cbLicenseClassFilter.Text.Equals("All")) // Reset view
            {
                dv.RowFilter = "";
            }
            else
            {
                string LicenseClassName = cbLicenseClassFilter.Text;
                dv.RowFilter = $"[ClassName] LIKE '{LicenseClassName}%'";
            }

            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvApplications.DataSource;

            if (cbStatusFilter.Text.Equals("All")) // Reset view
            {
                dv.RowFilter = "";
            }
            else
            {
                string Status = cbStatusFilter.Text;
                dv.RowFilter = $"[ApplicationStatus] LIKE '{Status}%'";
            }

            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '@')
            {
                e.Handled = true;
            }

            //Allows only digits if filtering by IDs
            if (cmbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewLocalLicenseApplication frm = new frmAddNewLocalLicenseApplication();
            frm.ShowDialog();
            frmListLDLApplications_Load(null, null);
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmLocalLicenseApplicationInfo frm = new frmLocalLicenseApplicationInfo((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}

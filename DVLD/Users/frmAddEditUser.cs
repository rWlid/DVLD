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

namespace DVLD.Users
{
    public partial class frmAddEditUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        int _UserID;
        clsUser _User;
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add User";
                this.Text = "Add User";
                _User = new clsUser();
            }
            else
            {
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";
            }
            lblUserID.Text = "???";
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            cbIsActive.Checked = true;
            ctrlPersonInfoFilter1.ResetPersonInfo();
            tabPageLogin.Enabled = false;
        }
        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _UserID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _User.ID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            ctrlPersonInfoFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            
            if (_Mode == enMode.Update) 
            { 
                ctrlPersonInfoFilter1.FilterEnabled = false;
                tabPageLogin.Enabled = true;
                _LoadData();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please Select a Person to create User", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
            txtUserName.Focus();
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txt, null);
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Required field");
                e.Cancel = true;
            }
            else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords don't match");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) { return; }

            _User.PersonID = ctrlPersonInfoFilter1.PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";
                lblUserID.Text = _User.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Required field");
                e.Cancel = true;
            }
            else if (clsUser.IsUserNameExist(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This Username is Already Used");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }
        private void LetterOrDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) { e.Handled = true; }
        }
        private void ctrlPersonInfoFilter1_OnPersonSelected(int obj)
        {
            btnSave.Enabled = true;
            tabPageLogin.Enabled = true;
        }
    }
}

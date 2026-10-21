using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Users
{
    public partial class frmAddEditUser : Form
    {
        public enum Mode { AddNew = 0, Update = 1 }

        private Mode _mode;
        private readonly int _userID;
        private User _user;
        public frmAddEditUser()
        {
            InitializeComponent();
            _mode = Mode.AddNew;
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
            _mode = Mode.Update;
        }
        private void ResetDefaultValues()
        {
            if (_mode == Mode.AddNew)
            {
                lblFormTitle.Text = "Add User";
                Text = "Add User";
                _user = new User();
            }
            else
            {
                lblFormTitle.Text = "Update User";
                Text = "Update User";
            }
            lblUserID.Text = "???";
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbIsActive.Checked = true;
            ctrlPersonInfoFilter1.ResetPersonInfo();
            tabPageLogin.Enabled = false;
        }
        private void LoadData()
        {
            _user = User.FindByUserID(_userID);

            if (_user == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _userID,
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblUserID.Text = _user.ID.ToString();
            txtUserName.Text = _user.UserName;
            cbIsActive.Checked = _user.IsActive;
            ctrlPersonInfoFilter1.LoadPersonInfo(_user.PersonID);
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if (_mode == Mode.Update)
            {
                LoadData();
                ctrlPersonInfoFilter1.FilterEnabled = false;
                tabPageLogin.Enabled = true;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please Select a Person to create User", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_mode == Mode.AddNew && User.IsUserExistForPerson(ctrlPersonInfoFilter1.PersonID))
            {
                MessageBox.Show("Selected Person already has User", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
            txtUserName.Focus();
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) { return; }
            if (_mode == Mode.AddNew && User.IsUserExistForPerson(ctrlPersonInfoFilter1.PersonID))
            {
                MessageBox.Show("Selected Person already has User", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_mode == Mode.Update && !User.ValidateCredentials(_user.UserName, txtPassword.Text))
            {
                MessageBox.Show("Wrong Password.", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _user.PersonID = ctrlPersonInfoFilter1.PersonID;
            _user.UserName = txtUserName.Text;
            _user.Password = txtPassword.Text;
            _user.IsActive = cbIsActive.Checked;

            if (_user.Save())
            {
                _mode = Mode.Update;
                lblFormTitle.Text = "Update User";
                Text = "Update User";
                ctrlPersonInfoFilter1.FilterEnabled = false;
                lblUserID.Text = _user.ID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Globals.CurrentUser.ID == _user.ID) { Globals.CurrentUser = _user; }
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
            else if (!_user.UserName.ToLower().Equals(txtUserName.Text.ToLower()) && User.IsUserExist(txtUserName.Text))
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

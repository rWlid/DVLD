using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;
using DVLD.Users.Controls;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private readonly int _userID;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            if (User.ChangeUserPassword(ctrlUserInfo.UserID, txtCurrentPassword.Text, txtNewPassoword.Text))
            {
                MessageBox.Show("Password Changed Successfully", "Changed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Required field");
                e.Cancel = true;
            }
            else if (!txtConfirmPassword.Text.Equals(txtNewPassoword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords don't match");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) { e.Handled = true; }
        }
        private void frmChangePassowrd_Load(object sender, EventArgs e)
        {
            if (!ctrlUserInfo.LoadUserInfo(_userID))
            {
                MessageBox.Show("No User is found with ID: " + _userID);
                Close();
            }
        }
    }
}

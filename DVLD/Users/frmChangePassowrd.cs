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
using DVLD.Users.Controls;

namespace DVLD.Users
{
    public partial class frmChangePassowrd : Form
    {
        public frmChangePassowrd(int UserID)
        {
            InitializeComponent();
            if (!ctrlUserInfo.LoadPersonInfo(UserID))
            {
                MessageBox.Show("No User is found with ID: " + UserID);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            if (clsUser.ChangeUserPassword(ctrlUserInfo.UserID, txtCurrentPassword.Text, txtNewPassoword.Text))
            {
                MessageBox.Show("Password Changed Successfully","Changed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Users
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void LoadUser()
        {
            Globals.CurrentUser = User.Find(txtUsername.Text);
        }
        private void Login()
        {
            var frm = new frmMain();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) { return; }

            if (!User.ValidateCredentials(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Invalid Username or Password", "Wrong Credentials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadUser();

            if (!Globals.CurrentUser.IsActive)
            {
                MessageBox.Show("Your account is not active, Contact Admin", "inactive account",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbRememberUser.Checked)
            {
                Globals.StoreCredentials(txtUsername.Text, txtPassword.Text);
            }
            else
            {
                Globals.StoreCredentials("", "");
            }
            Hide();
            Login();
            Show();
            frmLogin_Load(null, null);

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
        private void LetterOrDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) { e.Handled = true; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            (txtUsername.Text, txtPassword.Text) = Globals.GetStoredCredentials();

            if (string.IsNullOrEmpty(txtUsername.Text))
            { cbRememberUser.Checked = false; }
            else
            { cbRememberUser.Checked = true; }
        }
    }
}

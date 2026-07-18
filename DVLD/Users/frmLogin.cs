using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void _LoadUser()
        {
            Globals.CurrentUser = clsUser.Find(txtUsername.Text);
        }
        private void _Login()
        {
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) { return; }

            if (!clsUser.ValidateCredintials(txtUsername.Text, txtPassword.Text))
            { MessageBox.Show("Invalid Username or Password", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            
            _LoadUser();
            
            if(!Globals.CurrentUser.IsActive)
            { MessageBox.Show("Your account is not active, Contact Admin", "inactive account", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (cbRememberUser.Checked) 
            {
                Globals.StoreCredintials(txtUsername.Text,txtPassword.Text);
            }else
            {
                Globals.StoreCredintials("", "");
            }
            this.Hide();
            _Login();
            this.Show();
            frmLogin_Load(null, null);

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
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
             (txtUsername.Text, txtPassword.Text) = Globals.GetStoredCredintials();

            if (string.IsNullOrEmpty(txtUsername.Text)) 
            { cbRememberUser.Checked = false; } 
            else 
            { cbRememberUser.Checked = true; }
        }
    }
}

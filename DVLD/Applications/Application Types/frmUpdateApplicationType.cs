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
using DVLD.People.Controls;

namespace DVLD.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _Application;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }
        private void _LoadData()
        {
            _Application = clsApplicationType.GetApplicationType(_ApplicationTypeID);

            if (_Application == null)
            {
                MessageBox.Show("This form will be closed because No Application Type with ID = " + _ApplicationTypeID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTypeID.Text = _ApplicationTypeID.ToString();
            txtTitle.Text = _Application.Title;
            txtFees.Text = _Application.Fees.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
            txtTitle.Focus();
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "Required field");
            }
            else
            {
                errorProvider1.SetError(txt, null);
            }
        }
        private void Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space) { e.Handled = true; }
        }
        private void Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (e.KeyChar == '.' && !txt.Text.Contains(".") && txt.Text.Length > 0)
            {
                return;
            }

            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) {  return; }

            _Application.Title = txtTitle.Text;
            _Application.Fees = decimal.TryParse(txtFees.Text, out decimal Fees) ? Fees : _Application.Fees;

            if (_Application.UpdateApplicationType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            
            _LoadData();
        }
    }
}

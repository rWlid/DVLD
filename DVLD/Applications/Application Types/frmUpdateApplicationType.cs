using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        private readonly int _applicationTypeID;
        private ApplicationType _application;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _applicationTypeID = ApplicationTypeID;
        }
        private void LoadData()
        {
            _application = ApplicationType.GetApplicationType(_applicationTypeID);

            if (_application == null)
            {
                MessageBox.Show("This form will be closed because No Application Type with ID = " + _applicationTypeID,
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblTypeID.Text = _applicationTypeID.ToString();
            txtTitle.Text = _application.Title;
            txtFees.Text = _application.Fees.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadData();
            txtTitle.Focus();
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
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
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = (TextBox)sender;

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
            if (!ValidateChildren()) { return; }

            _application.Title = txtTitle.Text;
            _application.Fees = decimal.TryParse(txtFees.Text, out decimal Fees) ? Fees : _application.Fees;

            if (_application.UpdateApplicationType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            LoadData();
        }
    }
}

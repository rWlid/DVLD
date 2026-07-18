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

namespace DVLD.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = (clsTestType.enTestType)TestTypeID;
        }
        private void _LoadData()
        {
            _TestType = clsTestType.Find((clsTestType.enTestType) _TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("This form will be closed because No Test Type with ID = " + _TestTypeID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTypeID.Text = ((int)_TestTypeID).ToString();
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = _TestType.Fees.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) { return; }

            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = decimal.TryParse(txtFees.Text, out decimal Fees) ? Fees : _TestType.Fees;

            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            _LoadData();
        }
    }
}

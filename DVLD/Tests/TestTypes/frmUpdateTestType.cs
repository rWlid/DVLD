using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private readonly TestType.TestKind _testTypeID;
        private TestType _testType;
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            _testTypeID = (TestType.TestKind)TestTypeID;
        }
        private void LoadData()
        {
            _testType = TestType.Find((TestType.TestKind)_testTypeID);

            if (_testType == null)
            {
                MessageBox.Show("This form will be closed because No Test Type with ID = " + _testTypeID,
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblTypeID.Text = ((int)_testTypeID).ToString();
            txtTitle.Text = _testType.Title;
            txtDescription.Text = _testType.Description;
            txtFees.Text = _testType.Fees.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) { return; }

            _testType.Title = txtTitle.Text;
            _testType.Description = txtDescription.Text;
            _testType.Fees = decimal.TryParse(txtFees.Text, out decimal Fees) ? Fees : _testType.Fees;

            if (_testType.UpdateTestType())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Data is not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            LoadData();
        }
    }
}

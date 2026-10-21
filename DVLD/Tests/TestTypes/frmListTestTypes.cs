using System;
using System.Data;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Tests.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void dgvTestTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTestTypes.Rows.Count <= 0) { return; }

            dgvTestTypes.Columns["ID"].Width = 50;
            dgvTestTypes.Columns["Title"].Width = 250;
            dgvTestTypes.Columns["Description"].Width = 300;
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = TestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblNumberOfRecords.Text = dgvTestTypes.RowCount.ToString();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageTestTypes_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

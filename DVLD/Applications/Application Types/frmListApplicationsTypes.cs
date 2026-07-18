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

namespace DVLD.Applications
{
    public partial class frmListApplicationsTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmListApplicationsTypes()
        {
            InitializeComponent();
        }

        private void dgvApplicationsTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvApplicationTypes.Rows.Count <= 0) { return; }

            dgvApplicationTypes.Columns["Title"].Width = 250;
        }

        private void frmManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblNumberOfRecords.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationsTypes_Load(null, null);
        }
    }
}

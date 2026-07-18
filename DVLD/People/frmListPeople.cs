using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BL;
using DVLD.People;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }
        private void _RefreshPeopleList()
        {
            dgvAllPeople.DataSource = clsPerson.GetAllPeople().DefaultView;
            lblNumberOfRecords.Text = dgvAllPeople.RowCount.ToString();
        }
        private void FeatureStubError(object sender, EventArgs e) { MessageBox.Show("This feature is not implemented yet", "Try agian later", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning); }
        private void dgvAllPeople_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAllPeople.Rows.Count <= 0) { return; }
            dgvAllPeople.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllPeople.Columns["NationalNo"].HeaderText = "National No";
            dgvAllPeople.Columns["FirstName"].HeaderText = "First Name";
            dgvAllPeople.Columns["SecondName"].HeaderText = "Second Name";
            dgvAllPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dgvAllPeople.Columns["LastName"].HeaderText = "Last Name";
            dgvAllPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cmbFilterBy.SelectedIndex = 0;
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvAllPeople.DataSource;

            string column = cmbFilterBy.Text.Replace(" ", ""); // "Person ID" → "PersonID"
            string searchValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(searchValue)) // Reset view
            {
                dv.RowFilter = "";
                lblNumberOfRecords.Text = dgvAllPeople.RowCount.ToString();
                return;
            }

            if (dv.Table.Columns[column].DataType == typeof(int))
            {
                dv.RowFilter = $"CONVERT([{column}], System.String) LIKE '{searchValue}%'";
            }
            else
            {
                dv.RowFilter = $"[{column}] LIKE '{searchValue}%'";
            }

            lblNumberOfRecords.Text = dgvAllPeople.RowCount.ToString();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex != 0)
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }
            else
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();
            }
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '@')
            {
                e.Handled = true;
            }

            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 9)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowPersonDetails(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();

        }
        private void AddNewPerson(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete person [{dgvAllPeople.CurrentRow.Cells[0].Value}]?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                //Perform Delete and refresh
                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
        private void tsmEditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
    }
}

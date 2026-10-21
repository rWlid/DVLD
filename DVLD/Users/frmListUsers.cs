using System;
using System.Data;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Users
{
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }
        private void FeatureStubError(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet", "Try agian later",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
        }
        private void dgvAllUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAllUsers.Rows.Count <= 0) { return; }

            dgvAllUsers.Columns["UserID"].HeaderText = "User ID";
            dgvAllUsers.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllUsers.Columns["FullName"].HeaderText = "Full Name";
            dgvAllUsers.Columns["FullName"].Width = 250;
            dgvAllUsers.Columns["UserName"].HeaderText = "User Name";
            dgvAllUsers.Columns["IsActive"].HeaderText = "Is Active";
            dgvAllUsers.Columns["IsActive"].Width = 60;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            dgvAllUsers.DataSource = User.GettAllUsers().DefaultView;
            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
            cmbFilterBy.SelectedIndex = 0;
        }
        private void ShowUserDetails(object sender, EventArgs e)
        {
            var frm = new frmUserDetails(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            frmManageUsers_Load(null, null);

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            var dv = (DataView)dgvAllUsers.DataSource;

            string column = cmbFilterBy.Text.Replace(" ", ""); // "Person ID" → "PersonID"
            string searchValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(searchValue)) // Reset view
            {
                dv.RowFilter = "";
                lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
                return;
            }

            //Handel filtering by IDs
            if (dv.Table.Columns[column].DataType == typeof(int))
            {
                dv.RowFilter = $"CONVERT([{column}], System.String) LIKE '{searchValue}%'";
            }
            else
            {
                dv.RowFilter = $"[{column}] LIKE '{searchValue}%'";
            }

            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void cmbActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dv = (DataView)dgvAllUsers.DataSource;

            switch (cmbActiveFilter.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = "";
                    break;
                case 1:
                    dv.RowFilter = "IsActive";
                    break;
                case 2:
                    dv.RowFilter = "NOT IsActive";
                    break;

            }

            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFilterBy.Text.Equals("Is Active"))
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                cmbActiveFilter.Visible = true;
                cmbActiveFilter.SelectedIndex = 0;
                cmbActiveFilter.Focus();
            }
            else
            {
                cmbActiveFilter.Visible = false;
                cmbActiveFilter.SelectedIndex = 0;

                txtFilterValue.Visible = cmbFilterBy.SelectedIndex != 0;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back
                && e.KeyChar != ' ' && e.KeyChar != '@')
            {
                e.Handled = true;
            }

            //Allows only digits if filtering by IDs
            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 3)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new frmAddEditUser();
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void tsmiEditUser_Click(object sender, EventArgs e)
        {
            var frm = new frmAddEditUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void tsmiDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete user " +
                $"[{dgvAllUsers.CurrentRow.Cells[0].Value}]?", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)

            {
                //Perform Delete and refresh
                if (User.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageUsers_Load(null, null);
                }

                else
                {
                    MessageBox.Show("User was not deleted because it has data linked to it", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiChangePass_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}

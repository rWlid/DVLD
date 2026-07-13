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
using DVLD.People;

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private void _RefreshUsersList()
        {
            dgvAllUsers.DataSource = clsUser.GettAllUsers().DefaultView;

            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void FeatureStubError(object sender, EventArgs e) { MessageBox.Show("This feature is not implemented yet", "Try agian later", MessageBoxButtons.OK, icon: MessageBoxIcon.Warning); }
        private void dgvAllUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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
            _RefreshUsersList();
            cmbFilterBy.SelectedIndex = 0;
        }
        private void ShowUserDetails(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);

            frmUserDetails frm = new frmUserDetails(UserID);
            frm.ShowDialog();
            _RefreshUsersList();

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvAllUsers.DataSource;

            string column = cmbFilterBy.Text.Replace(" ", ""); // "Person ID" → "PersonID"
            string searchValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(searchValue)) // Reset view
            {
                dv.RowFilter = "";
                lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
                return;
            }

            dv.RowFilter = $"[{column}] LIKE '{searchValue}%'";
            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void cmbActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvAllUsers.DataSource;

            switch (cmbActiveFilter.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = "";
                    break;
                case 1:
                    dv.RowFilter = "IsActive = true";
                    break;
                case 2:
                    dv.RowFilter = "IsActive = false";
                    break;

            }
            lblNumberOfRecords.Text = dgvAllUsers.RowCount.ToString();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 0 )
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                cmbActiveFilter.Visible = false;
                cmbActiveFilter.SelectedIndex = 0;
            }
            else if (cmbFilterBy.SelectedIndex == 5)
            {
                txtFilterValue.Visible = false;

                cmbActiveFilter.Visible = true;
                cmbActiveFilter.SelectedIndex = 0;
            }
            else
            {
                cmbActiveFilter.Visible = false;

                txtFilterValue.Visible = true;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '@')
            {
                e.Handled = true;
            }

            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 3)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void tsmiEditUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void tsmiDeleteUser_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);
            if (MessageBox.Show($"Are you sure you want to delete user [{UserID}]?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                //Perform Delete and refresh
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsmiChangePass_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);
            frmChangePassowrd frm = new frmChangePassowrd(UserID);
            frm.ShowDialog();
        }
    }
}

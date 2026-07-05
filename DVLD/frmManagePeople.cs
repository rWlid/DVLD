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

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dgvAllPeople.DataSource = clsPerson.GetAllPeople().DefaultView;
        }
        private void dgvAllPeople_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAllPeople.Columns["PersonID"].HeaderText = "Person ID";
            dgvAllPeople.Columns["NationalNo"].HeaderText = "National No";
            dgvAllPeople.Columns["FirstName"].HeaderText = "First Name";
            dgvAllPeople.Columns["SecondName"].HeaderText = "Second Name";
            dgvAllPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dgvAllPeople.Columns["LastName"].HeaderText = "Last Name";
            dgvAllPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvAllPeople.Columns["Phone"].HeaderText = "Phone";
            dgvAllPeople.Columns["Email"].HeaderText = "Email";
            dgvAllPeople.Columns["CountryName"].HeaderText = "Nationality";

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cmbFilterBy.SelectedIndex = 0;
        }

        private void tBFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)dgvAllPeople.DataSource;

            string column = cmbFilterBy.Text.Replace(" ", ""); // "Person ID" → "PersonID"
            string searchValue = tBFilter.Text.Trim();

            if (string.IsNullOrEmpty(searchValue)) // Reset view
            {
                dv.RowFilter = "";
                return;
            }

            dv.RowFilter = $"[{column}] LIKE '{searchValue}%'";
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex != 0)
            {
                tBFilter.Visible = true;
            }
            else
            {
                tBFilter.Visible = false;
            }
        }
    }
}

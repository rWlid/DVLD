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
        private void _FilterBy(string column,string filter)
        {
            DataView dv = (DataView)dgvAllPeople.DataSource;
            dv.RowFilter = $"{column} = {filter}";
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
            if (cmbFilterBy.SelectedIndex != 0 && tBFilter.Text != string.Empty)
            {
                _FilterBy(cmbFilterBy.Text.Replace(" ",""),tBFilter.Text);

            }
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex != 0)
            {
                tBFilter.Visible = true;
            }
        }
    }
}

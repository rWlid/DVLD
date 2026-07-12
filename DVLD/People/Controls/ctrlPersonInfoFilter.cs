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
    public partial class ctrlPersonInfoFilter : UserControl
    {
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get {  return _ShowAddPerson; }
            set 
            { 
                _ShowAddPerson = value;
                btnAdd.Enabled = _ShowAddPerson;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonInfo.SelectedPersonInfo; }
        }
        public ctrlPersonInfoFilter()
        {
            InitializeComponent();
        }
        public void Find()
        {
            switch (cmbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInfo.LoadPersonInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    ctrlPersonInfo.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }
        }
        public void LoadPersonInfo(int PersonID)
        {
            cmbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            btnFind.PerformClick();
        }
        private void tBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnFind.PerformClick();
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (cmbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }

        private void btnPersonLookUp_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            Find();
        }

        private void tBFilter_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text)) 
            { 
                e.Cancel = true;
                txtFilterValue.Focus();
                return;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        private void ctrlPersonInfoFilter_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
    }
}

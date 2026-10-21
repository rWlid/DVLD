using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonInfoFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            if (!FilterEnabled) { return; }
            OnPersonSelected?.Invoke(PersonID); // Raise the event with the parameter
        }
        //private bool _ShowAddPerson = true;
        //public bool ShowAddPerson
        //{
        //    get {  return _ShowAddPerson; }
        //    set 
        //    { 
        //        _ShowAddPerson = value;
        //        btnAdd.Enabled = _ShowAddPerson;
        //    }
        //}
        private bool _filterEnabled = true;
        public bool FilterEnabled
        {
            get { return _filterEnabled; }
            set
            {
                _filterEnabled = value;
                gbFilter.Enabled = _filterEnabled;
            }
        }
        public int PersonID
        {
            get { return ctrlPersonInfo.SelectedPersonInfo.ID; }
        }
        public Person SelectedPersonInfo
        {
            get { return ctrlPersonInfo.SelectedPersonInfo; }
        }
        public ctrlPersonInfoFilter()
        {
            InitializeComponent();
        }
        public void ResetPersonInfo()
        {
            ctrlPersonInfo.ResetPersonInfo();

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
            //raise event
            PersonSelected(ctrlPersonInfo.PersonID);
        }
        public void LoadPersonInfo(int PersonID)
        {
            cmbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            btnFind.PerformClick();


        }
        public void LoadPersonInfo(Person Person)
        {
            cmbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = Person.ID.ToString();

            ctrlPersonInfo.LoadPersonInfo(Person);
            //raise event
            PersonSelected(ctrlPersonInfo.PersonID);
        }
        private void tBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
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
            if (!ValidateChildren())
            {
                return;
            }

            Find();
        }

        private void tBFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                e.Cancel = true;
                txtFilterValue.Focus();
                return;
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            var frm = new frmAddEditPerson();
            frm.DataBack += ReciveNewPersonID;
            frm.ShowDialog();
        }
        private void ReciveNewPersonID(object sender, int PersonID)
        {
            if (PersonID != -1)
            {
                LoadPersonInfo(PersonID);
            }
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

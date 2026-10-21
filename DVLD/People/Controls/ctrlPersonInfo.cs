using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DVLD.BL;
using DVLD.Properties;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonInfo : UserControl
    {
        private Person _person;

        private int _personID = -1;
        public int PersonID
        {
            get { return _personID; }
        }
        public Person SelectedPersonInfo
        {
            get { return _person; }
        }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        private void SetDefaultImage()
        {
            pbPersonPicture.Image = _person.Gender == 0
                ? (Image)DVLD.Properties.Resources.Male_512.Clone()
                : (Image)DVLD.Properties.Resources.Female_512.Clone();
        }
        private void LoadPersonImage()
        {
            if (!string.IsNullOrEmpty(_person.ImagePath) && File.Exists(_person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _person.ImagePath;
            }
            else { SetDefaultImage(); }
        }
        private void LoadData()
        {
            llblEditPersonInfo.Enabled = true;
            _personID = _person.ID;
            lblPersonID.Text = _person.ID.ToString();
            lblFullName.Text = _person.FullName;
            lblNationalNo.Text = _person.NationalNo;
            if (_person.Gender == 0)
            {
                lblGender.Text = "Male";
                lblGenderIcon.Image = (Image)DVLD.Properties.Resources.Man_32.Clone();
            }
            else
            {
                lblGender.Text = "Female";
                lblGenderIcon.Image = (Image)DVLD.Properties.Resources.Woman_32.Clone();
            }
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblDOB.Text = _person.DateOfBirth.ToString("dd/MM/yyyy");
            lblPhone.Text = _person.Phone;
            lblCountry.Text = _person.CountryInfo.CountryName;
            LoadPersonImage();
        }
        public void ResetPersonInfo()
        {
            _personID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGenderIcon.Image = Resources.Man_32;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDOB.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonPicture.Image = Resources.Male_512;

        }
        public bool LoadPersonInfo(int PersonID)
        {
            _person = Person.Find(PersonID);

            if (_person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with ID: " + PersonID.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoadData();
            return true;
        }
        public bool LoadPersonInfo(string NationalNo)
        {
            _person = Person.Find(NationalNo);

            if (_person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National Number: " + NationalNo.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoadData();
            return true;
        }
        public bool LoadPersonInfo(Person person)
        {
            _person = person;

            if (_person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National Number: " + person.NationalNo.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoadData();
            return true;
        }
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmAddEditPerson(_person.ID);
            frm.ShowDialog();

            //Load new edited data
            LoadPersonInfo(_person.ID);
        }
    }
}

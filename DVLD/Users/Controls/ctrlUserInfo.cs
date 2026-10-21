using System.Windows.Forms;
using DVLD.BL;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        private User _user;
        private int _userID;
        public int UserID
        {
            get { return _userID; }
        }
        public User SelectedUserInfo
        {
            get { return _user; }
        }
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        private void FillUserInfo()
        {
            _userID = _user.ID;
            lblUserID.Text = _user.ID.ToString();
            lblUserName.Text = _user.UserName;
            lblIsActive.Text = _user.IsActive ? "Yes" : "No";
            ctrlPersonInfo.LoadPersonInfo(_user.PersonID);
        }
        private void ResetUserInfo()
        {
            _userID = -1;
            lblUserID.Text = "??";
            lblUserName.Text = "???";
            lblIsActive.Text = "??";

        }
        public bool LoadUserInfo(int UserID)
        {
            _user = User.FindByUserID(UserID);

            if (_user == null)
            {
                ResetUserInfo();
                MessageBox.Show("No User with ID: " + UserID.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            FillUserInfo();
            return true;
        }
    }
}

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
using DVLD.Properties;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        private clsUser _User;
        private int _UserID;
        public int UserID 
        {
            get { return _UserID; }
        }
        public clsUser SelectedUserInfo
        {
            get { return _User; }
        }
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        private void _FillUserInfo()
        {
            _UserID = _User.ID;
            lblUserID.Text = _User.ID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
            ctrlPersonInfo.LoadPersonInfo(_User.PersonID);
        }
        private void _ResetUserInfo()
        {
            _UserID = -1;
            lblUserID.Text = "??";
            lblUserName.Text = "???";
            lblIsActive.Text = "??";

        }
        public bool LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with ID: " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _FillUserInfo();
            return true;
        }
    }
}

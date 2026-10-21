using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmUserDetails : Form
    {
        private readonly int _userID;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (!ctrlUserInfo.LoadUserInfo(_userID))
            {
                MessageBox.Show("No User is found with ID: " + _userID);
                Close();
            }
        }
    }
}

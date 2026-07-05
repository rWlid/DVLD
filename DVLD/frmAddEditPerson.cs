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
    public partial class frmAddEditPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        int _PersonID;
        clsPerson _Person;
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if(_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }

        }
    }
}

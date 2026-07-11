using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonInfoFilter : UserControl
    {
        public ctrlPersonInfoFilter()
        {
            InitializeComponent();
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
                tBFilter.Clear();
            }
        }
        private void tBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '@')
            {
                e.Handled = true;
            }

            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 9)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
        }
    }
}

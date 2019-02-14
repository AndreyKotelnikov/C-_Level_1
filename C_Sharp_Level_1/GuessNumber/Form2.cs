using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form2 : Form
    {
        Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1, int x, int y)
        {
            InitializeComponent();
            this.form1 = form1;
            SetDesktopLocation(x + 500, y + 30);
            tbUserNumberValue.Focus();
        }

        private void tbUserNumberValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
            }
            else if (ch == (char)Keys.Enter && tbUserNumberValue.Text.Length > 0)
            {
                form1.SetUserNumber(tbUserNumberValue.Text);
                e.Handled = true;
            }
        }

        internal void tbUserNumberClear()
        {
            tbUserNumberValue.Text = string.Empty;
        }
    }
}

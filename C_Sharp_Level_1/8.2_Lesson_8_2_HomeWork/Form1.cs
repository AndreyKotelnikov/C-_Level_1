using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8._2_Lesson_8_2_HomeWork
{
    //Андрей Котельников
    //2. Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством Value элемента NumericUpDown
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tb1Value.Text = nud1Value.Value.ToString();
        }

        private void nud1Value_ValueChanged(object sender, EventArgs e)
        {
            tb1Value.Text = nud1Value.Value.ToString();
        }
    }
}

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

    //2.	Используя Windows Forms, разработать игру «Угадай число». 
    //Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
    //Компьютер говорит, больше или меньше загаданное число введенного.
    //a) Для ввода данных от человека используется элемент TextBox;

    public partial class Form1 : Form
    {
        Repository rep;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            rep = new Repository(this);
            tbHello.Visible = false;
            btnStart.Visible = false;
            lblNumberTitle.Visible = true;
            lblTryCount.Visible = true;
            lblTryCountValue.Visible = true;
            tbMessage.Visible = true;
            cbSeparateForm.Visible = false;

            //2. б) **Реализовать отдельную форму c TextBox для ввода числа.
            if (cbSeparateForm.CheckState != CheckState.Checked)
            {
                lblUserNumber.Visible = true;
                tbUserNumberValue.Visible = true;
                tbUserNumberValue.Focus();
            } else
            {
                form2 = new Form2(this, Location.X, Location.Y);
                form2.Show();
            }

            lblTryCountValue.Text = rep.TryCount.ToString();
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
                rep.UserNumber = int.Parse(tbUserNumberValue.Text);
                rep.CheckUserAnswer();
                e.Handled = true;
            }
        }

        public void SetUserNumber(string number)
        {
            rep.UserNumber = int.Parse(number);
            rep.CheckUserAnswer();
        }

        public void FilltbMessage(int arg)
        {
            if (cbSeparateForm.CheckState != CheckState.Checked) { tbUserNumberValue.Text = string.Empty; }
            else { form2.tbUserNumberClear(); }
            
            lblTryCountValue.Text = rep.TryCount.ToString();

            switch (arg)
            {
                case 0:
                    tbMessage.Text = "Нужно указать число в диапазоне от 0 до 100";
                    break;
                case 1:
                    tbMessage.Text = "Вы указали слишком большое число";
                    break;
                case -1:
                    tbMessage.Text = "Вы указали слишком маленькое число";
                    break;
                default:
                    tbMessage.Text = "Непонятная ситуация - обратитесь в тех. поддержку";
                    break;
            }
            
        }

        internal void UserWin(int tryCount)
        {
            lblTryCountValue.Text = rep.TryCount.ToString();
            tbMessage.Text = $"Поздравляю! Вы угадали число за {tryCount} попыток!";

            if (cbSeparateForm.CheckState != CheckState.Checked) { tbUserNumberValue.Enabled = false; }
            else
            {
                lblUserNumber.Visible = true;
                tbUserNumberValue.Visible = true;
                tbUserNumberValue.Text = rep.UserNumber.ToString();
                tbUserNumberValue.Enabled = false;
                form2.Close();
            }
            
        }
    }
}

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
            lblUserNumber.Visible = true;
            tbUserNumberValue.Visible = true;
            tbMessage.Visible = true;

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
            }
        }

        public void FilltbMessage(int arg)
        {
            tbUserNumberValue.Text = string.Empty;
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
            tbUserNumberValue.Enabled = false;
        }
    }
}

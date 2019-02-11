using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            BtnClick();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            BtnClick();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = 1.ToString();
            BtnClick();
        }

        //1. а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
        private void BtnClick()
        {
            Udvoitel.ComandCounter++;
            lblComandCounterValue.Text = Udvoitel.ComandCounter.ToString();
            Udvoitel.CheckNumber(lblNumber.Text);
            Udvoitel.LastMove = int.Parse(lblNumber.Text);
        }

        //б) Добавить меню и команду «Играть». 
        //При нажатии появляется сообщение, какое число должен получить игрок.
        //Игрок должен получить это число за минимальное количество ходов.
        private void MenuItemPlay_Click(object sender, EventArgs e)
        {
            Udvoitel.SetNewNumberForPlay();
            MessageBox.Show($"Загадано число {Udvoitel.NumberForPlay}." +
                $"\nВы должны получить это число за минимальное количество ходов.", "Правила игры", MessageBoxButtons.OK);
            lblNumberForPlay.Visible = true;
            lblNumberForPlayValue.Visible = true;
            lblNumberForPlayValue.Text = Udvoitel.NumberForPlay.ToString();
            Udvoitel.ComandCounter = 0;
            lblComandCounterValue.Text = Udvoitel.ComandCounter.ToString();
            lblComandCounter.Text = "Количество ходов:";
            lblNumber.Text = 0.ToString();
            Udvoitel.ClearHistory();
        }

        public void PlayEnd()
        {
            MessageBox.Show($"Поздравляю, Вы добрались до нужного числа за {Udvoitel.ComandCounter} ходов.",
                "Конец игры", MessageBoxButtons.OK);
            lblNumberForPlay.Visible = false;
            lblNumberForPlayValue.Visible =false;
            lblComandCounterValue.Text = Udvoitel.ComandCounter.ToString();
            lblComandCounter.Text = "Счётчик команд:";
            lblNumber.Text = 0.ToString();
        }

        //в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
        //Вся логика игры должна быть реализована в классе с удвоителем.
        private void btnСancelMove_Click(object sender, EventArgs e)
        {
            lblNumber.Text = Udvoitel.LastMove.ToString();
        }
    }
}

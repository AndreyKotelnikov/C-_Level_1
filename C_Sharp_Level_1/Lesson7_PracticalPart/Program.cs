using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7_PracticalPart
{
    class Program
    {
        static void BtnClick(object o, EventArgs e)
        {
            MessageBox.Show($"Привет, {text.Text}!");
        }

        static TextBox text = new TextBox();

        static void Main(string[] args)
        {
            Form f = new Form();
            Button button = new Button();
            button.Left = 50;
            button.Top = 50;
            button.Text = "Жми меня";
            button.Click += BtnClick;
            f.Controls.Add(button);
            f.Controls.Add(text);

            f.Show();
            Application.Run(f);
            
        }
    }
}

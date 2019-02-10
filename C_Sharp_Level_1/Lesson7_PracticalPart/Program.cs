using System;
using System.Collections.Generic;
using System.Drawing;
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
            MessageBox.Show($"Привет, {text.Text}!", "Заголовок", MessageBoxButtons.OKCancel);
        }

        static TextBox text = new TextBox();

        static void Main(string[] args)
        {
            //Form f = new Form();
            //Button button = new Button();
            //button.Left = 50;
            //button.Top = 50;
            //button.Text = "Жми меня";
            //button.Click += BtnClick;
            //f.Controls.Add(button);
            //f.Controls.Add(text);

            //f.Show();
            //Application.Run(f);

            //Form form1 = new Form();
            //Form form2 = new Form();
            //form1.Text = "Эта форма запущена с использованием метода Run класса Application";
            //form2.Text = "Это форма для демонстрации возможности создавать несколько форм";
            //form2.Show();
            //Application.Run(form1);
            //MessageBox.Show("Application.Run() вернул " +
            //"управление в метод Main. До свидания", "Приложение \"Две формы\"");

            //Form form = new Form();
            //form.Text = "Событие Click";
            //// У формы есть событие Click
            //// в System.Windows.Form описан делегат EventHandler(Обработчик события),
            //// который описывает сигнатуру методов, которые можно подключать на событие
            //// Можно записать просто Form_Click
            //form.Click += new EventHandler(Form_Click);
            //Application.Run(form);

            Form form = new Form();
            form.Text = "Событие Paint";
            // У формы есть событие Paint,
            // в System.Windows.Form описан делегат PaintEventHandler,
            // который описывает сигнатуру методов, которые можно подключать на событие
            //Создаем делегат и указываем, что он указывает на метод MyPaintHandler

            form.Paint += new PaintEventHandler(MyPaintHandler);
            Application.Run(form);

        }

        private static void Form_Click(object sender, EventArgs e)
        {
            // Посмотрим, что же вызывало событие
            Console.WriteLine(sender.ToString());
            Console.WriteLine(e.GetType());
            MessageBox.Show("Щелкнули по форме!", "Щелк");
        }

        static void MyPaintHandler(object objSender, PaintEventArgs pea)
        {
            // Получаем ссылку на класс Graphics, в котором содержатся поля и методы для рисования на форме
            Graphics grfx = pea.Graphics;
            // Очищаем форму, закрашивая ее цветом
            grfx.Clear(Color.Chocolate);
            // Будем в заголовке окна менять время, чтобы лучше понять, когда же срабатывает это событие
            (objSender as Form).Text = DateTime.Now.ToLongTimeString();
            // А также посмотрим, что же вызывает это событие
            Console.WriteLine(objSender.ToString());
        }


    }
}

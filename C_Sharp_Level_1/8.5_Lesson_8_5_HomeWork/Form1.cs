using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson6_HomeWork;
using System.IO;

namespace _8._5_Lesson_8_5_HomeWork
{
    //5.	** Написать программу-преобразователь из CSV в XML-файл с информацией о студентах(6 урок).
    public partial class Form1 : Form
    {
        List<Student> listStudents;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            string str = btnOpenCSV.BackColor.ToString();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Таблица с данными (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listStudents = new List<Student>();
                Student.FileNameCSV =ofd.FileName;
                int bakalavr, magistr;
                try { listStudents = Student.LoadListOfStudents(Student.FileNameCSV, out bakalavr, out magistr); }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message, "Ошибка при загрузки файла:", MessageBoxButtons.OK);
                    btnOpenCSV.BackColor = Color.Red;
                    return;
                }
                btnOpenCSV.BackColor = Color.Green;
                btnConvert.BackColor = Color.FromName("Control");
                btnOpenXML.BackColor = Color.FromName("Control");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (listStudents == null) { return; }
            Student.FileNameXML = Student.FileNameCSV.Replace(".csv", ".txt");
            try { Student.SaveXML(listStudents); }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Ошибка при сохранении файла:", MessageBoxButtons.OK);
                btnConvert.BackColor = Color.Red;
                return;
            }
            btnConvert.BackColor = Color.Green;
        }

        private void btnOpenXML_Click(object sender, EventArgs e)
        {
            if (listStudents == null) { return; }
            if (btnConvert.BackColor == Color.FromName("Control"))
            {
                MessageBox.Show("Сначала нужно нажать кнопку \"Конвертировать\"", "Порядок действий:", MessageBoxButtons.OK);
                return;
            }
            try
            {
                if (!File.Exists(Student.FileNameXML))
                { throw new Exception("Нужный файл не найден - была ошибка при сериализации списка Студентов"); }
                Process proc = Process.Start("notepad.exe", Student.FileNameXML);
                proc.WaitForExit();
                proc.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Ошибка при открытии файла XML в блокноте:", MessageBoxButtons.OK);
                btnOpenXML.BackColor = Color.Red;
                return;
            }
            MessageBox.Show("Вы убедились, что Преобразование работает.");
            btnOpenXML.BackColor = Color.Green;
        }
    }
}

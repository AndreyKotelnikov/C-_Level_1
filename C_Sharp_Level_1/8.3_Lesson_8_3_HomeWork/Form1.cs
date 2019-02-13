using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8._3_Lesson_8_3_HomeWork
{

    //Андрей Котельников
    //3.	а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок 
    //(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    //б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов 
    //и добавив другие «косметические» улучшения на свое усмотрение.
    //в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    //г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).

    public partial class Form1 : Form
    {
        // База данных с вопросами
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
            nudNumber.Minimum = 0;
            nudNumber.Maximum = 0;
        }
        // Обработчик пункта меню Exit
        private void MiExit_Click(object sender, EventArgs e)
        {
            if (database.IsChanged)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохранённые изменения.\nСохранить изменения в файл перед выходом?",
                    "Сохранить изменения перед выходом?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) { miSave_Click(null, null); }
                else if (result == DialogResult.Cancel) { return; }
            }
            Close();
        }
        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add(tboxQuestion.Text, cboxTrue.Checked);
                try { database.Save(); }
                catch (Exception) { return; }
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                database.CurrentIndex = (int)nudNumber.Value - 1;
                tboxQuestion.Focus();
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, ((sender as NumericUpDown).Focused == true)? null : e))
            {
                tboxQuestion.Focus();
                nudNumber.Value = database.CurrentIndex + 1;
                return;
            }
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            database.CurrentIndex = (int)nudNumber.Value - 1;
            tboxQuestion.Focus();
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { nudNumber.Value = database.CurrentIndex + 1; return; }
            database.Add(string.Empty, false);
            tboxQuestion.Text = string.Empty;
            cboxTrue.Checked = false;
            database.CurrentIndex = database.Count - 1;
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            tboxQuestion.Focus();
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null)
            {
                tboxQuestion.Text = string.Empty;
                cboxTrue.Checked = false;
                return;
            }

            database.Remove((int)nudNumber.Value - 1);

            if ((int)nudNumber.Value > database.Count)
            {
                database.CurrentIndex--;
                nudNumber.Value = database.CurrentIndex + 1;
                
            } 
            nudNumber.Maximum--;
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            tboxQuestion.Focus();
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { return; }
            try { database.Save(); }
            catch (Exception) { return; }
            database.IsChanged = false;
        }
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                try { database.Load(); }
                catch (Exception) { return; }
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
                tboxQuestion.Focus();
            }
        }
        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { return; }
            database[database.CurrentIndex].text = tboxQuestion.Text;
            database[database.CurrentIndex].trueFalse = cboxTrue.Checked;
            database.IsChanged = true;
            tboxQuestion.Focus();
        }

        //Делаем проверки на заполнение текста вопроса и его сохранения в database     
        private bool CheckCurrentQuestion(object sender, EventArgs e)
        {
            if (database == null) { MessageBox.Show("База данных не создана"); return false; }
            if (sender != null && sender.GetType() == typeof(ToolStripMenuItem)) { return true; }

            if (tboxQuestion.Text == string.Empty && e != EventArgs.Empty)
            {
                MessageBox.Show("Введите текст в текущий вопрос", "Пустой текст вопроса", MessageBoxButtons.OK);
                return false;
            }
            if (sender != null && sender.GetType() == typeof(Button) && (sender as Button).Name == btnSaveQuest.Name) { return true; }

            if (database[database.CurrentIndex].text == string.Empty && tboxQuestion.Text != string.Empty && e != EventArgs.Empty)
            {
                if (DialogResult.Yes != MessageBox.Show(
                    "Для перехода на другой вопрос, нужно сохранить текущий.\nСохранить этот вопрос?",
                    "Сохранить текущий вопрос?", MessageBoxButtons.YesNo)) { return false; }
                else { btnSaveQuest_Click(null, EventArgs.Empty); return true; }
            }
            if ((database[database.CurrentIndex].text != tboxQuestion.Text ||
                database[database.CurrentIndex].trueFalse != cboxTrue.Checked) && e != EventArgs.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Текущий вопрос был изменён.\nСохранить изменения?",
                    "Сохранить изменения?", MessageBoxButtons.YesNo)) { btnSaveQuest_Click(null, EventArgs.Empty); return true; }
            }
            return true;
        }

        private void miAboutProgramm_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { return; }
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database.FileName = sfd.FileName;
                try { database.Save(); }
                catch (Exception) { return; }
                tboxQuestion.Focus();
            };
        }
    }
}

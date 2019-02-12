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
        }
        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
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
                database.Add(string.Empty, false);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database == null) { return; }
            if (!CheckSaveCurrentQuestion())
            {
                if (DialogResult.Yes != MessageBox.Show(
                    "Для перехода на другой вопрос, нужно сохранить или удалить текущий.\nСохранить этот вопрос?",
                    "Сохранить текущий вопрос?", MessageBoxButtons.YesNo)) { return; }
                else { btnSaveQuest_Click(null, null); }
            }
            if (!CheckChangesInCurrentQuestion())
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Текущий вопрос был изменён.\nСохранить изменения?",
                    "Сохранить изменения?", MessageBoxButtons.YesNo)) { btnSaveQuest_Click(null, null); }
            }
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            if (!CheckSaveCurrentQuestion())
            {
                if (DialogResult.Yes != MessageBox.Show(
                    "Для создания нового вопроса нужно сохранить текущий.\nСохранить этот вопрос?",
                    "Сохранить текущий вопрос?", MessageBoxButtons.YesNo)) { return; }
                else { btnSaveQuest_Click(null, null); }
            }
            if (!CheckChangesInCurrentQuestion())
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Текущий вопрос был изменён.\nСохранить изменения?",
                    "Сохранить изменения?", MessageBoxButtons.YesNo)) { btnSaveQuest_Click(null, null); }
            }
            database.Add(string.Empty, false);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            tboxQuestion.Text = string.Empty;
            cboxTrue.Checked = false;
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
                database.IsChanged = false;
            }
            else MessageBox.Show("База данных не создана");
        }
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
        }
        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (database == null) { MessageBox.Show("База данных не создана"); return; }
            if (!CheckChangesInCurrentQuestion())
            {
                database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
                database.IsChanged = true;
            }
        }

        //Проверка на сохранение нового вопроса в database
        private bool CheckSaveCurrentQuestion()
        {
            return (database[(int)nudNumber.Value - 1].text == string.Empty) ? false : true; 
        }

        //Проверка на изменение текста вопроса и признака trueFalse 
        private bool CheckChangesInCurrentQuestion()
        {
            return (database[(int)nudNumber.Value - 1].text != tboxQuestion.Text ||
                database[(int)nudNumber.Value - 1].trueFalse != cboxTrue.Checked) ? false : true;
        }
    }
}

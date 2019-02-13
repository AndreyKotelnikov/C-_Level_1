using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8._4_Lesson_8_4_HomeWork
{

    //Андрей Котельников
    //4.	*Используя полученные знания и класс TrueFalse в качестве шаблона, 
    //разработать собственную утилиту хранения данных 
    //(Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).

    public partial class Form1 : Form
    {
        // База данных с вопросами
        FriendsList database;
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
                database = new FriendsList(sfd.FileName);
                database.Add(tbName.Text, tbSurName.Text, tbSecondName.Text, int.Parse(tbMonth.Text), int.Parse(tbDay.Text));
                try { database.Save(); }
                catch (Exception) { return; }
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                database.CurrentIndex = (int)nudNumber.Value - 1;
                tbName.Focus();
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, ((sender as NumericUpDown).Focused == true)? null : e))
            {
                tbName.Focus();
                nudNumber.Value = database?.CurrentIndex + 1 ?? 0;
                return;
            }
            database.CurrentIndex = (int)nudNumber.Value - 1;
            FillFormFieldes();
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { nudNumber.Value = database?.CurrentIndex + 1 ?? 0; return; }
            database.Add(string.Empty, string.Empty, string.Empty, 1, 1);
            database.CurrentIndex = database.Count - 1;
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            FillFormFieldes();
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null)
            {
                ClearFormFieldes();
                return;
            }

            database.Remove((int)nudNumber.Value - 1);

            if ((int)nudNumber.Value > database.Count)
            {
                database.CurrentIndex--;
                nudNumber.Value = database.CurrentIndex + 1;
            } 
            nudNumber.Maximum--;
            FillFormFieldes();
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
                database = new FriendsList(ofd.FileName);
                try { database.Load(); }
                catch (Exception) { return; }
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                database.CurrentIndex = 0;
                FillFormFieldes();
            }
        }
        // Обработчик кнопки Сохранить (друга)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (!CheckCurrentQuestion(sender, e)) { return; }
            SaveFormFieldesInDataBase();
            database.IsChanged = true;
        }

        //Делаем проверки на заполнение текста вопроса и его сохранения в database     
        private bool CheckCurrentQuestion(object sender, EventArgs e)
        {
            if (database == null) { MessageBox.Show("База данных не создана"); return false; }
            if (sender != null && sender.GetType() == typeof(ToolStripMenuItem)) { return true; }

            if (tbName.Text == string.Empty && e != EventArgs.Empty)
            {
                MessageBox.Show("Введите хотя бы имя друга", "Пустое Имя", MessageBoxButtons.OK);
                return false;
            }
            if (sender != null && sender.GetType() == typeof(Button) && (sender as Button).Name == btnSaveQuest.Name) { return true; }

            if (database[database.CurrentIndex].Name == string.Empty && tbName.Text != string.Empty && e != EventArgs.Empty)
            {
                if (DialogResult.Yes != MessageBox.Show(
                    "Для перехода к другому другу, нужно сохранить текущего.\nСохранить этого друга?",
                    "Сохранить текущего друга?", MessageBoxButtons.YesNo)) { return false; }
                else { btnSaveQuest_Click(null, EventArgs.Empty); return true; }
            }
            if ((database[database.CurrentIndex].Name != tbName.Text ||
                database[database.CurrentIndex].SurName != tbSurName.Text ||
                database[database.CurrentIndex].SecondName != tbSecondName.Text ||
                database[database.CurrentIndex].MonthBirthday != int.Parse(tbMonth.Text) ||
                database[database.CurrentIndex].DayBirthday != int.Parse(tbDay.Text)) 
                && e != EventArgs.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show(
                    "Текущие данные были изменены.\nСохранить изменения?",
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
                tbName.Focus();
            };
        }

        private void FillFormFieldes()
        {
            tbName.Text = database[database.CurrentIndex].Name;
            tbSurName.Text = database[database.CurrentIndex].SurName;
            tbSecondName.Text = database[database.CurrentIndex].SecondName;
            tbMonth.Text = database[database.CurrentIndex].MonthBirthday.ToString();
            tbDay.Text = database[database.CurrentIndex].DayBirthday.ToString();
            tbName.Focus();
        }

        private void SaveFormFieldesInDataBase()
        {
            database[database.CurrentIndex].Name = tbName.Text;
            database[database.CurrentIndex].SurName = tbSurName.Text;
            database[database.CurrentIndex].SecondName = tbSecondName.Text;
            database[database.CurrentIndex].MonthBirthday = int.Parse(tbMonth.Text);
            database[database.CurrentIndex].DayBirthday = int.Parse(tbDay.Text);
            tbName.Focus();
        }

        private void ClearFormFieldes()
        {
            tbName.Text = string.Empty;
            tbSurName.Text = string.Empty;
            tbSecondName.Text = string.Empty;
            tbMonth.Text = 1.ToString();
            tbDay.Text = 1.ToString();
            tbName.Focus();
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tbMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}

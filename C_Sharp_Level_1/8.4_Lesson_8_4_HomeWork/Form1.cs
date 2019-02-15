using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_4_Lesson_8_4_HomeWork
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
            monthCalendar1_DateSelected(null, null);
            ControlBox = false;
            tbName.Focus();
        }                                                               
        // Обработчик пункта меню Exit
        private void MiExit_Click(object sender, EventArgs e)
        {
            if (database?.IsChanged ?? false)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохранённые изменения.\nСохранить изменения в файл перед выходом?",
                    "Сохранить изменения перед выходом?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) { miSave_Click(null, EventArgs.Empty); }
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
                database.Add(tbName.Text, tbSurName.Text, tbSecondName.Text, 
                    monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day);
                try { database.Save(); }
                catch (Exception) { return; }
                tbName.Focus();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                database.CurrentIndex = (int)nudNumber.Value - 1;
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
            monthCalendar1.SetDate(DateTime.Now);
            database.Add(string.Empty, string.Empty, string.Empty, 
                monthCalendar1.SelectionStart.Month, monthCalendar1.SelectionStart.Day);
            database.CurrentIndex = database.Count - 1;
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            FillFormFieldes();
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && DialogResult.Yes != MessageBox.Show(
                    "Текущий друг будет удалён.\nВы подтверждаете действие?",
                    "Удаление текущего друга", MessageBoxButtons.YesNo)) { return; }
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
                tbName.Focus();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                database.CurrentIndex = 0;
                FillFormFieldes();
                nudNumber.Value = 1;
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
                database[database.CurrentIndex].MonthBirthday != monthCalendar1.SelectionStart.Month ||
                database[database.CurrentIndex].DayBirthday != monthCalendar1.SelectionStart.Day) 
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
            DateTime dateTime = new DateTime(
                DateTime.Now.Year, database[database.CurrentIndex].MonthBirthday, database[database.CurrentIndex].DayBirthday);
            monthCalendar1.SetDate(dateTime);
            tbName.Focus();
        }

        private void SaveFormFieldesInDataBase()
        {
            database[database.CurrentIndex].Name = tbName.Text;
            database[database.CurrentIndex].SurName = tbSurName.Text;
            database[database.CurrentIndex].SecondName = tbSecondName.Text;
            database[database.CurrentIndex].MonthBirthday = monthCalendar1.SelectionStart.Month;
            database[database.CurrentIndex].DayBirthday = monthCalendar1.SelectionStart.Day;
            tbName.Focus();
        }

        private void ClearFormFieldes()
        {
            tbName.Text = string.Empty;
            tbSurName.Text = string.Empty;
            tbSecondName.Text = string.Empty;
            monthCalendar1.SetDate(DateTime.Now);
            tbMonth.Text = monthCalendar1.SelectionStart.Month.ToString("00");
            tbDay.Text = monthCalendar1.SelectionStart.Day.ToString("00");
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

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbMonth.Text = monthCalendar1.SelectionStart.Month.ToString("00");
            tbDay.Text = monthCalendar1.SelectionStart.Day.ToString("00");
        }
    }
}

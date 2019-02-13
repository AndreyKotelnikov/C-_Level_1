using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace _8._4_Lesson_8_4_HomeWork
{
    // Класс для друга    
    [Serializable]
    public class Friend
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public int MonthBirthday { get; set; } = 1;
        public int DayBirthday { get; set; } = 1;

        public Friend()
        {
        }
        public Friend(string name, string surName, string secondName, int monthBirthday, int dayBirthday)
        {
            Name = name;
            SurName = surName;
            SecondName = secondName;
            MonthBirthday = monthBirthday;
            DayBirthday = dayBirthday;
        }
    }
    // Класс для хранения списка друзей. А также для сериализации в XML и десериализации из XML
    class FriendsList
    {
        string fileName;
        List<Friend> list;
        public bool IsChanged { get; set; } = false;
        public int CurrentIndex { get; set; } = 0;
        public string FileName
        {
            set { fileName = value; }
        }
        public FriendsList(string fileName)
        {
            this.fileName = fileName;
            list = new List<Friend>();
        }
        public void Add(string name, string surName, string secondName, int monthBirthday, int dayBirthday)
        {
            list.Add(new Friend(name, surName, secondName, monthBirthday, dayBirthday));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Friend this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Friend>));
                Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка при сохранении файла:", MessageBoxButtons.OK);
                throw;
            }
        }
        public void Load()
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Friend>));
                Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                list = (List<Friend>)xmlFormat.Deserialize(fStream);
                fStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка при загрузке файла:", MessageBoxButtons.OK);
                throw;
            }
        }
        public int Count
        {
            get { return list.Count; }
        }
    }

}

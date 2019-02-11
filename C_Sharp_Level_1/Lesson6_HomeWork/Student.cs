using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_HomeWork
{
    class Student
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string University { get; private set; }
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public string Department { get; private set; }
        public int Group { get; private set; }
        public string City { get; private set; }
        public int Age { get; private set; }
        
        // Создаем конструктор
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="university"></param>
        /// <param name="faculty"></param>
        /// <param name="department"></param>
        /// <param name="age"></param>
        /// <param name="course"></param>
        /// <param name="group"></param>
        /// <param name="city"></param>
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            LastName = lastName;
            FirstName = firstName;
            University = university;
            Faculty = faculty;
            Department = department;
            Course = course;
            Age = age;
            Group = group;
            City = city;
        }
    
        /// <summary>
        /// Функция для сортировки Студентов по Имени
        /// </summary>
        /// <param name="st1">Студент 1</param>
        /// <param name="st2">Студент 2</param>
        /// <returns>Возвращает результат сравнения: -1, 0 или 1</returns>
        public static int SortByFirstName(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.FirstName, st2.FirstName);          // Сравниваем две строки
        }

        /// <summary>
        /// Функция для сортировки Студентов сначала по курсу, потом по возрасту
        /// </summary>
        /// <param name="st1">Студент 1</param>
        /// <param name="st2">Студент 2</param>
        /// <returns>Возвращает результат сравнения: -1, 0 или 1</returns>
        public static int SortByCourseThenByAge(Student st1, Student st2)
        {
            if (st1.Course > st2.Course) { return 1; }
            if (st1.Course < st2.Course) { return -1; }
            else
            {
                if (st1.Age > st2.Age) { return 1; }
                if (st1.Age < st2.Age) { return -1; }
                else { return 0; }
            }
        }

        /// <summary>
        /// Загружает из файла список студентов и возвращает его. 
        /// Дополнительно через out передаёт количество магистром и бакалавров.
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="bakalavr">Параметр для возврата значения: количество бакалавров</param>
        /// <param name="magistr">Параметр для возврата значения: количество магистров</param>
        /// <returns>Возвращает список студентов из файла</returns>
        public static List<Student> LoadListOfStudents(string fileName, out int bakalavr, out int magistr)
        {
            bakalavr = 0;
            magistr = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        list.Clear();
                        return list;
                    }
                }
            }
            sr.Close();
            return list;
        }

        /// <summary>
        /// Выводит на экран список студентов. 
        /// Дополнительно может отсортировать список и вывести количество бакалавров и студентов.
        /// </summary>
        /// <param name="list">Список студентов</param>
        /// <param name="bakalavr">Количество бакалавров</param>
        /// <param name="magistr">Количество магистров</param>
        /// <param name="sort">Функция для сортировки списка</param>
        public static void OutputListOfStudents(List<Student> list, int bakalavr = -1, int magistr = -1, Func<Student, Student, int> sort = null)
        {

            if (sort != null) { list.Sort(new Comparison<Student>(sort)); }
            Console.WriteLine("\nВсего студентов:" + list.Count);
            if (magistr != -1) { Console.WriteLine("Магистров:{0}", magistr); }
            if (bakalavr != -1) { Console.WriteLine("Бакалавров:{0}", bakalavr); }
            Console.WriteLine("|firstName|secondName|univercity|faculty|department|age|сourse|group|city|");
            foreach (var v in list)
            {
                Console.WriteLine($"|{v.FirstName, 9}|{v.LastName,10}|{v.University,10}|{v.Faculty,7}|{v.Department,10}|{v.Age,3}|{v.Course,6}|{v.Group,5}|{v.City,4}|");
            }
        }

        /// <summary>
        /// Подсчитывает и возвращает частотный массив студентов в заданном возрастном промежутке
        /// </summary>
        /// <param name="list">Список студентов</param>
        /// <param name="minAge">Минимальное значение возраста</param>
        /// <param name="maxAge">Максимальное значение возраста</param>
        /// <returns>Возвращает частотный массив студентов в заданном возрастном промежутке</returns>
        public static Dictionary<int, int> GetNumberOfStudentsInEachCourse(List<Student> list ,int minAge, int maxAge)
        {
            Dictionary<int, int> numberOfStudents = new Dictionary<int, int>();
            List<Student> listWithPredicateByAge = list.FindAll(item => item.Age >= minAge && item.Age <= maxAge);
            foreach (var item in listWithPredicateByAge)
            {
                if (numberOfStudents.Keys.Contains(item.Course)) { numberOfStudents[item.Course]++; }
                else { numberOfStudents.Add(item.Course, 1); }
            }
            return numberOfStudents;
        }

        /// <summary>
        /// Возвращает количество студентов на 5 и 6 курсах
        /// </summary>
        /// <param name="list">Список студентов</param>
        /// <returns>Возвращает количество студентов на 5 и 6 курсах</returns>
        public static int NumberHighCourse_5_6(List<Student> list) 
            => list.FindAll(item => item.Course == 5 || item.Course == 6).Count;

        /// <summary>
        /// Возвращает количество студентов по заданным условиям отбора для Свойств типа int
        /// </summary>
        /// <param name="list">Список студентов</param>
        /// <param name="property">Свойство, по которому требуется сделать отбор. 
        /// Нужно привести к типу Student и передать как функцию. Пример: (Student) => Student.Course</param>
        /// <param name="minValue">Минимальное значение свойства</param>
        /// <param name="maxValue">Максимальное значение свойства</param>
        /// <returns>Возвращает количество студентов по заданным условиям отбора для Свойств типа int</returns>
        public static int NumberOfStudentsWithPredicates(List<Student> list, Func<Student, int> property, int minValue, int maxValue)
        {
             return list.FindAll(item => property(item) >= minValue && property(item) <= maxValue).Count;
        }

        /// <summary>
        /// Возвращает количество студентов по заданным условиям отбора для Свойств типа string
        /// </summary>
        /// <param name="list">Список студентов</param>
        /// <param name="property">Свойство, по которому требуется сделать отбор. 
        /// Нужно привести к типу Student и передать как функцию. Пример: (Student) => Student.Course</param>
        /// <param name="valueForEqual">Значение для отбора на равенство</param>
        /// <returns>Возвращает количество студентов по заданным условиям отбора для Свойств типа string</returns>
        public static int NumberOfStudentsWithPredicates(List<Student> list, Func<Student, string> property, string valueForEqual)
        {
            return list.FindAll(item => property(item) == valueForEqual).Count;
        }

    }
}

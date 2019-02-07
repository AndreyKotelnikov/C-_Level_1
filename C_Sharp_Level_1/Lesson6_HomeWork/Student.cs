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
    
        public static int SortByFirstName(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.FirstName, st2.FirstName);          // Сравниваем две строки
        }

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

        internal static Dictionary<int, int> GetNumberOfStudentsInEachCourse(List<Student> list ,int minAge, int maxAge)
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

        public static int NumberHighCourse_5_6(List<Student> list) 
            => list.FindAll(item => item.Course == 5 || item.Course == 6).Count;
        
        public static int NumberOfStudentsWithPredicates(List<Student> list, Func<Student, int> property, int minValue, int maxValue)
        {
             return list.FindAll(item => property(item) >= minValue && property(item) <= maxValue).Count;
        }

        public static int NumberOfStudentsWithPredicates(List<Student> list, Func<Student, string> property, string valueForEqual)
        {
            return list.FindAll(item => property(item) == valueForEqual).Count;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using static Lesson6_HomeWork.TableFunc;

namespace Lesson6_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            goto m1;
            //1. Изменить программу вывода таблицы функции так, 
            //чтобы можно было передавать функции типа double (double, double). 
            //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
            Console.WriteLine("Таблица функций:");
            Fun fun = Func1;
            Table(fun, 4, 5);
            Table(Func2, 4, 5);
            Table(delegate (double x, double b) { return x * x * b; }, 4, 5);

            //2. Модифицировать программу нахождения минимума функции так, 
            //чтобы можно было передавать функцию в виде делегата. 
            //а) Сделать меню с различными функциями и представить пользователю выбор, 
            //для какой функции и на каком отрезке находить минимум.
            //Использовать массив(или список) делегатов, в котором хранятся различные функции.
            Console.WriteLine("\n\nНахождение минимума функции:");
            double[] userAnswes = MinFunc.GetUserAnswer();
            del_d_d del = MinFunc.functions.Keys.ElementAt((int)userAnswes[0]);
            Func<double, double> func = new Func<double, double>(del);
            MinFunc.SaveFunc(@"..\..\data.bin", func, -100, 100, 0.5);
            double min;
            
            //б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
            //Пусть она возвращает минимум через параметр(с использованием модификатора out).
            List<double> list = MinFunc.Load(@"..\..\data.bin", out min);
            Console.WriteLine($"\nМинимум функции: {min:0.000}");
            Console.WriteLine("\n\nВыводим все значения функции из файла:");
            foreach (var item in list)
            {
                Console.Write($"{item:0.000} ");
            }
            m1:
            //3. Переделать программу Пример использования коллекций для решения следующих задач:
            //а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            DateTime dt = DateTime.Now;
            int bakalavr;
            int magistr;
            List<Student> listStudents = Student.LoadListOfStudents(@"..\..\Students.csv", out bakalavr, out magistr);
            Student.OutputListOfStudents(listStudents, bakalavr, magistr, Student.SortByFirstName);
            Console.WriteLine(DateTime.Now - dt);

            Console.WriteLine($"\nКоличество студентов 5 и 6 курса равно: {Student.NumberHighCourse_5_6(listStudents)}");

            //3. б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
            int minAge = 18;
            int maxAge = 20;
            Dictionary<int, int> numberOfStudentsInEachCourse = Student.GetNumberOfStudentsInEachCourse(listStudents, minAge, maxAge);
            Console.WriteLine($"\n\nСреди студентов в возрасте от {minAge} до {maxAge} лет на каждом курсе учатся следующее количество:");
            foreach (var item in numberOfStudentsInEachCourse)
            {
                Console.WriteLine($"курс {item.Key} => {item.Value, 2} {DeclensionWord(item.Value, "студент", "студента", "студентов")}");
            }

            //3. в) отсортировать список по возрасту студента;
            Console.WriteLine("\nОтсортировать список по возрасту студента");
            listStudents.Sort(delegate (Student x, Student y) { if (x.Age > y.Age) { return 1; } else if (x.Age < y.Age) { return -1; } else { return 0; } });
            Student.OutputListOfStudents(listStudents);

            //3. г) *отсортировать список по курсу и возрасту студента;
            Console.WriteLine("\nОтсортировать список по курсу и возрасту студента");
            Student.OutputListOfStudents(listStudents, sort: Student.SortByCourseThenByAge);

            //3. д) разработать единый метод подсчета количества студентов по различным параметрам
            //выбора с помощью делегата и методов предикатов.
            Console.WriteLine($"\nКоличество студентов 5 и 6 курса равно: " +
                $"{Student.NumberOfStudentsWithPredicates(listStudents, (Student) => Student.Course, 5, 6)}");
            Console.WriteLine($"\nКоличество студентов с именем Andrey равно: " +
                $"{Student.NumberOfStudentsWithPredicates(listStudents, (Student) => Student.FirstName, "Andrey")}");

            //4.	**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
            //Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), 
            //строку для StreamReader и массив int для BinaryReader.


            Pause();
        }
    }
}

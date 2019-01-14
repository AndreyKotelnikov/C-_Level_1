using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
/*Котельников Андрей 
 *Kурс C# Уровень 1
 *Урок 1
 *Домашнее задание*/
#endregion

namespace Lesson1_HomeWork
{
    class Program
    {
        static double GetNumber(string msg)
        {
            double number;
            string answer;
            while (true)
            {
                Console.WriteLine(msg);
                answer = Console.ReadLine();
                if (Double.TryParse(answer, out number))
                {
                    return number;
                }
                Console.WriteLine("Нужно ввести число. Попробуйте ещё раз\n\n");
            }
        }

        static double BodyMassIndex(double growth, double weight)
        {
            return weight / Math.Pow(growth, 2);
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Main(string[] args)
        {
            /*1.	Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
             * В результате вся информация выводится в одну строчку:
             * а) используя  склеивание;*/
            Console.WriteLine("Укажите Ваше имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Укажите Вашу фамилию:");
            string surname = Console.ReadLine();
            double age = GetNumber("Укажите Ваш возраст:");
            double growth = GetNumber("Укажите Ваш рост:");
            double weight = GetNumber("Укажите Ваш вес:");
            Console.WriteLine(name + " " + surname + ", возраст: " + age + ", рост: " + growth + ", вес: " + weight);

            //б) используя форматированный вывод;
            Console.WriteLine("{0} {1}, возраст: {2}, рост: {3:N2}, вес: {4:N2}", name, surname, age, growth, weight);

            //в) используя вывод со знаком $.
            // Console.WriteLine("{0} {1}, возраст: {2}, рост: {3:C2}, вес: {4:C2}", name, surname, age, growth, weight);

            /*2.	Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле /k’; 
             * где m — масса тела в килограммах, h — рост в метрах.*/
            growth = GetNumber("Введите Ваш рост для расчёта индекса массы:");
            weight = GetNumber("Введите Ваш вес для расчёта индекса массы:");
            Console.WriteLine("Ваш индекс массы тела равен: {0:F2}", BodyMassIndex(growth, weight));

            /*3.а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
             * по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);*/
            Console.WriteLine("\n\nРасчёт расстояния между точками.");
            double x1 = GetNumber("Введите координату X1:");
            double y1 = GetNumber("Введите координату Y1:");
            double x2 = GetNumber("Введите координату X2:");
            double y2 = GetNumber("Введите координату Y2:");
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками равно {0:F2}", r);

            //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            Console.WriteLine("Расстояние между точками равно {0:F2}", Distance(x1, y1, x2, y2));

            Console.ReadLine();
        }
    }
}

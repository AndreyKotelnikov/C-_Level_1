using Lesson1_HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region 
//Котельников Андрей 
//Kурс C# Уровень 1
//Урок 2
//Практическая часть
#endregion


namespace Lesson2_PracticalPart
{
    class Program
    {


        static void Main(string[] args)
        {
            //Цикл с помощью рекурсии
            Loop(3, 13);
            Console.WriteLine("\n\n");

            //Найти сумму цифр числа A
            int a = (int)UsefulMethods.GetNumberFromConsoleInput("Введи число для суммы цифр");
            Console.WriteLine("Сумма цифр числа подсчитана без рекурсии: {0}", SumDigitsOfNumber(a));
            Console.WriteLine("Сумма цифр числа подсчитана с рекурсией: {0}", SumDigitsOfNumberRecursion(a));

            //Используем структуру DateTime
            DateTime start = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            DateTime finish = DateTime.Now;

            Console.WriteLine(@"Время выполнения программы в формате 'секунды:миллисекунды': {0:ss\:fffffff}", finish - start);

            //Задача 1.Алгоритм нахождения НОД и организация метода
            //Реализовать метод нахождения NOD, используя алгоритм Евклида:

            a = 1071;
            int b = 462;
            int nod = NOD(a, b);
            Console.WriteLine(nod);

            UsefulMethods.Pause();
        }

        private static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b) a -= b; else b -= a;
            }
            return a;
        }

        private static int SumDigitsOfNumberRecursion(int a)
        {
            if (a < 1) return 0;
            return SumDigitsOfNumberRecursion(a / 10) + (a % 10);
        }

        private static int SumDigitsOfNumber(int a)
        {
            int sum = 0;
            while (a > 0)
            {
                sum += (a % 10);
                a /= 10;
            }
            return sum;
        }

        private static void Loop(int a, int b)
        {
            Console.Write("{0,4} ", a);
            if (a < b)  Loop(a + 1, b);
        }
    }
}

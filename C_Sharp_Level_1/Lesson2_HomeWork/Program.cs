using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson1_HomeWork;

#region
//Котельников Андрей 
//Kурс C# Уровень 1
//Урок 2
//Домашнее задание
#endregion

namespace Lesson2_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Написать метод, возвращающий минимальное из трёх чисел.
            Console.WriteLine("Минимальное число равно: {0}", MinimalNumber(10, 5, 30));
            Console.WriteLine("Минимальное число равно: {0}", MinimalNumber(5, 10, 30));
            Console.WriteLine("Минимальное число равно: {0}", MinimalNumber(30, 5, 10));
            Console.WriteLine("Минимальное число равно: {0}", MinimalNumber(30, 10, 5));

            UsefulMethods.Pause();
        }

        private static int MinimalNumber(int v1, int v2, int v3)
        {
            return (v1 < v2) ? ((v1 < v3) ? v1 : v3) : ((v2 < v3) ? v2 : v3);
        }
    }
}

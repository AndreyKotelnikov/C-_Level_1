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

            //2.	Написать метод подсчета количества цифр числа.
            int answer = (int)UsefulMethods.GetNumberFromConsoleInput("Введите число для подсчёта количества его цифр:");
            Console.WriteLine("Количество цифр равно: {0}", CountDigitsOfNumber(answer));

            UsefulMethods.Pause();
        }

        /// <summary>
        /// Подсчитывает количество цифр в числе
        /// </summary>
        /// <param name="answer">Число для подсчёта количества его цифр</param>
        /// <returns></returns>
        private static int CountDigitsOfNumber(int number)
        {
            int count = 0;
            
            metka1:
                count++;
                number /= 10;
            if (number > 0) goto metka1;
            return count;
        }

        /// <summary>
        /// Возвращает минимальное число из 3-х аргументов
        /// </summary>
        /// <param name="v1">Первое число</param>
        /// <param name="v2">Второе число</param>
        /// <param name="v3">Третье число</param>
        /// <returns></returns>
        private static int MinimalNumber(int v1, int v2, int v3)
        {
            return (v1 < v2) ? ((v1 < v3) ? v1 : v3) : ((v2 < v3) ? v2 : v3);
        }
    }
}

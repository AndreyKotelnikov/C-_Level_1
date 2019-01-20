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

            //Требуется написать программу, которая правильно определит, 
            //какое слово нужно написать после возраста: год, лет, года.
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Вам {0} {1}.", i, DeclensionWord(i));
            }

            //Напишите программу, которая в последовательности целых чисел определяет среднее арифметическое положительных чисел, кратных 8.Программа получает на вход целые числа, среди них есть хотя бы одно положительное число, кратное 8, количество введённых чисел неизвестно, последовательность чисел заканчивается числом 0(0 — признак окончания ввода, не входит в последовательность).
            //Количество чисел не превышает 1000.Введённые числа по модулю не превышают 30 000.
            //Программа должна вывести одно число: среднее арифметическое положительных чисел, кратных 8.
            int answer;
            int count = 0;
            int countPozitivNumberDiv8 = 0;
            int sum = 0;
            int sumModul = 0;
            string numbersToString = "";

            while (true)
            {
                answer = (int)UsefulMethods.GetNumberFromConsoleInput("Введите число, или ноль для выхода");
                sumModul += Math.Abs(answer);
                count++;
                if (answer == 0 || (count + 1) > 1000 || sumModul > 30_000) break;
                if (answer > 0 && answer % 8 == 0)
                {
                    countPozitivNumberDiv8++;
                    sum += answer;
                }
                numbersToString += $" {answer},";
            }
            Console.WriteLine("\n\nВы ввели следующие числа: {0}", numbersToString);
            Console.WriteLine("\nСреднее арифметическое положительных чисел кратных 8 равно: {0}", sum / ((countPozitivNumberDiv8 == 0) ? 1 : countPozitivNumberDiv8));

            //Научимся подсчитывать время выполнения программы. Решим задачу нахождения простых чисел в диапазоне от 1 до 1000000.
            DateTime start1 = DateTime.Now;
            int count1 = 0;

            for (int i = 2; i < 100; i++)
            {
                if (IsSimple(i)) count1++;
            }
            Console.WriteLine("Количество простых чисел: {0}", count1);
            DateTime finish1 = DateTime.Now;
            Console.WriteLine(@"Длительность выполнения программы равна: {0:ss\:fffffff}", finish1 - start1);

            //Задача 6.Дано натуральное число n.Вычислить n!
            int factorial = 1;
            int answer1 = (int)UsefulMethods.GetNumberFromConsoleInput("Введите число для расчёта факториала:");

            for (int i = 2; i <= answer1; i++) factorial *= i;
            Console.WriteLine("Факториал равен: {0}", factorial);
            Console.WriteLine("Факториал через рекурсию равен: {0}", Factorial(answer1));

            UsefulMethods.Pause();
        }

        private static int Factorial(int number)
        {
            if (number == 1) return 1;
            return Factorial(number - 1) * number;
        }

        private static bool IsSimple(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Склонение слова для числительных. Пример: 1 год, 2 года,..., 5 лет,..., 21 год,... 
        /// </summary>
        /// <param name="i">Число, по которому определяем склонение слова</param>
        /// <param name="wordFor1">Склонение слова для i=1</param>
        /// <param name="wordFor234">Склонение слова для i=2,3,4</param>
        /// <param name="wordFor567890">Склонение слова для i=5,6,7,8,9,0</param>
        /// <returns></returns>
        private static string DeclensionWord(int i, string wordFor1 = "год", string wordFor234 = "года", string wordFor567890 = "лет")
        {
            if ((i >= 11 && i <= 14) || i % 10 >= 5 || i % 10 == 0) return wordFor567890;
            else if (i % 10 == 1) return wordFor1;
            else return wordFor234;
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

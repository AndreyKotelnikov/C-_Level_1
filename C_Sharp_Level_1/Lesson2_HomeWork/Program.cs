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

            //2.Написать метод подсчета количества цифр числа.
            int answer = (int)UsefulMethods.GetNumberFromConsoleInput("Введите число для подсчёта количества его цифр:");
            Console.WriteLine("Количество цифр равно: {0}", CountDigitsOfNumber(answer));

            //3.С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечётных положительных чисел.
            int sum = 0;
            while (true)
            {
                answer = (int)UsefulMethods.GetNumberFromConsoleInput("Введите число для подсчёта суммы положительных нечётных чисел:");
                if (answer == 0) break;
                if (answer > 0 && !UsefulMethods.EvenCheck(answer)) sum += answer;
            }
            Console.WriteLine("Сумма нечётных положительных чисел равна: {0}", sum);

            //4.Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password: GeekBrains). 
            //Используя метод проверки логина и пароля, написать программу:
            //пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.
            int count = 0;
            int maxCountOfTry = 3;

            do
            {
                if (AuthorizationCheck("root", "GeekBrains"))
                {
                    Console.WriteLine("Авторизация успешно пройдена");
                    break;
                }
                else
                {
                    count++;
                    Console.WriteLine("Логин или пароль не верны. У Вас осталось {0} {1}", maxCountOfTry - count, UsefulMethods.DeclensionWord(maxCountOfTry - count, "попытка", "попытки", "попыток"));
                }
            } while (count < maxCountOfTry);

            //5.а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы 
            //и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            double growth = UsefulMethods.GetNumberFromConsoleInput("Введите Ваш рост (в сантиметрах) для расчёта индекса массы:");
            double weight = UsefulMethods.GetNumberFromConsoleInput("Введите Ваш вес (в кг) для расчёта индекса массы:");
            Console.WriteLine("Ваш индекс массы тела равен: {0:F2}", UsefulMethods.BodyMassIndex(growth, weight));
            if (DeviationInBodyMassIndex(growth, weight) < 0)
                Console.WriteLine("Ваша масса ниже нормы. Вам нужно набрать вес. Минимум {0:f1} килограмм", -DeviationInBodyMassIndex(growth, weight));
            else if (DeviationInBodyMassIndex(growth, weight) > 0)
                Console.WriteLine("У Вас избыток массы тела. Вам нужно сбросить вес. Минимум {0:f1} килограмм", DeviationInBodyMassIndex(growth, weight));
            else Console.WriteLine("Ваш вес в норме.");

            //6.* Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
            double maxNumber = 1_000_000_000;
            count = 0;
            DateTime start = DateTime.Now;

            for (int i = 1; i <= maxNumber; i++)
            {
                if (i % SumDigitsOfNumberRecursion(i) == 0) count++;
            }
            Console.WriteLine("\nКоличество хороших чисел от 1 до {0} равно: {1}", maxNumber, count);
            DateTime finish = DateTime.Now;
            Console.WriteLine(@"Время выполнения программы в формате 'секунды:миллисекунды': {0:ss\:fffffff}", finish - start);

            //7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
            OutputNumbersBetweenInterval(1, 20);

            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            Console.WriteLine("Сумма чисел равна: {0}", SumNumbersBetweenInterval(1, 5));

            Random random = new Random();
            ConsoleColor[] colors = UsefulMethods.ArrayOfConsoleColors();
            Console.ForegroundColor = colors[random.Next(colors.Length - 1)];
            Console.WriteLine("\n\nДо новых встреч!");

            UsefulMethods.Pause();
        }

        private static int SumNumbersBetweenInterval(int minNumber, int maxNumber)
        {
            if (minNumber > maxNumber) return 0;
            return SumNumbersBetweenInterval(minNumber + 1, maxNumber) + minNumber;
            
        }

        private static void OutputNumbersBetweenInterval(int minNumber, int maxNumber)
        {
            Console.Write("{0,4} ", minNumber);
            if (minNumber < maxNumber) OutputNumbersBetweenInterval(minNumber + 1, maxNumber);
        }

        /// <summary>
        /// Считает сумму цифр у числа
        /// </summary>
        /// <param name="number">Число для расчёта суммы его цифр</param>
        /// <returns></returns>
        private static double SumDigitsOfNumberRecursion(double number)
        {
            if (number < 1) return 0;
            return SumDigitsOfNumberRecursion(number / 10) + (number % 10);
        }

        /// <summary>
        /// Рассчитывает отклонение в кг от нормы для данного роста. Если значение отрицательное - дефицит массы тела, если положительное - избыточная масса тела, если 0 - масса тела находится в рамках нормы
        /// </summary>
        /// <param name="growth">Рост в сантиметрах</param>
        /// <param name="weight">Вес в килограммах</param>
        private static double DeviationInBodyMassIndex(double growth, double weight)
        {
            double minNormIndex = 18.5;
            double maxNormIndex = 25;
            double bodyMassIndex = UsefulMethods.BodyMassIndex(growth, weight);

            if (bodyMassIndex <= minNormIndex)
                return (Math.Pow(growth / 100, 2) * bodyMassIndex) - (Math.Pow(growth / 100, 2) * minNormIndex);
            else if (bodyMassIndex >= maxNormIndex)
                return (Math.Pow(growth / 100, 2) * bodyMassIndex) - (Math.Pow(growth / 100, 2) * maxNormIndex);
            else return 0;
        }

        /// <summary>
        /// Проверяет совпадение логина и пароля, которые ввёл пользователь. При совпадении возвращает true.
        /// </summary>
        /// <param name="login">логин для проверки</param>
        /// <param name="password">пароль для проверки</param>
        /// <returns></returns>
        private static bool AuthorizationCheck(string login, string password)
        {
            string answer;
            Console.WriteLine("\nВведите Ваш логин:");
            answer = Console.ReadLine();
            if (answer == login)
            {
                Console.WriteLine("Введите Ваш пароль:");
                answer = Console.ReadLine();
                if (answer == password) return true;
            }
            return false;
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

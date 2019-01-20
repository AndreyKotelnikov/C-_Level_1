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
                } else
                {
                    count++;
                    Console.WriteLine("Логин или пароль не верны. У Вас осталось {0} {1}", maxCountOfTry - count, UsefulMethods.DeclensionWord(maxCountOfTry - count, "попытка", "попытки", "попыток"));
                }
            } while (count < maxCountOfTry);
            ;


      UsefulMethods.Pause();
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

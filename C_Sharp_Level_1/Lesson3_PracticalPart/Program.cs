using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;

namespace Lesson3_PracticalPart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Struct\n");

            ComplexStruct complexStruct1 = new ComplexStruct(4, 4);
            ComplexStruct complexStruct2 = new ComplexStruct(7, 7);

            Console.WriteLine(complexStruct1.ToString());
            Console.WriteLine(complexStruct2.ToString());

            ComplexStruct complexStruct3 = new ComplexStruct();
            complexStruct3 = complexStruct1.Plus(complexStruct2);

            Console.WriteLine(complexStruct3.ToString());

            ComplexStruct complexStruct4 = new ComplexStruct();
            complexStruct4 = complexStruct1 + complexStruct2;

            Console.WriteLine(complexStruct4.ToString());

            Console.WriteLine("\n\nClass\n");

            Complex complex1 = new Complex(4, 4);
            Complex complex2 = new Complex(7, 7);

            Console.WriteLine(complex1.ToString());
            Console.WriteLine(complex2.ToString());

            Complex complex3 = new Complex();
            complex3 = complex1.Plus(complex2);

            Console.WriteLine(complex3.ToString());

            Complex complex4 = new Complex();
            complex4 = complex1 + complex2;

            Console.WriteLine(complex4.ToString());

            complex4.Re = -4;
            Console.WriteLine(complex4.ToString());

            complex3.Im = -5;
            Console.WriteLine(complex3.ToString());

            //Задача 1.Найти максимальное число.
            //На вход программе подаётся последовательность чисел, заканчивающаяся нулём.Найти максимальное число.
            Console.WriteLine("\n\nНайти максимальное число\n");
            double maxNumber = Double.NaN;
            double answer;
        
            do
            {
                answer = GetNumberFromConsoleInput("Введите число или ноль для выхода");
                if (Double.IsNaN(maxNumber)) maxNumber = answer;
                if (answer != 0 && answer > maxNumber) maxNumber = answer;
            } while (answer != 0);

            Console.WriteLine($"Максимальное число равно {(maxNumber != 0 ? maxNumber.ToString() : "неизвестности")}");

            //Задача 2. Вычислить частное q и остаток r при делении а на d, не используя операций деления (/) 
            //и взятия остатка от деления (%).
            //Дано натуральное(целое неотрицательное) число а и целое положительное число d.
            Console.WriteLine("\n\nВычислить частное q и остаток r при делении а на d\n");
            {
                int a = (int)GetNumberFromConsoleInput(min: 0, isInteger: true);
                int b = (int)GetNumberFromConsoleInput(min: 1, isInteger: true);
                int q = 0, r = 0;

                while (a >= b)
                {
                    a -= b;
                    q++;
                }
                r = a;

                Console.WriteLine($"{b * q + r} / {b} = {q} и остаток {r}");
            }

            //Задача 3. Написать программу табуляции произвольной функции в диапазоне от a до b.
            Console.WriteLine("\n\nНаписать программу табуляции произвольной функции в диапазоне от a до b\n");
            {
                double a = 1;
                double b = 10;
                double tableStep = 0.5;

                for (double i = a; i <= b; i += tableStep)
                {
                    Console.WriteLine($"{i,5}: {F(i): 0.###}");
                }


            }

        //Задача 4. Игра «Угадай число».
        //Игра «Угадай число». Метод половинного деления.
        //Написать игру «Угадай число». Компьютер загадывает число в диапазоне от 1 до 100, 
        //а человек за ограниченное число попыток должен угадать его.
        //Количество попыток вычисляется по формуле i = log2N + 1
            Random rand = new Random();
            int guessNumber = 10; //rand.Next(101);
            int maxTry = (int)Math.Round(Math.Log(100)) + 1;
            Console.WriteLine($"Угадайте загаданное число за {maxTry} {DeclensionWord(maxTry, "попытка", "попытки", "попыток")}\n");
            int count = 0;
            int userAnswer;

            do
            {
                Console.WriteLine($"У Вас есть ещё {maxTry - count} " +
                    $"{DeclensionWord(maxTry - count, "попытка", "попытки", "попыток")}");
                userAnswer = (int)GetNumberFromConsoleInput("Введите число от 0 до 100:", 0, 100, true);
                count++;
                if (userAnswer > guessNumber) Console.WriteLine("Вы указали слишком большое число\n");
                else if (userAnswer < guessNumber) Console.WriteLine("Вы указали слишком маленькое число\n");

            } while (count < maxTry && userAnswer != guessNumber);

            if (userAnswer != guessNumber) Console.WriteLine("\n\nВаши попытки закончились. Попробуйте ещё раз");
            else Console.WriteLine("\n\nПоздарвляю! Вы угадали число!");
            


            Pause();
        }

        private static double F(double i)
        {
            return 1 / i;
        }
    }
}

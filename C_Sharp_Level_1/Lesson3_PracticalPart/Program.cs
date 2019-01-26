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
                int a = 1;
                int b = 10;

                for (int i = a; i <= b; i++)
                {
                    Console.WriteLine($"{i,3}, {F(i): 0.###}");
                }


            }

            Pause();
        }

        private static double F(int i)
        {
            return 1 / (double)i;
        }
    }
}

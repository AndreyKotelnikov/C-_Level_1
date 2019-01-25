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

            Console.WriteLine($"Максимальное число равно {maxNumber}");

           Pause();
        }
    }
}

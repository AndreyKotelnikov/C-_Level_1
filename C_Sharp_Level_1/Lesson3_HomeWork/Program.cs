using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using Lesson3_PracticalPart;

namespace Lesson3_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
            //Продемонстрировать работу структуры.
            Console.WriteLine("Struct\n");

            ComplexStruct complexStruct1 = new ComplexStruct(4, 4);
            ComplexStruct complexStruct2 = new ComplexStruct(7, 7);
            Console.WriteLine(complexStruct1);
            Console.WriteLine(complexStruct2);

            ComplexStruct complexStruct3 = new ComplexStruct();
            complexStruct3 = complexStruct1.Plus(complexStruct2);
            Console.WriteLine(complexStruct3);

            ComplexStruct complexStruct4 = new ComplexStruct();
            complexStruct4 = complexStruct1 + complexStruct2;
            Console.WriteLine(complexStruct4);

            complexStruct3 = complexStruct1.Minus(complexStruct2);
            Console.WriteLine(complexStruct3);

            complexStruct4 = complexStruct1 - complexStruct2;
            Console.WriteLine(complexStruct4);

            //1. б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            Console.WriteLine("\n\nClass\n");

            Complex complex1 = new Complex(10, 10);
            Complex complex2 = new Complex(5, 5);
            Console.WriteLine(complex1);
            Console.WriteLine(complex2);

            Complex complex3 = new Complex();
            complex3 = complex1.Plus(complex2);
            Console.WriteLine($"complex1.Plus(complex2) = {complex3}");

            Complex complex4 = new Complex();
            complex4 = complex1 + complex2;
            Console.WriteLine($"complex1 + complex2 = {complex4}");

            complex3 = complex1.Minus(complex2);
            Console.WriteLine($"complex1.Minus(complex2) = {complex3}");

            complex4 = complex1 - complex2;
            Console.WriteLine($"complex1 - complex2 = {complex4}");

            complex3 = complex1.Multiplication(complex2);
            Console.WriteLine($"complex1.Multiplication(complex2) = {complex3}");

            complex4 = complex1 * complex2;
            Console.WriteLine($"complex1 * complex2 = {complex4}");

            complex3 = complex1.Division(complex2);
            Console.WriteLine($"complex1.Division(complex2) = {complex3}");

            complex4 = complex1 / complex2;
            Console.WriteLine($"complex1 / complex2 = {complex4}");

            //1. в) Добавить диалог с использованием switch демонстрирующий работу класса.
            Console.WriteLine(Complex.ArithmeticOperationsWithTwoNumbers(Complex.InputFormatArithmeticOperation()));

            //2. а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
            //Требуется подсчитать сумму всех нечётных положительных чисел. 
            //Сами числа и сумму вывести на экран, используя tryParse.
            double sumEvenPositiveNumbers = 0;
            double number;
            List<string> answer = new List<string>();

            Console.WriteLine("\n\nВводите числа (каждое число в новой строке) или 0 для начала рассчётов:");
            do
            {
                answer.Add(Console.ReadLine());
                
            } while (answer.Last() != "0");

            Console.WriteLine("\n\nВыводим нечётные положительные числа:");

            foreach (var item in answer)
            {
                if (Double.TryParse(item, out number) && number > 0 && !EvenCheck(number))
                {
                    Console.Write($"{number}, ");
                    sumEvenPositiveNumbers += number;
                }
            }

            Console.WriteLine($"\nСумма нечётных положительных чисел равна: {sumEvenPositiveNumbers}");
            //3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
            //Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
            //Написать программу, демонстрирующую все разработанные элементы класса.
            


            Pause();
        }
    }
}

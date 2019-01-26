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


            Pause();
        }
    }
}

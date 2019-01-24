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
            ComplexStruct complex1 = new ComplexStruct(4, 4);
            ComplexStruct complex2 = new ComplexStruct(7, 7);

            Console.WriteLine(complex1.ToString());
            Console.WriteLine(complex2.ToString());

            ComplexStruct complex3 = new ComplexStruct();
            complex3 = complex1.Plus(complex2);

            Console.WriteLine(complex3.ToString());

            ComplexStruct complex4 = new ComplexStruct();
            complex4 = complex1 + complex2;

            Console.WriteLine(complex4.ToString());

            Pause();
        }
    }
}

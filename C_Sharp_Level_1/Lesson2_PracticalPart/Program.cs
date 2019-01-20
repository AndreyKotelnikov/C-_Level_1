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

            UsefulMethods.Pause();
        }

        private static void Loop(int a, int b)
        {
            Console.Write("{0,4} ", a);
            if (a < b)  Loop(a + 1, b);
        }
    }
}

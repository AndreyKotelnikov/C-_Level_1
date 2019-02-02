using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;


namespace Lesson5_PracticalPart
{
    class Program
    {
        const int iIterations = 10000;

        static void Main(string[] args)
        {
            //Сравним производительность работы StringBuilder с неизменяемыми строками:
            {
                DateTime dt = DateTime.Now;
                string str = String.Empty;
                for (int i = 0; i < iIterations; i++)
                    str += "abcdefghijklmnopqrstuvwxyz\r\n";
                Console.WriteLine(DateTime.Now - dt);
            }

            //Те же операции с StringBuilder:
            {
                DateTime dt = DateTime.Now;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < iIterations; i++)
                    sb.Append("abcdefghijklmnopqrstuvwxyz\r\n");
                string str = sb.ToString();
                Console.WriteLine(DateTime.Now - dt);
            }
            //StringBuilder в 1000 раз быстрее string

            Pause();
        }
    }
}

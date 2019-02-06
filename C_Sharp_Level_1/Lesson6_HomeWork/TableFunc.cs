using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_HomeWork
{
    public delegate double Fun(double x, double b);

    class TableFunc
    {
        
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        /// <summary>
        /// a*x^2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns>a*x^2</returns>
        public static double Func1(double x, double a) => a * Math.Pow(x, 2);

        /// <summary>
        /// a*sin(x)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns>a*sin(x)</returns>
        public static double Func2(double x, double a) => a * Math.Sin(x);

    }
}

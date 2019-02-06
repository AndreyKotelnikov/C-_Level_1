using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using static Lesson6_HomeWork.TableFunc;

namespace Lesson6_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Изменить программу вывода таблицы функции так, 
            //чтобы можно было передавать функции типа double (double, double). 
            //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
            Fun fun = Func1;
            Table(fun, 4, 5);
            Table(Func2, 4, 5);
            Table(delegate (double x, double b) { return x * x * b; }, 4, 5);






            Pause();
        }
    }
}

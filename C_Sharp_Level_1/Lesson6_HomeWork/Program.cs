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
            Console.WriteLine("Таблица функций:");
            Fun fun = Func1;
            Table(fun, 4, 5);
            Table(Func2, 4, 5);
            Table(delegate (double x, double b) { return x * x * b; }, 4, 5);

            //2. Модифицировать программу нахождения минимума функции так, 
            //чтобы можно было передавать функцию в виде делегата. 
            //а) Сделать меню с различными функциями и представить пользователю выбор, 
            //для какой функции и на каком отрезке находить минимум.
            //Использовать массив(или список) делегатов, в котором хранятся различные функции.
            Console.WriteLine("\n\nНахождение минимума функции:");
            double[] userAnswes = MinFunc.GetUserAnswer();
            del_d_d del = MinFunc.functions.Keys.ElementAt((int)userAnswes[0]);
            Func<double, double> func = new Func<double, double>(del);
            MinFunc.SaveFunc(@"..\..\data.bin", func, -100, 100, 0.5);
            Console.WriteLine($"\nМинимум функции: {MinFunc.Load(@"..\..\data.bin"):0.000}");





            Pause();
        }
    }
}

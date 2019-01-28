using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;

namespace Lesson4_PracticalPart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 1. Класс «Мой одномерный массив»
            //Разработать класс для работы с одномерным массивом.Предусмотреть конструктор, 
            //заполняющий массив конкретными значениями, и конструктор, заполняющий массив случайными числами.
            //Сделать методы поиска среднего значения, максимального элемента массива, минимального элемента массива, 
            //подсчета количества положительных чисел и метод, возвращающий массив в виде строки.
            Console.WriteLine("Мой одномерный массив:");
            MyArray array = new MyArray(10, -100, 100);
            Console.WriteLine(array);
            Console.WriteLine($"Среднее значение = {array.Average}");
            Console.WriteLine($"Минимальное значение = {array.Min}");
            Console.WriteLine($"Максимальное значение = {array.Max}");
            Console.WriteLine($"Количество положительных чисел = {array.Positive}");

            Pause();
        }
    }
}

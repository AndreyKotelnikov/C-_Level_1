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
            Console.WriteLine($"Среднее значение = {array.Average:0.###}");
            Console.WriteLine($"Минимальное значение = {array.Min}");
            Console.WriteLine($"Максимальное значение = {array.Max}");
            Console.WriteLine($"Количество положительных чисел = {array.Positive}");

            //Задача 2. Массив и файл
            //Дана последовательность целых чисел, записанная в текстовый файл.
            //Требуется считать данные из файла в массив, найти среднее арифметическое элементов и вывести 
            //минимальный и максимальный элементы массива на экран.Отсортировать массив.
            Console.WriteLine("\n\nСчитываем массив из файла");
            MyArray arrayFile = new MyArray(@"D:\! Geek Brain\С# Уровень 1\Урок 4\Array.txt");
            Console.WriteLine(arrayFile);
            Console.WriteLine($"Среднее значение = {arrayFile.Average:0.###}");
            Console.WriteLine($"Минимальное значение = {arrayFile.Min}");
            Console.WriteLine($"Максимальное значение = {arrayFile.Max}");
            
            arrayFile.BubbleSort();
            arrayFile.OutputArrayWithMessage("\nВыводим отсортированный массив:");

            //Задача 3. Частотный массив
            //Дана последовательность натуральных чисел от 0 до 99.Найти, какое число встречается чаще всего.
            //Если таких чисел несколько, то вывести все числа.
            MyArray seriesArray = arrayFile.MaxFrequencyItems();
            seriesArray.OutputArrayWithMessage("\nСамые встречающиеся значения:");


                      Pause();
        }
    }
}

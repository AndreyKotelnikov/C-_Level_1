using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using MyLibraryForArray;

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

            //Привязываемся к относительной директории, 
            //чтобы при запуске проекта на другом компьютере не приходилось заново указывать путь к файлу
            string path = Environment.CurrentDirectory;
            string newPath;
            newPath = path.Remove(path.LastIndexOf(@"\bin\Debug") + 1);
            newPath = String.Concat(newPath, "Array.txt");
            
            MyArray arrayFile = new MyArray(newPath);
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

            //Задача 4. Класс «Мой двумерный массив»
            //Разработать класс для работы с двумерным массивом.Сделать методы поиска среднего значения, 
            //максимального элемента массива, минимального элемента массива, подсчета количества положительных 
            //элементов массива, вывода массива на экран и метод, возвращающий массив в виде строки.
            Console.WriteLine("\n\nМой двухмерный массив");
            MyArrayTwoDim array2D = new MyArrayTwoDim(10, 10, -100, 100);
            array2D.OutputArrayWithMessage("Выводим таблицу значений:");
            Console.WriteLine($"\nСреднее значение = {array2D.Average:0.###}");
            Console.WriteLine($"Минимальное значение = {array2D.Min}");
            Console.WriteLine($"Максимальное значение = {array2D.Max}");
            Console.WriteLine($"Количество положительных чисел = {array2D.Positive}");

            //Задача 5. Задача на матрицу
            //Дан прямоугольный массив целых положительных чисел N х M, заполненный случайными числами.
            //Описать на русском языке или на одном из языков программирования алгоритм поиска строки 
            //с наименьшей суммой элементов.Вывести на печать номер строки и сумму её элементов.
            //Если таких строк несколько, вывести информацию о каждой строке.
            Console.WriteLine("\n\nСоздаём матрицу");
            MyArrayTwoDim matrix = new MyArrayTwoDim(5, 2, -2, 2);
            matrix.OutputArrayWithMessage("Выводим таблицу значений:");

            MyArrayTwoDim minSumRows = matrix.MinSumRows;
            minSumRows.OutputArrayWithMessage("В этих строках минимальная сумма:");

            //Задача 6
            //Разработать класс для работы с одномерным массивом.
            //Создать конструктор для заполнения массива случайными числами и конструктор для заполнения массива
            //из файла. Создать свойство, возвращающее максимальный элемент. Реализовать индексируемое свойство.
            Console.WriteLine("Массив с индексацией:");
            MyArray myNewArray = new MyArray(10, 0, 20);
            for (int i = 0; i < myNewArray.Length; i++)
            {
                Console.Write($"{myNewArray[i]}, ");
            }

            Pause();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson1_HomeWork.UsefulMethods;
using Lesson4_PracticalPart;

namespace Lesson4_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.	Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения
            //от –10 000 до 10 000 включительно. Заполнить случайными числами.  Написать программу, позволяющую найти
            //и вывести количество пар элементов массива, в которых только одно число делится на 3. 
            //В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, 
            //для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
            //ноль рассматриваем как число, которое делится на 3.
            Console.WriteLine("Реализуем алгоритм поиска количества пар, делящихся на 3, через метод класса MyArray");
            MyArray array = new MyArray(20, -10_000, 10_000);
            array.OutputArrayWithMessage("Выводим значения массива");
            Console.WriteLine($"\nКоличество пар, делящихся на 3, равно: {array.NumberOfPairsDividedBy(3)}");

            //2.	Реализуйте задачу 1 в виде статического класса StaticClass;
            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу
            Console.WriteLine("\nРеализуем алгоритм поиска количества пар, делящихся на 3, через " +
                "статический метод класса StaticClass");
            int[] arrayInt = new int[20];
            StaticClass.FillingArrayWithRandomNumbers(arrayInt, -10_000, 10_000);
            StaticClass.OutputArray(arrayInt);
            Console.WriteLine($"\nКоличество пар, делящихся на 3, равно: {StaticClass.NumberOfPairsDividedBy(arrayInt, 3)}");

            //2. б) *Добавьте статический метод для считывания массива из текстового файла. 
            //Метод должен возвращать массив целых чисел;
            //в)**Добавьте обработку ситуации отсутствия файла на диске.
            Console.WriteLine("\nзаполняем массив из файла");
            int[] arrayFile = new int[6];
            StaticClass.GetArrayFromFile(arrayFile, @"D:\! Geek Brain\С# Уровень 1\Урок 4\Array.txt");
            StaticClass.OutputArray(arrayFile);


            Pause();
        }
    }
}

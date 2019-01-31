using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4_HomeWork
{
    class StaticClass
    {
        /// <summary>
        /// Заполняет массив случайными числами в указанном диапазоне включительно
        /// </summary>
        /// <param name="array">Массив, который нужно заполнить случайными числами</param>
        /// <param name="minValue">Минимальное значение для создания случайных чисел</param>
        /// <param name="maxValue">Максимальное значение для создания случайных чисел</param>
        public static void FillingArrayWithRandomNumbers(ref int[] array, int minValue, int maxValue)
        {
            Random rand = new Random(100);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
        }

        public static void OutputArray(int[] array)
        {
            Console.WriteLine("Выводим значения массива:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
            }
        }

        /// <summary>
        /// Возвращает количество пар элементов массива, в которых только одно число делится на указанный делитель.
        /// Считаем, что ноль делится на любое число.
        /// </summary>
        /// <param name="array">Массив, пары элементов которых нужно проверить</param>
        /// <param name="dividedBy">Делитель, на который нужно проверить делимость значений в парах элементов</param>
        /// <returns>Возвращает количество пар элементов массива, в которых только одно число делится на указанный делитель.</returns>
        public static int NumberOfPairsDividedBy(int[] array, int dividedBy)
        {
            //считаем, что ноль делится на любое число
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (((array[i] % dividedBy == 0) && (array[i + 1] % dividedBy != 0))
                    || ((array[i] % dividedBy != 0) && (array[i + 1] % dividedBy == 0))) count++;
            }
            return count;
        }

        /// <summary>
        /// Заполняет значения элементов массива из файла (по одному числу с каждой следующей строки файла).
        /// </summary>
        /// <param name="array">Массив, который нужно заполнить из файла</param>
        /// <param name="fileName">Путь к файлу, с указанием его имени</param>
        public static void GetArrayFromFile(ref int[] array, string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(fileName);
                    
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (streamReader.EndOfStream)
                        {
                            Console.WriteLine("В файле данные закончились раньше, чем элементы в массиве");
                            break;
                        }
                        array[i] = int.Parse(streamReader.ReadLine());
                    }
                    streamReader.Close();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else Console.WriteLine($"В указанной директории файл не обнаружен: {fileName}");
        }
    }
}

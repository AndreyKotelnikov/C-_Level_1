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
        public static void FillingArrayWithRandomNumbers(int[] array, int minValue, int maxValue)
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

        public static void GetArrayFromFile(int[] array, string fileName)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

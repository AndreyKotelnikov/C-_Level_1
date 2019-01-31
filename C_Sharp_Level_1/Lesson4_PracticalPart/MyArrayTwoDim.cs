using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibraryForArray;

namespace Lesson4_PracticalPart
{
    /// <summary>
    /// Библиотека для работы с двухмерным массивом, включающим элементы типа int
    /// </summary>
    public class MyArrayTwoDim
    {
        int[,] array2D;

        /// <summary>
        /// Возвращает новый одномерный массив, содержащий значения всех элементов указанного индекса строки массива
        /// </summary>
        /// <param name="i">Индекс строки массива, элементы которой нужно получит в новом массиве</param>
        /// <returns></returns>
        public MyArray this[int i]
        {
            get
            {
                MyArray array = new MyArray(array2D.GetLength(1));
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array[j] = array2D[i, j];
                }
                return array;
            }
        }

        /// <summary>
        /// Возвращает элемент массива с указанными индексами строки и колонки
        /// </summary>
        /// <param name="i">Индекс строки</param>
        /// <param name="j">Индекс колонки</param>
        /// <returns>Возвращает элемент массива с указанными индексами строки и колонки</returns>
        public int this[int i, int j]
        {
            get => array2D[i, j];
            set { array2D[i, j] = value; }
        }

        /// <summary>
        /// Создаёт массив указанного размера и заполняет его указанными значениями (по умолчанию заполняется нулями)
        /// </summary>
        /// <param name="rows">Количество строк в массиве</param>
        /// <param name="columns">Количество колонок в массиве</param>
        /// <param name="valueItem">Значение, которыми заполняются все элементы массива (по умолчанию = 0)</param>
        public MyArrayTwoDim(int rows, int columns, int valueItem = 0)
        {
            array2D = new int[rows, columns];
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = valueItem;
                }
            }
        }

        /// <summary>
        /// Создаёт массив указанной длины и заполняет случайными числами в указанном диапазоне включительно
        /// </summary>
        /// <param name="rows">Количество строк в массиве</param>
        /// <param name="columns">Количество колонок в массиве</param>
        /// <param name="minValue">Минимальное значение для создания случайных чисел</param>
        /// <param name="maxValue">Максимальное значение для создания случайных чисел</param>
        public MyArrayTwoDim(int rows, int columns, int minValue, int maxValue)
        {
            array2D = new int[rows, columns];
            Random rand = new Random(77); //Указываем число 77, чтобы получать всегда одинаковую последовательность

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = rand.Next(minValue, maxValue + 1);
                }
            }
        }

        /// <summary>
        /// Возвращает максимальное значение в массиве
        /// </summary>
        public int Max
        {
            get
            {
                int max = array2D[0, 0];
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        if (max < array2D[i, j]) max = array2D[i, j];
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Возвращает минимальное значение в массиве
        /// </summary>
        public int Min
        {
            get
            {
                int min = array2D[0, 0];
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        if (min > array2D[i, j]) min = array2D[i, j];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Возвращает среднее значение всего массива
        /// </summary>
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        sum += array2D[i, j];
                    }
                }
                return sum / array2D.GetLength(0) / array2D.GetLength(1);
            }
        }

        /// <summary>
        /// Возвращает сумму положительных чисел в массиве
        /// </summary>
        public int Positive
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        if (array2D[i, j] > 0) sum += array2D[i, j];
                    }
                }
                return sum;
            }
        }

        /// <summary>
        /// Перегруженный метод, возвращающий строку со всеми элементами массива
        /// </summary>
        /// <returns>Возвращающий строку со всеми элементами массива</returns>
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    str += $"{array2D[i, j], 4}, ";
                }
                str += "\n";
            }
            return str;
        }

        /// <summary>
        /// Выводит в консоль указанное сообщение и далее значения самого массива
        /// </summary>
        /// <param name="message">Сообщения для вывода на консоль</param>
        public void OutputArrayWithMessage(string message = "")
        {
            if (message != "") Console.WriteLine(message);
            Console.WriteLine(this);
        }

        /// <summary>
        /// Возвращает новый двухмерный массив с минимальными суммами элементов в строках:
        /// номер (начиная с 1) строки и минимальное значение суммы элементов строки между всеми строками массива
        /// </summary>
        public MyArrayTwoDim MinSumRows
        {
            get
            {
                int min = this[0].Sum;
                for (int i = 1; i < array2D.GetLength(0); i++)
                {
                    if (min > this[i].Sum) min = this[i].Sum;
                }

                int count = 0;
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    if (min == this[i].Sum) count++;
                }

                MyArrayTwoDim arrayOut = new MyArrayTwoDim(count, 2);
                count = 0;
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    if (min == this[i].Sum)
                    {
                        arrayOut[count, 0] = i + 1;
                        arrayOut[count++, 1] = this[i].Sum;
                    }
                }
                return arrayOut;
            }
        }
        

    }
}

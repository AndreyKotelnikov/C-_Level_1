using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_PracticalPart
{
    public class MyArrayTwoDim
    {
        int[,] array2D;

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

        public int this[int i, int j]
        {
            get => array2D[i, j];
            set { array2D[i, j] = value; }
        }

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

        public void Print(string message = "")
        {
            if (message != "") Console.WriteLine(message);
            Console.WriteLine(this);
        }

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

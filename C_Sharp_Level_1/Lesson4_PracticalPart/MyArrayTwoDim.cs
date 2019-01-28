using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_PracticalPart
{
    class MyArrayTwoDim
    {
        int[,] array2D;

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

    }
}

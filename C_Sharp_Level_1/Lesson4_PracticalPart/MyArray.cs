using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_PracticalPart
{
    class MyArray
    {
        int[] array;

        public MyArray(int size, int itemValue = 0)
        {
            array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = itemValue;
            }
        }

        public MyArray(int size, int minValue, int maxValue)
        {
            array = new int[size];
            Random rand = new Random(100);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
        }

        public double Average
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return (double)sum / array.Length; 
            }
        }

        public int Max
        {
            get
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max < array[i]) max = array[i];
                }
                return max;
            }
        }

        public int Min
        {
            get
            {
                int min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (min > array[i]) min = array[i];
                }
                return min;
            }
        }
        
        public int Positive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0) count++;
                }
                return count;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                str += $"{array[i]}, ";
            }
            return str;
        }
    }
}

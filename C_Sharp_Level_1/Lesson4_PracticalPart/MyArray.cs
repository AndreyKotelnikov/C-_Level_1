using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson4_PracticalPart
{
    class MyArray
    {
        int[] array;

        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public MyArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(fileName);
                    //Считываем количество элементов из первой строки файла
                    int size = int.Parse(streamReader.ReadLine());
                    array = new int[size];
                    for (int i = 0; i < array.Length; i++)
                    {
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
                int min = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[min] > array[i]) min = i;
                }
                return array[min];
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
            try
            {
                
                for (int i = 0; i < array.Length; i++)
                {
                    str += $"{array[i]}, ";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Source}, class MyArray, method ToString():");
                Console.WriteLine(ex.Message);
            }
            return str;
        }

        public void BubbleSort()
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1]) 
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void OutputArrayWithMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(this);
        }

        public int Length
        {
            get { return array.Length; }
        }

        public MyArray MaxFrequencyItems()
        {
            MyArray seriesN = new MyArray(Max - Min + 1);
            int minOfArray = Min;
            foreach (var item in array)
            {
                seriesN[item - minOfArray]++; 
            }

            int max = seriesN.Max;
            int count = 0;
            for (int i = 0; i < seriesN.Length; i++)
            {
                if (seriesN[i] == max) count++;
            }

            MyArray arrayOut = new MyArray(count);
            count = 0;
            
            for (int i = 0; i < seriesN.Length; i++)
            {
                if (seriesN[i] == max) { arrayOut[count] = minOfArray + i; count++; }
            }
            return arrayOut;
        }
    }
}

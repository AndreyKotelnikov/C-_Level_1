using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryForArray
{
    /// <summary>
    /// Библиотека для работы с массивом, включающим элементы типа int
    /// </summary>
    public class MyArray
    {
        int[] array;

        /// <summary>
        /// Возвращает элемент массива с указанным индексом
        /// </summary>
        /// <param name="i">Индекс элемента в массиве, значение которого нужно получить</param>
        /// <returns>Элемент массива с указанным индексом I</returns>
        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        /// <summary>
        /// Конструктор класса, который создаёт массив, и инициализирует его начальным значением, 
        /// которое увеличивается на величину шага на каждом следующем элементе
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="startNumber">Начальное значение для заполнения первого элемента массива.
        /// Обязательно привести к типу Int64, поскольку тип int используется в сигнатуре другого конструктора</param>
        /// <param name="step">Величина шага, на который увеличивается каждый следующий элемент массива</param>
        public MyArray(int size, Int64 startNumber, int step = 1)
        {
            //array = new int[size];
            array = (int[])Array.CreateInstance(typeof(int), size);
            int sumStep = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)startNumber + sumStep;
                sumStep += step;
            }
        }

        /// <summary>
        /// Создаёт массив, загружая количество элементов из первой строки файла, 
        /// а значения элементов по одному с каждой следующей строки файла.
        /// </summary>
        /// <param name="fileName">Строка, указывающая путь к файлу и его название</param>
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

        /// <summary>
        /// Создаёт массив указанного размера и заполняет его указанными значениями (по умолчанию заполняется нулями)
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="itemValue">Значение, которыми заполняются все элементы массива (по умолчанию = 0)</param>
        public MyArray(int size, int itemValue = 0)
        {
            array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = itemValue;
            }
        }

        /// <summary>
        /// Создаёт массив указанной длины и заполняет случайными числами в указанном диапазоне включительно 
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="minValue">Минимальное значение для создания случайных чисел</param>
        /// <param name="maxValue">Максимальное значение для создания случайных чисел</param>
        public MyArray(int size, int minValue, int maxValue)
        {
            array = new int[size];
            Random rand = new Random(100); //Указываем число 100, чтобы получать всегда одинаковую последовательность

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
        }

        /// <summary>
        /// Возвращает среднее значение всего массива
        /// </summary>
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

        /// <summary>
        /// Возвращает сумму всех элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }
        }

        /// <summary>
        /// Возвращает максимальное значение в массиве
        /// </summary>
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

        /// <summary>
        /// Возвращает минимальное значение в массиве
        /// </summary>
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

        /// <summary>
        /// Возвращает сумму положительных чисел в массиве
        /// </summary>
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

        /// <summary>
        /// Умножает каждый элемент массива на определённое число
        /// </summary>
        /// <param name="multiplier">Множитель, на который нужно умножить каждый элемент массива</param>
        public void Multi(int multiplier)
        {
            for (int i = 0; i < Length; i++)
            {
                this[i] *= multiplier;
            }
        }

        /// <summary>
        /// Возвращает новый массив с измененными знаками у всех элементов массива 
        /// (старый массив, остается без изменений)
        /// </summary>
        /// <returns>Новый массив с измененными знаками у всех элементов массива</returns>
        public MyArray Inverse()
        {
            MyArray arrayOut = new MyArray(Length);
            for (int i = 0; i < Length; i++)
            {
                arrayOut[i] = -this[i];
            }
            return arrayOut;
        }

        /// <summary>
        /// Перегруженный метод, возвращающий строку со всеми элементами массива
        /// </summary>
        /// <returns>Возвращающий строку со всеми элементами массива</returns>
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

        /// <summary>
        /// Сортирует элементы массива методом пузырьков: первый элемент - минимальный, последний - максимальный
        /// </summary>
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

        /// <summary>
        /// Выводит в консоль указанное сообщение и далее значения самого массива
        /// </summary>
        /// <param name="message">Сообщения для вывода на консоль</param>
        public void OutputArrayWithMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(this);
        }

        /// <summary>
        /// Возвращает длину массива
        /// </summary>
        public int Length
        {
            get { return array.Length; }
        }

        /// <summary>
        /// Возвращает количество максимальных элементов в массиве
        /// </summary>
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                for (int i = 0; i < Length; i++)
                {
                    if (this[i] == max) count++;
                }
                return count;
            }
        }

        /// <summary>
        /// Возвращает новый массив с элементами, которые чаще всего встречаются в текущем массиве
        /// </summary>
        /// <returns>Возвращает новый массив с элементами, которые чаще всего встречаются в текущем массиве</returns>
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

        /// <summary>
        /// Возвращает количество пар элементов массива, в которых только одно число делится на указанный делитель.
        /// Считаем, что ноль делится на любое число.
        /// </summary>
        /// <param name="dividedBy">Делитель, на который нужно проверить делимость значений в парах элементов</param>
        /// <returns>Возвращает количество пар элементов массива, в которых только одно число делится на указанный делитель.</returns>
        public int NumberOfPairsDividedBy(int dividedBy)
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (((array[i] % dividedBy == 0) && (array[i + 1] % dividedBy != 0))
                    || ((array[i] % dividedBy != 0) && (array[i + 1] % dividedBy == 0))) count++;
            }
            return count;
        }

        /// <summary>
        /// Возвращает частоту вхождения каждого элемента в массив в коллекции Dictionary(int,int)
        /// </summary>
        /// <returns>Возвращает частоту вхождения каждого элемента в массив в коллекции Dictionary(int,int)</returns>
        public Dictionary<int, int> FrequencyOfOccurrenceItemInArray()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    dictionary[array[i]]++;
                }
                else
                {
                    dictionary.Add(array[i], 1);
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Выводит на консоль информацию по частоте вхождения каждого элемента в массив в виде: Элемент => Частота
        /// </summary>
        public void OutputConsoleFrequencyOfOccurrenceItemInArray()
        {
            Dictionary<int, int> frequencyItem = FrequencyOfOccurrenceItemInArray();
            Dictionary<int, int>.KeyCollection keys = frequencyItem.Keys;

            Console.WriteLine("\nПодсчитываем частоту вхождения каждого элемента в массив:");
            Console.WriteLine("Элемент => Частота");
            foreach (var item in keys)
            {
                Console.WriteLine($"{item,7} => {frequencyItem[item]}");
            }
        }

        /// <summary>
        /// Заполняет массив случайными числами в указанном диапазоне включительно
        /// </summary>
        /// <param name="array">Массив, который нужно заполнить случайными числами</param>
        /// <param name="minValue">Минимальное значение для создания случайных чисел</param>
        /// <param name="maxValue">Максимальное значение для создания случайных чисел</param>
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



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_HomeWork
{
    delegate double del_d_d(double d);

    class MinFunc
    {
        /// <summary>
        /// Словарь, в котором хранятся значения делегатов функций и их описание
        /// </summary>
        public static Dictionary<del_d_d, string> functions = new Dictionary<del_d_d, string>
        {
            [F] = "x * x - 50 * x + 10",
            [Math.Sin] = "Sin(x)",
            [Math.Tan] = "Tangent(x)"
        };

        /// <summary>
        /// Запрашиваем у пользователя через консоль значение следующих параметров:
        /// номер функции, начальное значение функции, конечное значение и шаг увеличения аргумента.
        /// </summary>
        /// <returns>Возвращаем массив значений с ответами пользователя: 
        /// номер функции, начальное значение функции, конечное значение и шаг увеличения аргумента.</returns>
        public static double[] GetUserAnswer()
        {
            double[] inputValues;

            Console.WriteLine("\nСначала укажите номер функции, потом через пробелы: начальное значение функции, " +
                "конечное значение и шаг увеличения аргумента:");
            for (int i = 0; i < functions.Count; i++)
            {
                Console.WriteLine($"№{i + 1}: {functions.Values.ElementAt(i)} ");
            }

            while (true)
            {
                if (CheckOutput(out inputValues, functions.Count)) break;
                Console.WriteLine("\nНеверный формат входящих даный. Попробуйте ещё:");
            }
            return inputValues;
        }

        /// <summary>
        /// Проверяем корректность введённых пользователем данных. Возвращаем true, если всё корректно.
        /// </summary>
        /// <param name="inputValues">Массив значений пользователя для проверки</param>
        /// <param name="maxValue">Количество функций для выбора пользователем</param>
        /// <returns>Возвращаем true, если всё корректно.</returns>
        private static bool CheckOutput(out double[] inputValues, int maxValue)
        {
            try
            {
                int size = 4;
                inputValues = new double[size];
                string[] str = Console.ReadLine().Split(' ');
                for (int i = 0; i < inputValues.Length; i++)
                {
                    if (!double.TryParse(str[i], out inputValues[i])) return false;
                    if (i == 0 && (inputValues[i] < 1 || inputValues[i] > maxValue)) return false;
                    else inputValues[i]--;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inputValues = (double[])Array.CreateInstance(typeof(double), 0);
                return false;
            }
        }

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }


        /// <summary>
        /// Рассчитывает данные по значению функции и сохраняет данные в файл
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="result">Делегат для передачи функции для расчёта</param>
        /// <param name="a">Начальное значение х</param>
        /// <param name="b">Конечное значение х</param>
        /// <param name="h">Шаг увеличения х</param>
        public static void SaveFunc(string fileName, Func<double, double> result, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(result(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Загружает данные из файла и возвращает массив их значений, 
        /// дополнительно находи и возвращает через out минимальное число
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="min">Возвращает через out минимальное число</param>
        /// <returns>Загружает данные из файла и возвращает массив их значений</returns>
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            List<double> list = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                list.Add(bw.ReadDouble());
                if (list.Last() < min) min = list.Last();
            }
            bw.Close();
            fs.Close();
            return list;
        }
    }
}

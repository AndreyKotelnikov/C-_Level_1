using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lesson5_HomeWork
{
    class Pupil
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public int[] Grades { get; set; }
        public static int NumbersOfPuples { get; private set; }

        public Pupil(string surname, string name, int[] grades)
        {
            Surname = surname;
            Name = name;
            Grades = grades;
            NumbersOfPuples++;
        }

        /// <summary>
        /// Создаёт массив, загружая количество элементов из первой строки файла, 
        /// а значения элементов по одному с каждой следующей строки файла.
        /// </summary>
        /// <param name="fileName">Строка, указывающая путь к файлу и его название</param>
        /// <returns>Возвращает новый массив с элементами класса Puple</returns>
        public static Pupil[] GetPupilsListFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(fileName, Encoding.GetEncoding(1251));
                    //Считываем количество элементов из первой строки файла
                    int size = int.Parse(streamReader.ReadLine());
                    Pupil[] pupilsList = new Pupil[size];
                    char[] separator = { ' ' };
                    for (int i = 0; i < pupilsList.Length; i++)
                    {
                        string[] tempStr = streamReader.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        int[] tempInt = new int[tempStr.Length - 2];
                        for (int j = 2; j < tempStr.Length; j++)
                        {
                            tempInt[j - 2] = int.Parse(tempStr[j]);
                        }
                        pupilsList[i] = new Pupil(tempStr[0], tempStr[1], tempInt);
                    }
                    streamReader.Close();
                    return pupilsList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else Console.WriteLine($"В указанной директории файл не обнаружен: {fileName}");
            return (Pupil[])Array.CreateInstance(typeof(Pupil), 0);
        }

        /// <summary>
        /// Выводит в консоль список учеников и их оценки. Каждый ученик с новой строки
        /// </summary>
        /// <param name="listOfPuple">Список учеников для вывода на консоль</param>
        /// <param name="outputGrades">Нужно ли выводить оценки учеников? (по умолчанию  = true)</param>
        public static void OutputListOfPuples(Pupil[] listOfPuple, bool outputGrades = true)
        {
            Console.WriteLine($"\n\nВыводим список {listOfPuple.Length} учеников {(outputGrades ? "и их оценки" : "")}:");
            foreach (var item in listOfPuple)
            {
                Console.Write($"{item.Surname, 20} {item.Name, 15} ");
                if (outputGrades)
                {
                    foreach (var grade in item.Grades)
                    {
                        Console.Write($"{grade} ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Возвращает среднюю оценку ученика
        /// </summary>
        public double AverageGrade
        {
            get
            {
                int sum = 0;
                foreach (var item in Grades)
                {
                    sum += item;
                }
                return (double)sum / Grades.Length;
            }
        }

        /// <summary>
        /// Возвращает массив с указанным количеством худших по среднему баллу учеников. Если среди остальных есть ученики, 
        /// набравшие тот же средний балл, что и один из худших, то они тоже включаются в массив.
        /// </summary>
        /// <param name="listOfPuples">Список учеников с оценками</param>
        /// <param name="numberOfLowestAverageGrades">Количество учеников с самым худшим средним баллом</param>
        /// <param name="round">Количество разрядов дробной части для округления средней оценки при сравнении</param>
        /// <returns>Возвращает массив с указанным количеством худших по среднему баллу учеников.</returns>
        public static Pupil[] GetListOfPuplesWithLowPerformance(Pupil[] listOfPuples, int numberOfLowestAverageGrades, int round)
        {
            Pupil[] listWithLowPerformance = new Pupil[listOfPuples.Length];
            double[] averageGrades = new double[listOfPuples.Length];
            double[] averageGradesForSort = new double[listOfPuples.Length];
            for (int i = 0; i < averageGrades.Length; i++)
            {
                averageGrades[i] = listOfPuples[i].AverageGrade;
                averageGradesForSort[i] = averageGrades[i];
            }
            Array.Sort(averageGradesForSort);

            int count = 0;
            for (int i = 0; i < averageGrades.Length; i++)
            {
                if ((int)(averageGradesForSort[numberOfLowestAverageGrades - 1] * Pow(10, round)) >= (int)(averageGrades[i] * Pow(10, round)))
                    listWithLowPerformance[count++] = listOfPuples[i];
            }
            Array.Resize<Pupil>(ref listWithLowPerformance, count);
            return listWithLowPerformance;
        }
    }
}

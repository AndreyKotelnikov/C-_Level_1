using System;

namespace Lesson1_HomeWork
{
    public static class UsefulMethods
    {

        static UsefulMethods()
        {
            //Console.WriteLine("Вызов статического конструктора класса UsefulMethods");
        }


        public static double GetNumberFromConsoleInput(string outputMessage)
        {
            double number;
            string answer;
            while (true)
            {
                Console.WriteLine(outputMessage);
                answer = Console.ReadLine();
                if (Double.TryParse(answer, out number))
                {
                    return number;
                }
                Console.WriteLine("Нужно ввести число. Попробуйте ещё раз\n\n");
            }
        }

        /// <summary>
        /// Рассчитывает индекс массы тела.
        /// </summary>
        /// <param name="growth">Рост в сантиметрах</param>
        /// <param name="weight">Вес в килограммах</param>
        /// <returns></returns>
        public static double BodyMassIndex(double growth, double weight)
        {
            return weight / Math.Pow(growth / 100, 2);
        }

        public static double DistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static void ConsoleOutputWithCursorPosition(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Проверяет число на чётность и возвращает true, если число чётное.
        /// </summary>
        /// <param name="number">Число для проверки его чётности</param>
        /// <returns></returns>
        public static bool EvenCheck(double number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Склонение слова для числительных. Пример: 1 год, 2 года,..., 5 лет,..., 21 год,... 
        /// </summary>
        /// <param name="i">Число, по которому определяем склонение слова</param>
        /// <param name="wordFor1">Склонение слова для i=1</param>
        /// <param name="wordFor234">Склонение слова для i=2,3,4</param>
        /// <param name="wordFor567890">Склонение слова для i=5,6,7,8,9,0</param>
        /// <returns></returns>
        public static string DeclensionWord(int i, string wordFor1 = "год", string wordFor234 = "года", string wordFor567890 = "лет")
        {
            if ((i >= 11 && i <= 14) || i % 10 >= 5 || i % 10 == 0) return wordFor567890;
            else if (i % 10 == 1) return wordFor1;
            else return wordFor234;
        }

        public static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b) a -= b; else b -= a;
            }
            return a;
        }

        /// <summary>
        /// Возвращает массив с цветами консоли.
        /// </summary>
        /// <returns>Массив с цветами консоли</returns>
        public static ConsoleColor[] ArrayOfConsoleColors() 
            => (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
    }
}

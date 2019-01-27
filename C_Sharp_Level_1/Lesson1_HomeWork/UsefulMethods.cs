using System;

namespace Lesson1_HomeWork
{
    public static class UsefulMethods
    {

        static UsefulMethods()
        {
            //Console.WriteLine("Вызов статического конструктора класса UsefulMethods");
        }

        /// <summary>
        /// Возвращает число, введённое с консоли. Перед вводом печатет указанный текст 
        /// и проверяет включение в указанный интервал min - max 
        /// </summary>
        /// <param name="outputMessage">Выводит на консоль указанный текст, по умолчанию выводит: "Введите число:"</param>
        /// <param name="min">Минимальное значение для проверки числа</param>
        /// <param name="max">Максимальное значение для проверки числа</param>
        /// <returns></returns>
        public static double GetNumberFromConsoleInput(
            string outputMessage = "Введите число:", double min = Double.MinValue, double max = Double.MaxValue, 
            bool isInteger = false)
        {
            double number;
            string answer;
            while (true)
            {
                Console.WriteLine(outputMessage);
                answer = Console.ReadLine();
                if (!Double.TryParse(answer, out number))
                    Console.WriteLine("Нужно ввести число. Попробуйте ещё раз\n\n");
                else if (isInteger == true && number.ToString().Split(',').Length > 1)
                    Console.WriteLine("\nНужно ввести целое число");
                else if (number < min) Console.WriteLine($"\nНужно ввести значение больше или равным числу {min}\n\n");
                else if (number > max) Console.WriteLine($"\nНужно ввести значение меньше или равным числу {max}\n\n");
                else return number;
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

        /// <summary>
        /// Считает сумму цифр у числа
        /// </summary>
        /// <param name="number">Число для расчёта суммы его цифр</param>
        /// <returns></returns>
        public static double SumDigitsOfNumberRecursion(double number)
        {
            if (number < 1) return 0;
            return SumDigitsOfNumberRecursion(number / 10) + (number % 10);
        }

        /// <summary>
        /// Рассчитывает отклонение в кг от нормы для данного роста. Если значение отрицательное - дефицит массы тела, если положительное - избыточная масса тела, если 0 - масса тела находится в рамках нормы
        /// </summary>
        /// <param name="growth">Рост в сантиметрах</param>
        /// <param name="weight">Вес в килограммах</param>
        public static double DeviationInBodyMassIndex(double growth, double weight)
        {
            double minNormIndex = 18.5;
            double maxNormIndex = 25;
            double bodyMassIndex = UsefulMethods.BodyMassIndex(growth, weight);

            if (bodyMassIndex <= minNormIndex)
                return (Math.Pow(growth / 100, 2) * bodyMassIndex) - (Math.Pow(growth / 100, 2) * minNormIndex);
            else if (bodyMassIndex >= maxNormIndex)
                return (Math.Pow(growth / 100, 2) * bodyMassIndex) - (Math.Pow(growth / 100, 2) * maxNormIndex);
            else return 0;
        }

        /// <summary>
        /// Проверяет совпадение логина и пароля, которые ввёл пользователь. При совпадении возвращает true.
        /// </summary>
        /// <param name="login">логин для проверки</param>
        /// <param name="password">пароль для проверки</param>
        /// <returns></returns>
        public static bool AuthorizationCheck(string login, string password)
        {
            string answer;
            Console.WriteLine("\nВведите Ваш логин:");
            answer = Console.ReadLine();
            if (answer == login)
            {
                Console.WriteLine("Введите Ваш пароль:");
                answer = Console.ReadLine();
                if (answer == password) return true;
            }
            return false;
        }

        /// <summary>
        /// Подсчитывает количество цифр в числе
        /// </summary>
        /// <param name="answer">Число для подсчёта количества его цифр</param>
        /// <returns></returns>
        public static int CountDigitsOfNumber(int number)
        {
            int count = 0;

        metka1:
            count++;
            number /= 10;
            if (number > 0) goto metka1;
            return count;
        }
    }
}

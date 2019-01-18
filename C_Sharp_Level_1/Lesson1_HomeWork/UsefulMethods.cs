using System;

namespace Lesson1_HomeWork
{
    public static class UsefulMethods
    {

        static UsefulMethods()
        {
            Console.WriteLine("Вызов статического конструктора класса UsefulMethods");
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

        public static double BodyMassIndex(double growth, double weight)
        {
            return weight / Math.Pow(growth, 2);
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
    }
}

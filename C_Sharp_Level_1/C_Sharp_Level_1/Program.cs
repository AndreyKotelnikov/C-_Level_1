using System;

#region 
/*Котельников Андрей 
 *Kурс C# Уровень 1
 *Урок 1
 *Практическая часть */
#endregion


namespace C_Sharp_Level_1
{
    class Program
    {
        static double EnterNumber(string nameOfNumber)
        {
            string answer;
            double number;

            while (true)
            {
                Console.WriteLine("Введите " + nameOfNumber + ":");
                answer = Console.ReadLine();
                if (Double.TryParse(answer, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Требуется ввести число. Попробуйте ещё раз\n");
                }
            }
        }

        private static bool EvenCheck(double number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            return false;
        }

        static void Print(string str, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }

        static void Print(string str, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = currentColor;
        }

        static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        static double Square(double a, double b, double c)
        {
            double halfPerimeter = (a + b + c) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
        }

        static void Main(string[] args)
        {
            //Задача 1.Написать программу сложения двух чисел.
            double firstNumber;
            double secondNumber;
            double summa;

            firstNumber = EnterNumber("первое число");
            secondNumber = EnterNumber("второе число");

            summa = firstNumber + secondNumber;

            Console.WriteLine("\n" + firstNumber + " + " + secondNumber + " = " + summa);

            //Задача 2.Вывести значение функции ax ^ 2 + bx + c в точке x.x — ввести с клавиатуры, a,b и c — присвоить в программе.
            { 
                double a = 10;
                double b = 10;
                double c = 10;
                double x;

                x = EnterNumber("значение X");

                Console.WriteLine("\nКвадратное уравнение: {0}*x^2 + {1}*x + {2} в точке X={3} имеет значение: {4}", a, b, c, x, a * Math.Pow(x, 2) + b * x + c);
            }

            //Задача 3. Обменять значениями две переменные.
            {
                double a = 20;
                double b = 30;
                double temp = a;
                a = b;
                b = temp;
            }

            //Задача 4. Разработать метод проверки чётности числа. Метод возвращает true, если число чётное, и false, если число нечётное.
            firstNumber = EnterNumber(" число для проверки его чётности");
            if (EvenCheck(firstNumber))
            {
                Console.WriteLine("Это чётное число\n");
            } else
            {
                Console.WriteLine("Это нечётное число\n");
            }

            //Задача 5. Работа с консолью и перегрузкой методов.
            Print("Вызываем метод Print() с указанием позиции курсора\n", 3, 20);
            Print("Вызываем перегруженный метод Print() с указанием цвета\n\n", ConsoleColor.Red);

            //Задача 6. Написать программу для подсчета площади треугольника. 
            {
                double a = EnterNumber("первую сторону треугольника");
                double b = EnterNumber("вторую сторону треугольника");
                double c = EnterNumber("третью сторону треугольника");
                if (IsTriangle(a, b, c))
                {
                    Console.WriteLine("\n\nПлощадь треугольника равна {0}", Square(a, b, c));
                }
                else
                {
                    Console.WriteLine("Это не треугольник!\n\n");
                }
            }
            Console.ReadLine();
        }
    }
}

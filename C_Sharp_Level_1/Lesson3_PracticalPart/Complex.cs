using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_PracticalPart
{
    public class Complex
    {
        double re;
        double im;
        static int countObjects = 0;

        static int CountObjects
        {
            set
            {
                countObjects++;
                if (countObjects == 3)
                {
                    Console.WriteLine($"Вы создали уже {countObjects} комплексных числа!");
                }
            }
        }

        public double Re
        {
            get { return re; }
            set {
                    if (value < 0) Console.WriteLine("Устанавливаем отрицательную вещественную часть");
                    re = value;
                }
        }

        public double Im
        {
            get { return im; }
            set {   if (value < 0) Console.WriteLine("Устанавливаем отрицательную мнимую часть");
                    im = value;
                }
        }

        public Complex()
        {
            re = 0;
            im = 0;
            //Вызываем свойство set у статического объекта оператором присваивания для инкремента значения, 
            //при этом ноль присваиваться не будет и нужен только для корректной записи операции присваивания.
            Complex.CountObjects = 0;
        }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
            //Вызываем свойство set у статического объекта оператором присваивания для инкремента значения, 
            //при этом ноль присваиваться не будет и нужен только для корректной записи операции присваивания.
            Complex.CountObjects = 0;
        }

        public Complex Plus(Complex complexIn)
        {
            Complex complexOut = new Complex(complexIn.Re + Re, complexIn.Im + Im);
            return complexOut;
        }

        public static Complex operator +(Complex complex1, Complex complex2)
        {
            Complex complexOut = new Complex(complex1.Re + complex2.Re, complex1.Im + complex2.Im);
            return complexOut;
        }

        public Complex Minus(Complex complexIn)
        {
            Complex complexOut = new Complex(Re - complexIn.Re, Im - complexIn.Im);
            return complexOut;
        }

        public static Complex operator -(Complex complex1, Complex complex2)
        {
            Complex complexOut = new Complex(complex1.Re - complex2.Re, complex1.Im - complex2.Im);
            return complexOut;
        }

        public Complex Multiplication(Complex complexIn)
        {
            Complex complexOut = new Complex(Re * complexIn.Re, Im * complexIn.Im);
            return complexOut;
        }

        public static Complex operator *(Complex complex1, Complex complex2)
        {
            Complex complexOut = new Complex(complex1.Re * complex2.Re, complex1.Im * complex2.Im);
            return complexOut;
        }

        public Complex Division(Complex complexIn)
        {
            Complex complexOut = new Complex(Re / complexIn.Re, Im / complexIn.Im);
            return complexOut;
        }

        public static Complex operator /(Complex complex1, Complex complex2)
        {
            Complex complexOut = new Complex(complex1.Re / complex2.Re, complex1.Im / complex2.Im);
            return complexOut;
        }

        public override string ToString()
        {
            return $"({Re:0.##} + {Im:0.##} i)";
        }

        /// <summary>
        /// Позволяет в консоли ввести два числа и арифметическое действие в удобном формате "(5 + 7 i) - (-8 + -5 i) =\",
        /// нужно вводить только числа и арифметическое действие, остальное программа заполняет сама.
        /// Возвращает массив из 5-ти строк с числами и арифметическим действием: {re1, im1, арифм. действие, re2, im2}
        /// </summary>
        /// <returns>Возвращает массив из 5-ти строк с числами и арифметическим действием: 
        /// {re1, im1, арифм. действие, re2, im2}</returns>
        public static string[] InputFormatArithmeticOperation()
        {
            Console.WriteLine("Введите два комплексных числа и арифметическое действие: +, -, *, /\n" +
                "Формат ввода: \"(5 + 7 i) - (-8 + -5 i) =\" " +
                "\nВам нужно вводить только числа и арифметическое действие, остальное программа сделает сама:\n");
            double numberForTryParse;
            string[] inputData = new string[5];
            string[] outputData = {"(", " + ", " i) ", " (", " + ", " i) = "};
            string[] operators = { "+", "-", "*", "/" }; 

            int cursorPositionX, cursorPositionY;
            int count = 0;

            while (true)
            {
                Console.Write(outputData[count]);
                if (inputData[count] == null)
                {
                    cursorPositionX = Console.CursorLeft;
                    cursorPositionY = Console.CursorTop;

                    inputData[count] = Console.ReadLine();
                    
                    if ((count != 2 && !Double.TryParse(inputData[count], out numberForTryParse)) 
                        || (count == 2 && !operators.Contains(inputData[count])))
                    {
                        inputData[count] = null;
                        count = 0;
                        continue;
                    }
                    else
                    {
                        Console.CursorLeft = cursorPositionX + inputData[count].Length;
                        Console.CursorTop = cursorPositionY;
                        count++;
                    }
                }
                else
                {
                    Console.Write(inputData[count]);
                    count++;
                }


                if (count == 5)
                {
                    Console.Write(outputData[count]);
                    break;
                }
            }
            return inputData;
        }

        /// <summary>
        /// Возвращает комплексное число, которое является результатом арифметического действия с двумя комплексными числами.
        /// На вход передаётся массив из 5-ти строк с числами и арифметическим действием в формате: 
        /// {re1, im1, арифм. действие, re2, im2}
        /// </summary>
        /// <param name="arrayOfStrings">массив из 5-ти строк с числами и арифметическим действием в формате: 
        /// {re1, im1, арифм. действие, re2, im2}</param>
        /// <returns>Возвращает комплексное число, которое является результатом арифметического действия с двумя комплексными числами.</returns>
        public static Complex ArithmeticOperationsWithTwoNumbers(string[] arrayOfStrings)
        {
            double[] arrayOfDoubles = new double[5];

            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                if (!Double.TryParse(arrayOfStrings[i], out arrayOfDoubles[i]) && i != 2)
                    Console.WriteLine($"В элементе {i} во входящей строке число указано некорректно"); ;
            }

            Complex complex1 = new Complex(arrayOfDoubles[0], arrayOfDoubles[1]);
            Complex complex2 = new Complex(arrayOfDoubles[3], arrayOfDoubles[4]);
            Complex complexOut = new Complex();

            switch (arrayOfStrings[2])
            {
                case "+":
                    complexOut = complex1 + complex2;
                    break;
                case "-":
                    complexOut = complex1 - complex2;
                    break;
                case "*":
                    complexOut = complex1 * complex2;
                    break;
                case "/":
                    complexOut = complex1 / complex2;
                    break;
                default:
                    Console.WriteLine("Строка не содержит нужных символов арифметических действий\n");
                    break;
            }
            return complexOut;
        }

    }
}

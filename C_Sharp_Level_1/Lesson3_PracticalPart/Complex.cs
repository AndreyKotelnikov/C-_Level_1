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
                if (countObjects == 10)
                {
                    Console.WriteLine($"Вы создали уже {countObjects} комплексных числа!");
                }
            }
        }

        public double Re
        {
            get { return re; }
            set {
                    if (value < 0)
                    {
                        Console.WriteLine("Устанавливаем отрицательную вещественную часть");
                        re = value;
                    }
            }
        }

        public double Im
        {
            get { return im; }
            set {   if (value < 0)
                    {
                        Console.WriteLine("Устанавливаем отрицательную мнимую часть");
                        im = value;
                    }
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

        public static Complex InputFormatArithmeticOperation()
        {
            Console.WriteLine("Введите два комплексных числа и арифметическое действие: +, -, *, /\n" +
                "Формат ввода: \"(5 + 7 i) - (-8 + -5 i) =\" " +
                "\nВам нужно вводить только числа и арифметическое действие, остальное программа сделает сама:\n");
            double[] inputNumbers = new double[5];
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
                    
                    if ((count != 2 && !Double.TryParse(inputData[count], out inputNumbers[count])) 
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

            Complex complex1 = new Complex(inputNumbers[0], inputNumbers[1]);
            Complex complex2 = new Complex(inputNumbers[3], inputNumbers[4]);
            Complex complexOut = new Complex();

            switch (inputData[2])
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
                    Console.WriteLine("Вы запустили программу на другой планете!\n");
                    break;
            }

            return complexOut;
        }
    }
}

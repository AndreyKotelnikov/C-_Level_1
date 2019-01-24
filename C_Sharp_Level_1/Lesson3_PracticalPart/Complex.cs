using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_PracticalPart
{
    class Complex
    {
        double re;
        double im;

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
        }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
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

        public override string ToString()
        {
            return $"({Re}, {Im})";
        }
    }
}

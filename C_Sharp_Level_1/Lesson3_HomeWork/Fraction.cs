using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lesson3_HomeWork
{
    public class Fraction
    {
        int denominator;

        public int Numerator { get; set; }

        public int Denominator { get => denominator; set => denominator = value == 0 ? 1 : value; }

        public double DecimalFraction { get => Numerator / (double)Denominator; }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator == 0 ? 1 : denominator;
        }

        public Fraction Plus(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = Numerator + fraction2.Numerator;
            fractionOut.Denominator = Denominator + fraction2.Denominator;
            return fractionOut;
        }

        public Fraction Minus(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = Numerator - fraction2.Numerator;
            fractionOut.Denominator = Denominator - fraction2.Denominator;
            return fractionOut;
        }

        public Fraction Multiplication(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = Numerator * fraction2.Numerator;
            fractionOut.Denominator = Denominator * fraction2.Denominator;
            return fractionOut;
        }

        public Fraction Division(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = Numerator / fraction2.Numerator;
            fractionOut.Denominator = Denominator / fraction2.Denominator;
            return fractionOut;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = fraction1.Numerator + fraction2.Numerator;
            fractionOut.Denominator = fraction1.Denominator + fraction2.Denominator;
            return fractionOut;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = fraction1.Numerator - fraction2.Numerator;
            fractionOut.Denominator = fraction1.Denominator - fraction2.Denominator;
            return fractionOut;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = fraction1.Numerator * fraction2.Numerator;
            fractionOut.Denominator = fraction1.Denominator * fraction2.Denominator;
            return fractionOut;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.Numerator = fraction1.Numerator / fraction2.Numerator;
            fractionOut.Denominator = fraction1.Denominator / fraction2.Denominator;
            return fractionOut;
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
    }
}

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
        int numerator;
        int denominator;

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator == 0 ? 1 : denominator;
        }

        public Fraction Plus(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = this.numerator + fraction2.numerator;
            fractionOut.denominator = this.denominator + fraction2.denominator;
            return fractionOut;
        }

        public Fraction Minus(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = this.numerator - fraction2.numerator;
            fractionOut.denominator = this.denominator - fraction2.denominator;
            return fractionOut;
        }

        public Fraction Multiplication(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = this.numerator * fraction2.numerator;
            fractionOut.denominator = this.denominator * fraction2.denominator;
            return fractionOut;
        }

        public Fraction Division(Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = this.numerator / fraction2.numerator;
            fractionOut.denominator = this.denominator / fraction2.denominator;
            return fractionOut;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = fraction1.numerator + fraction2.numerator;
            fractionOut.denominator = fraction1.denominator + fraction2.denominator;
            return fractionOut;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = fraction1.numerator - fraction2.numerator;
            fractionOut.denominator = fraction1.denominator - fraction2.denominator;
            return fractionOut;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = fraction1.numerator * fraction2.numerator;
            fractionOut.denominator = fraction1.denominator * fraction2.denominator;
            return fractionOut;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            Fraction fractionOut = new Fraction();
            fractionOut.numerator = fraction1.numerator / fraction2.numerator;
            fractionOut.denominator = fraction1.denominator / fraction2.denominator;
            return fractionOut;
        }

        public override string ToString() => $"{numerator}/{denominator}";
    }
}

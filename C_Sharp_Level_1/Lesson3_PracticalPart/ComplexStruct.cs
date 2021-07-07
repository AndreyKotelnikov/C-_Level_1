﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_PracticalPart
{
    public struct ComplexStruct
    {
        readonly double re;
        readonly double im;

        public double Re => re;
        public double Im => im;

        public ComplexStruct(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public ComplexStruct Plus(ComplexStruct complexStructIn)
        {
            ComplexStruct complexStructOut = new ComplexStruct(complexStructIn.Re + Re, complexStructIn.Im + Im);
            return complexStructOut;
        }

        public static ComplexStruct operator +(ComplexStruct complex1, ComplexStruct complex2)
        {
            ComplexStruct complexStructOut = new ComplexStruct(complex1.Re + complex2.Re, complex1.Im + complex2.Im);
            return complexStructOut;
        }

        public ComplexStruct Minus(ComplexStruct complexStructIn)
        {
            ComplexStruct complexStructOut = new ComplexStruct(Re - complexStructIn.Re, Im - complexStructIn.Im);
            return complexStructOut;
        }

        public static ComplexStruct operator -(ComplexStruct complex1, ComplexStruct complex2)
        {
            ComplexStruct complexStructOut = new ComplexStruct(complex1.Re - complex2.Re, complex1.Im - complex2.Im);
            return complexStructOut;
        }

        public override string ToString()
        {
            return $"({Re} + {Im} i)";
        }
    }
}
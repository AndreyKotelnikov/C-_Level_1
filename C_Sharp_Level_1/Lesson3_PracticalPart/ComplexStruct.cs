using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_PracticalPart
{
    struct ComplexStruct
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
            ComplexStruct complexStructOut = new ComplexStruct(complexStructIn.Re + this.Re, complexStructIn.Im + this.Im);
            return complexStructOut;
        }

        public static ComplexStruct operator +(ComplexStruct complex1, ComplexStruct complex2)
        {
            ComplexStruct complexStructOut = new ComplexStruct(complex1.Re + complex2.Re, complex1.Im + complex2.Im);
            return complexStructOut;
        }

        public override string ToString()
        {
            return $"({this.Re}, {this.Im})";
        }
    }
}

using System;

namespace Mathematics
{
    class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginari { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber x = obj as ComplexNumber;
                return x.Real == Real && x.Imaginari == Imaginari;
            }
            return base.Equals(obj);
        }
        public readonly static ComplexNumber Zero = new ComplexNumber()
        {
            Real = 0,
            Imaginari = 0
        };
        public ComplexNumber Multiply(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real * b.Real - a.Imaginari * b.Imaginari,
                Imaginari = (a.Real * b.Imaginari + a.Imaginari * b.Real)
            };
        }
        public double GetAbsoluteValue()
        {
            return Math.Sqrt(Real * Real + Imaginari * Imaginari);
        }
        public ComplexNumber Add(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real + b.Real,
                Imaginari = a.Imaginari + b.Imaginari
            };
        }
        public double GetAngleInRadiansFromComplexNumber()
        {
            return Math.Atan(Imaginari / Real);
        }
        public ComplexNumber Subtract(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real - b.Real,
                Imaginari = a.Imaginari - b.Imaginari
            };
        }
        public override string ToString()
        {
            return $"({Real} + {Imaginari}i)";
        }
        public ComplexNumber Divide(ComplexNumber b)
        {
            var dividend = Multiply(new ComplexNumber() { Real = b.Real, Imaginari = -b.Imaginari });
            var divisor = b.Real * b.Real + b.Imaginari * b.Imaginari;

            return new ComplexNumber()
            {
                Real = dividend.Real / divisor,
                Imaginari = (dividend.Imaginari / divisor)
            };
        }
    }
}
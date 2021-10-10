using System;

namespace Mathematics
{
    public class ComplexNumber
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public readonly static ComplexNumber Zero = new ComplexNumber()
        {
            RealPart = 0,
            ImaginaryPart = 0
        };

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber x = obj as ComplexNumber;
                return x.RealPart == RealPart && x.ImaginaryPart == ImaginaryPart;
            }
            return base.Equals(obj);
        }

        public ComplexNumber Multiply(ComplexNumber b)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart * b.RealPart - this.ImaginaryPart * b.ImaginaryPart,
                ImaginaryPart = this.RealPart * b.ImaginaryPart + this.ImaginaryPart * b.RealPart
            };
        }

        public ComplexNumber Divide(ComplexNumber b)
        {
            ComplexNumber tmp = this.Multiply(new ComplexNumber() { RealPart = b.RealPart, ImaginaryPart = -b.ImaginaryPart });
            double tmp2 = b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart;

            return new ComplexNumber()
            {
                RealPart = tmp.RealPart / tmp2,
                ImaginaryPart = tmp.ImaginaryPart / tmp2
            };
        }

        public double GetAbs()
        {
            return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }

        public ComplexNumber Add(ComplexNumber b)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart + b.RealPart,
                ImaginaryPart = this.ImaginaryPart + b.ImaginaryPart
            };
        }

        public ComplexNumber Subtract(ComplexNumber b)
        {
            return new ComplexNumber()
            {
                RealPart = this.RealPart - b.RealPart,
                ImaginaryPart = this.ImaginaryPart - b.ImaginaryPart
            };
        }

        public double GetAngle()
        {
            return Math.Atan(ImaginaryPart / RealPart);
        }

        public override string ToString()
        {
            return $"({RealPart} + {ImaginaryPart}i)";
        }

    }
}
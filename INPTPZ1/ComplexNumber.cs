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
        public ComplexNumber Add(ComplexNumber secondNumber)
        {
            return new ComplexNumber()
            {
                RealPart = RealPart + secondNumber.RealPart,
                ImaginaryPart = ImaginaryPart + secondNumber.ImaginaryPart
            };
        }

        public ComplexNumber Subtract(ComplexNumber secondNumber)
        {
            return new ComplexNumber()
            {
                RealPart = RealPart - secondNumber.RealPart,
                ImaginaryPart = ImaginaryPart - secondNumber.ImaginaryPart
            };
        }

        public ComplexNumber Multiply(ComplexNumber secondNumber)
        {
            return new ComplexNumber()
            {
                RealPart = RealPart * secondNumber.RealPart - ImaginaryPart * secondNumber.ImaginaryPart,
                ImaginaryPart = RealPart * secondNumber.ImaginaryPart + ImaginaryPart * secondNumber.RealPart
            };
        }

        public ComplexNumber Divide(ComplexNumber secondNumber)
        {
            ComplexNumber dividedNumber = Multiply(new ComplexNumber() { 
                RealPart = secondNumber.RealPart, 
                ImaginaryPart = -secondNumber.ImaginaryPart 
            });

            double divider = Math.Pow(secondNumber.RealPart, 2) + Math.Pow(secondNumber.ImaginaryPart, 2);

            return new ComplexNumber()
            {
                RealPart = dividedNumber.RealPart / divider,
                ImaginaryPart = dividedNumber.ImaginaryPart / divider
            };
        }

        public double GetAbs()
        {
            return Math.Sqrt(Math.Pow(RealPart, 2) + Math.Pow(ImaginaryPart, 2));
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
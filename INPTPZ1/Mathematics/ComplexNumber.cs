using System;

namespace INPTPZ1.Mathematics
{
    public class ComplexNumber
    {
        public readonly static ComplexNumber Zero = new ComplexNumber()
        {
            Re = 0,
            Im = 0
        };

        private readonly int SquareExponent = 2;

        public double Re { get; set; }
        public double Im { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber x = obj as ComplexNumber;
                return x.Re == Re && x.Im == Im;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashCode = 29377563;
            hashCode = hashCode * -1521134295 + Re.GetHashCode();
            hashCode = hashCode * -1521134295 + Im.GetHashCode();
            return hashCode;
        }

        public double GetAbs()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }

        public double GetAngle()
        {
            return Math.Atan(Im / Re);
        }

        public ComplexNumber Add(ComplexNumber otherNumber)
        {
            return new ComplexNumber()
            {
                Re = Re + otherNumber.Re,
                Im = Im + otherNumber.Im
            };
        }

        public ComplexNumber Subtract(ComplexNumber otherNumber)
        {
            return new ComplexNumber()
            {
                Re = Re - otherNumber.Re,
                Im = Im - otherNumber.Im
            };
        }

        public ComplexNumber Multiply(ComplexNumber otherNumber)
        {
            return new ComplexNumber()
            {
                Re = Re * otherNumber.Re - Im * otherNumber.Im,
                Im = Re * otherNumber.Im + Im * otherNumber.Re
            };
        }

        public ComplexNumber Divide(ComplexNumber otherNumber)
        {
            ComplexNumber dividend = Multiply(new ComplexNumber() 
            { 
                Re = otherNumber.Re, 
                Im = -otherNumber.Im 
            });

            double divisor = otherNumber.Re * otherNumber.Re + otherNumber.Im * otherNumber.Im;

            return new ComplexNumber()
            {
                Re = dividend.Re / divisor,
                Im = dividend.Im / divisor
            };
        }

        public double GetComplexConjugateProduct()
        {
            return SquareNumber(Re) + SquareNumber(Im);
        }

        public double SquareAndAddRealAndImaginaryDifferences(ComplexNumber otherNumber)
        {
            return SquareNumber(Re - otherNumber.Re) + SquareNumber(Im - otherNumber.Im);
        }

        public override string ToString()
        {
            return $"({Re} + {Im}i)";
        }

        private double SquareNumber(double number)
        {
            return Math.Pow(number, SquareExponent);
        }
    }
}

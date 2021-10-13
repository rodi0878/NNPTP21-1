using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public readonly static ComplexNumber ZERO = new ComplexNumber()
            {
                Real = 0,
                Imaginary = 0
            };

            public double Real { get; set; }
            public double Imaginary { get; set; }

            public ComplexNumber Add(ComplexNumber complexNumberToAdd)
            {
                return new ComplexNumber()
                {
                    Real = this.Real + complexNumberToAdd.Real,
                    Imaginary = this.Imaginary + complexNumberToAdd.Imaginary
                };
            }

            public ComplexNumber Subtract(ComplexNumber complexNumberToSubstract)
            {
                return new ComplexNumber()
                {
                    Real = this.Real - complexNumberToSubstract.Real,
                    Imaginary = this.Imaginary - complexNumberToSubstract.Imaginary
                };
            }

            public ComplexNumber Multiply(ComplexNumber complexNumberToMultiply)
            {
                return new ComplexNumber()
                {
                    Real = this.Real * complexNumberToMultiply.Real - this.Imaginary * complexNumberToMultiply.Imaginary,
                    Imaginary = this.Real * complexNumberToMultiply.Imaginary + this.Imaginary * complexNumberToMultiply.Real
                };
            }

            public ComplexNumber Divide(ComplexNumber complexNumberToDivide)
            {
                var dividedNumber = this.Multiply(new ComplexNumber() { Real = complexNumberToDivide.Real, Imaginary = -complexNumberToDivide.Imaginary });
                var divisor = complexNumberToDivide.Real * complexNumberToDivide.Real + complexNumberToDivide.Imaginary * complexNumberToDivide.Imaginary;

                return new ComplexNumber()
                {
                    Real = dividedNumber.Real / divisor,
                    Imaginary = dividedNumber.Imaginary / divisor
                };
            }

            public double GetAbs()
            {
                return Math.Sqrt(Real * Real + Imaginary * Imaginary);
            }

            public double GetAngleInRadians()
            {
                return Math.Atan(Imaginary / Real);
            }

            public override string ToString()
            {
                return $"({Real} + {Imaginary}i)";
            }

            public override bool Equals(object obj)
            {
                if (obj is ComplexNumber)
                {
                    ComplexNumber complexNumber = obj as ComplexNumber;
                    return complexNumber.Real == Real && complexNumber.Imaginary == Imaginary;
                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                var hashCode = -837395861;
                hashCode = hashCode * -1521134295 + Real.GetHashCode();
                hashCode = hashCode * -1521134295 + Imaginary.GetHashCode();
                return hashCode;
            }
        }
    }
}

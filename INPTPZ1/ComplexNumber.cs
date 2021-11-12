using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }

            public readonly static ComplexNumber Zero = new ComplexNumber()
            {
                Real = 0,
                Imaginary = 0
            };
            public override bool Equals(object obj)
            {
                if (obj is ComplexNumber)
                {
                    ComplexNumber CheckedComplexNumber = obj as ComplexNumber;
                    return CheckedComplexNumber.Real == Real && CheckedComplexNumber.Imaginary == Imaginary;
                }
                return base.Equals(obj);
            }

            public ComplexNumber Add(ComplexNumber complexNumberToAdd)
            {
                return new ComplexNumber()
                {
                    Real = Real + complexNumberToAdd.Real,
                    Imaginary = Imaginary + complexNumberToAdd.Imaginary
                };
            }
            public ComplexNumber Subtract(ComplexNumber complexNumberToSubstract)
            {
                return new ComplexNumber()
                {
                    Real = Real - complexNumberToSubstract.Real,
                    Imaginary = Imaginary - complexNumberToSubstract.Imaginary
                };
            }
            public ComplexNumber Multiply(ComplexNumber complexNumberToMultiply)
            {
                return new ComplexNumber()
                {
                    Real = Real * complexNumberToMultiply.Real - Imaginary * complexNumberToMultiply.Imaginary,
                    Imaginary = Real * complexNumberToMultiply.Imaginary + Imaginary * complexNumberToMultiply.Real
                };
            }
            public ComplexNumber Divide(ComplexNumber complexNumberToDivide)
            {
                var dividend = Multiply(new ComplexNumber() { Real = complexNumberToDivide.Real, Imaginary = -complexNumberToDivide.Imaginary });
                var divisor = complexNumberToDivide.Real * complexNumberToDivide.Real + complexNumberToDivide.Imaginary * complexNumberToDivide.Imaginary;

                return new ComplexNumber()
                {
                    Real = dividend.Real / divisor,
                    Imaginary = dividend.Imaginary / divisor
                };
            }
            public double GetAbsoluteValue()
            {
                return Math.Sqrt(Real * Real + Imaginary * Imaginary);
            }


            public double GetAngle()
            {
                return Math.Atan(Imaginary / Real);
            }


            public override string ToString()
            {
                return $"({Real} + {Imaginary}i)";
            }

            public override int GetHashCode()
            {
                int hashCode = -837395861;
                hashCode = hashCode * -1521134295 + Real.GetHashCode();
                hashCode = hashCode * -1521134295 + Imaginary.GetHashCode();
                return hashCode;
            }
        }
    }
}

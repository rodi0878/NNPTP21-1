using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double Re { get; set; }
            public double Im { get; set; }

            public static readonly ComplexNumber Zero = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };

            public override bool Equals(object complexNum)
            {
                if (complexNum is ComplexNumber complexNumber)
                {
                    return complexNumber.Re == Re && complexNumber.Im == Im;
                }
                return base.Equals(complexNum);
            }

            public ComplexNumber Multiply(ComplexNumber b)
            {
                return new ComplexNumber()
                {
                    Re = Re * b.Re - Im * b.Im,
                    Im = Re * b.Im + Im * b.Re
                };
            }

            public double GetAbsoluteValue()
            {
                return Math.Sqrt(Re * Re + Im * Im);
            }

            public ComplexNumber Add(ComplexNumber b)
            {
                return new ComplexNumber()
                {
                    Re = Re + b.Re,
                    Im = Im + b.Im
                };
            }

            public double GetAngle()
            {
                return Math.Atan(Im / Re);
            }

            public ComplexNumber Subtract(ComplexNumber b)
            {
                return new ComplexNumber()
                {
                    Re = Re - b.Re,
                    Im = Im - b.Im
                };
            }

            public ComplexNumber Divide(ComplexNumber divisor)
            {
                ComplexNumber numerator = GetNumeratorForDiving(divisor);
                double denominator = GetDenominatorForDiving(divisor);

                return new ComplexNumber()
                {
                    Re = numerator.Re / denominator,
                    Im = numerator.Im / denominator
                };
            }

            public override string ToString()
            {
                return $"({Re} + {Im}i)";
            }

            private ComplexNumber GetNumeratorForDiving(ComplexNumber complexNumber)
            {
                return Multiply(new ComplexNumber() { Re = complexNumber.Re, Im = -complexNumber.Im });
            }

            private double GetDenominatorForDiving(ComplexNumber complexNumber)
            {
                return complexNumber.Re * complexNumber.Re + complexNumber.Im * complexNumber.Im;
            }
        }
    }
}

using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public static readonly ComplexNumber ZERO = new ComplexNumber() { Re = 0, Im = 0 };

            public double Re { get; set; }
            public double Im { get; set; }

            public override bool Equals(object expression)
            {
                if (expression is ComplexNumber complexNumberExpression)
                {
                    return complexNumberExpression.Re == Re && complexNumberExpression.Im == Im;
                }
                return base.Equals(expression);
            }

            public ComplexNumber Multiply(ComplexNumber multiplier)
            {
                ComplexNumber multiplicand = this;
                return new ComplexNumber()
                {
                    Re = multiplicand.Re * multiplier.Re - multiplicand.Im * multiplier.Im,
                    Im = multiplicand.Re * multiplier.Im + multiplicand.Im * multiplier.Re
                };
            }

            public double GetAbs()
            {
                return Math.Sqrt( Re * Re + Im * Im);
            }

            public ComplexNumber Add(ComplexNumber addend)
            {
                ComplexNumber augend = this;
                return new ComplexNumber()
                {
                    Re = augend.Re + addend.Re,
                    Im = augend.Im + addend.Im
                };
            }

            public double GetAngleInRadians()
            {
                return Math.Atan(Im / Re);
            }

            public ComplexNumber Subtract(ComplexNumber subtrahend)
            {
                ComplexNumber minuend = this;
                return new ComplexNumber()
                {
                    Re = minuend.Re - subtrahend.Re,
                    Im = minuend.Im - subtrahend.Im
                };
            }

            public override string ToString()
            {
                return $"({Re} + {Im}i)";
            }

            internal ComplexNumber Divide(ComplexNumber divisor)
            {
                ComplexNumber numerator = Multiply(new ComplexNumber() { Re = divisor.Re, Im = -divisor.Im });
                double denominator = divisor.Re * divisor.Re + divisor.Im * divisor.Im;

                return new ComplexNumber()
                {
                    Re = numerator.Re / denominator,
                    Im = numerator.Im / denominator
                };
            }

            public override int GetHashCode()
            {
                int hashCode = 29377563;
                hashCode = hashCode * -1521134295 + Re.GetHashCode();
                hashCode = hashCode * -1521134295 + Im.GetHashCode();
                return hashCode;
            }
        }
    }
}

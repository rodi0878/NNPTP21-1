using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double Re { get; set; }
            public double Im { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is ComplexNumber)
                {
                    ComplexNumber complexNumber = obj as ComplexNumber;
                    return complexNumber.Re == Re && complexNumber.Im == Im;
                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                var hashCode = 29377563;
                hashCode = hashCode * -1521134295 + Re.GetHashCode();
                hashCode = hashCode * -1521134295 + Im.GetHashCode();
                return hashCode;
            }

            public readonly static ComplexNumber Zero = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };
            public ComplexNumber Add(ComplexNumber secondNumber)
            {
                return new ComplexNumber()
                {
                    Re = Re + secondNumber.Re,
                    Im = Im + secondNumber.Im
                };
            }

            public ComplexNumber Multiply(ComplexNumber secondNumber)
            {
                return new ComplexNumber()
                {
                    Re = Re * secondNumber.Re - Im * secondNumber.Im,
                    Im = Re * secondNumber.Im + Im * secondNumber.Re
                };
            }

            public ComplexNumber Subtract(ComplexNumber secondNumber)
            {
                return new ComplexNumber()
                {
                    Re = Re - secondNumber.Re,
                    Im = Im - secondNumber.Im
                };
            }

            public ComplexNumber Divide(ComplexNumber secondNumber)
            {
                ComplexNumber dividedNumber = Multiply(new ComplexNumber() { Re = secondNumber.Re, Im = -secondNumber.Im });
                double divisor = Math.Pow(secondNumber.Re, 2) + Math.Pow(secondNumber.Im, 2);

                return new ComplexNumber()
                {
                    Re = dividedNumber.Re / divisor,
                    Im = dividedNumber.Im / divisor
                };
            }
            public double GetAbsoluteValue()
            {
                return Math.Sqrt( Math.Pow(Re,2) + Math.Pow(Im, 2));
            }

            public double GetAngle()
            {
                return Math.Atan(Im / Re);
            }

            public override string ToString()
            {
                return $"({Re} + {Im}i)";
            }

        }
    }
}

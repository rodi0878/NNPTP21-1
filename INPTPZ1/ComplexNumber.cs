using System;

namespace INPTPZ1.Mathematics
{
    public class ComplexNumber
    {
        public readonly static ComplexNumber ZERO = new ComplexNumber()
        {
            Re = 0,
            Im = 0
        };
        public double Re { get; set; }
        public double Im { get; set; }

        public ComplexNumber Add(ComplexNumber addend)
        {
            return new ComplexNumber()
            {
                Re = Re + addend.Re,
                Im = Im + addend.Im
            };
        }

        public ComplexNumber Subtract(ComplexNumber substrahend)
        {
            return new ComplexNumber()
            {
                Re = Re - substrahend.Re,
                Im = Im - substrahend.Im
            };
        }

        public ComplexNumber Multiply(ComplexNumber multiplicand)
        {
            return new ComplexNumber()
            {
                Re = Re * multiplicand.Re - Im * multiplicand.Im,
                Im = Re * multiplicand.Im + Im * multiplicand.Re
            };
        }

        public ComplexNumber Divide(ComplexNumber divisor)
        {
            double calculatedDivisor = (divisor.Re * divisor.Re + divisor.Im * divisor.Im);
            ComplexNumber calculatedDividend = Multiply(GetConjugate());

            return new ComplexNumber()
            {
                Re = calculatedDividend.Re / calculatedDivisor,
                Im = calculatedDividend.Im / calculatedDivisor
            };
        }

        public double GetAngle()
        {
            return Math.Atan(Im / Re);
        }

        public double GetAbs()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }

        public override string ToString()
        {
            return $"({Re} + {Im}i)";
        }

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

        private ComplexNumber GetConjugate()
        {
            return new ComplexNumber() { Re = Re, Im = -Im };
        }
    }
}

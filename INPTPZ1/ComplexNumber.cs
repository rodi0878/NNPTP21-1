using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public readonly static ComplexNumber Zero = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };
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

            public ComplexNumber Add(ComplexNumber b)
            {
                ComplexNumber a = this;
                return new ComplexNumber()
                {
                    Re = a.Re + b.Re,
                    Im = a.Im + b.Im
                };
            }

            public ComplexNumber Subtract(ComplexNumber b)
            {
                ComplexNumber a = this;
                return new ComplexNumber()
                {
                    Re = a.Re - b.Re,
                    Im = a.Im - b.Im
                };
            }

            public ComplexNumber Multiply(ComplexNumber b)
            {
                ComplexNumber a = this;
                // aRe*bRe + aRe*bIm*i + aIm*bRe*i + aIm*bIm*i*i
                return new ComplexNumber()
                {
                    Re = a.Re * b.Re - a.Im * b.Im,
                    Im = (float)(a.Re * b.Im + a.Im * b.Re)
                };
            }

            public ComplexNumber Divide(ComplexNumber b)
            {
                // (aRe + aIm*i) / (bRe + bIm*i)
                // ((aRe + aIm*i) * (bRe - bIm*i)) / ((bRe + bIm*i) * (bRe - bIm*i))
                //  bRe*bRe - bIm*bIm*i*i
                var dividend = Multiply(new ComplexNumber() { Re = b.Re, Im = -b.Im });
                var divisor = b.Re * b.Re + b.Im * b.Im;

                return new ComplexNumber()
                {
                    Re = dividend.Re / divisor,
                    Im = (float)(dividend.Im / divisor)
                };
            }

            public override string ToString()
            {
                return $"({Re} + {Im}i)";
            }


        }
    }
}

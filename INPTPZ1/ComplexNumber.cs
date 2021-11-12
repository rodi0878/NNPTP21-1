using System;

namespace INPTPZ1
{
    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double RealPart { get; set; }
            public double ImaginaryPart { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is ComplexNumber)
                {
                    ComplexNumber complexNumber = obj as ComplexNumber;
                    return complexNumber.RealPart == RealPart && complexNumber.ImaginaryPart == ImaginaryPart;
                }
                return base.Equals(obj);
            }

            public readonly static ComplexNumber Zero = new ComplexNumber()
            {
                RealPart = 0,
                ImaginaryPart = 0
            };

            public ComplexNumber Multiply(ComplexNumber complexNumber2)
            {
                ComplexNumber complexNumber1 = this;
                return new ComplexNumber()
                {
                    RealPart = complexNumber1.RealPart * complexNumber2.RealPart - complexNumber1.ImaginaryPart * complexNumber2.ImaginaryPart,
                    ImaginaryPart = complexNumber1.RealPart * complexNumber2.ImaginaryPart + complexNumber1.ImaginaryPart * complexNumber2.RealPart
                };
            }
            public double GetAbsoluteOfSquareRoot()
            {
                return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
            }

            public ComplexNumber Add(ComplexNumber complexNumber2)
            {
                ComplexNumber complexNumber1 = this;
                return new ComplexNumber()
                {
                    RealPart = complexNumber1.RealPart + complexNumber2.RealPart,
                    ImaginaryPart = complexNumber1.ImaginaryPart + complexNumber2.ImaginaryPart
                };
            }
            public double GetAngleInDegrees()
            {
                return Math.Atan(ImaginaryPart / RealPart);
            }
            public ComplexNumber Subtract(ComplexNumber complexNumber2)
            {
                ComplexNumber complexNumber1 = this;
                return new ComplexNumber()
                {
                    RealPart = complexNumber1.RealPart - complexNumber2.RealPart,
                    ImaginaryPart = complexNumber1.ImaginaryPart - complexNumber2.ImaginaryPart
                };
            }

            public override string ToString()
            {
                return $"({RealPart} + {ImaginaryPart}i)";
            }

            internal ComplexNumber Divide(ComplexNumber complexNumber)
            {
                ComplexNumber numerator = this.Multiply(new ComplexNumber() { RealPart = complexNumber.RealPart, ImaginaryPart = -complexNumber.ImaginaryPart });
                double denominator = complexNumber.RealPart * complexNumber.RealPart + complexNumber.ImaginaryPart * complexNumber.ImaginaryPart;

                return new ComplexNumber()
                {
                    RealPart = numerator.RealPart / denominator,
                    ImaginaryPart = numerator.ImaginaryPart / denominator
                };
            }
        }
    }    
}
using System;

namespace Mathematics
{
    public class ComplexNumber
    {
        /// <summary>
        /// New ComplexNumber with zero values
        /// </summary>
        public readonly static ComplexNumber Zero = new ComplexNumber()
        {
            Real = 0,
            Imaginary = 0
        };
        /// <summary>
        /// Real part of complex number
        /// </summary>
        public double Real { get; set; }
        /// <summary>
        /// Imaginary part of complex number
        /// </summary>
        public double Imaginary { get; set; }
        /// <summary>
        /// Compare ComplexNumber with object
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>true - if object is the same, false - if not object is the same</returns>
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber numberForCompare = obj as ComplexNumber;
                return numberForCompare.Real == Real && numberForCompare.Imaginary == Imaginary;
            }
            return base.Equals(obj);
        }
        /// <summary>
        /// Multiply ComplexNumber with another ComplexNumber
        /// </summary>
        /// <param name="b">Second ComplexNumber</param>
        /// <returns>product of multiply two ComplexNumbers</returns>
        public ComplexNumber Multiply(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real * b.Real - a.Imaginary * b.Imaginary,
                Imaginary = (a.Real * b.Imaginary + a.Imaginary * b.Real)
            };
        }
        /// <summary>
        /// Method to get absolute value of ComplexNumber
        /// </summary>
        /// <returns>real number (absolute value)</returns>
        public double GetAbsoluteValue()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }
        /// <summary>
        /// ComplexNumber a + ComplexNumber b
        /// </summary>
        /// <param name="b">ComplexNumber b</param>
        /// <returns>Total of two ComplexNumbers</returns>
        public ComplexNumber Add(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real + b.Real,
                Imaginary = a.Imaginary + b.Imaginary
            };
        }
        /// <summary>
        /// Method get angle from complex number, because divide of Imaginary and Real part is value of tan
        /// </summary>
        /// <returns>Angle in rad</returns>
        public double GetAngleInRadiansFromComplexNumber()
        {
            return Math.Atan(Imaginary / Real);
        }
        /// <summary>
        /// Method substract ComplexNumber b from actual ComplexNumber
        /// </summary>
        /// <param name="b">ComplexNumber b</param>
        /// <returns>result of substract</returns>
        public ComplexNumber Subtract(ComplexNumber b)
        {
            ComplexNumber a = this;
            return new ComplexNumber()
            {
                Real = a.Real - b.Real,
                Imaginary = a.Imaginary - b.Imaginary
            };
        }
        /// <summary>
        /// Method divide actual complexNumber with another complex number
        /// </summary>
        /// <param name="b">another complex number</param>
        /// <returns>Result of divide</returns>
        public ComplexNumber Divide(ComplexNumber b)
        {
            var dividend = Multiply(new ComplexNumber() { Real = b.Real, Imaginary = -b.Imaginary });
            var divisor = b.Real * b.Real + b.Imaginary * b.Imaginary;

            return new ComplexNumber()
            {
                Real = dividend.Real / divisor,
                Imaginary = (dividend.Imaginary / divisor)
            };
        }
        /// <summary>
        /// Method convert ComplexNumber to string
        /// </summary>
        /// <returns>complex number in string</returns>
        public override string ToString()
        {
            return $"({Real} + {Imaginary}i)";
        }
    }
}
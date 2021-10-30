using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mathematics;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTest
    {
        [TestMethod()]
        public void EqualsTrueTest()
        {
            ComplexNumber complexNumber = new ComplexNumber { Real = 10, Imaginary = 10 };
            bool result = complexNumber.Equals(new ComplexNumber { Real = 10, Imaginary = 10 });
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EqualsFalseTest()
        {
            ComplexNumber complexNumber = new ComplexNumber { Real = 10, Imaginary = 10 };
            bool result = complexNumber.Equals(new ComplexNumber { Real = 15, Imaginary = 10 });
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 10, Imaginary = 20 };
            ComplexNumber b = new ComplexNumber { Real = 10, Imaginary = 20 };
            ComplexNumber expectedResult = new ComplexNumber { Real = -300, Imaginary = 400 };
            Assert.AreEqual(expectedResult, a.Multiply(b));
        }

        [TestMethod()]
        public void GetAbsoluteValueTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 10, Imaginary = 10 };
            double expectedValue = Math.Sqrt(10 * 10 + 10 * 10);
            Assert.AreEqual(expectedValue, a.GetAbsoluteValue());
        }

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 10, Imaginary = 10 };
            ComplexNumber b = new ComplexNumber { Real = 10, Imaginary = 10 };
            ComplexNumber expectedResult = new ComplexNumber { Real = 20, Imaginary = 20 };
            Assert.AreEqual(expectedResult, a.Add(b));
        }

        [TestMethod()]
        public void GetAngleTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 10, Imaginary = 10 };
            double expectedAngle = Math.Atan(10 / 10);
            Assert.AreEqual(expectedAngle, a.GetAngleInRadiansFromComplexNumber());
        }

        [TestMethod()]
        public void SubstractTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 20, Imaginary = 20 };
            ComplexNumber b = new ComplexNumber { Real = 10, Imaginary = 10 };
            ComplexNumber expectedValue = new ComplexNumber { Real = 10, Imaginary = 10 };
            Assert.AreEqual(expectedValue, a.Subtract(b));
        }

        [TestMethod()]
        public void DivideTest()
        {
            ComplexNumber a = new ComplexNumber { Real = 10, Imaginary = 10 };
            ComplexNumber b = new ComplexNumber { Real = 10, Imaginary = 10 };
            ComplexNumber expectedResult = new ComplexNumber { Real = 1, Imaginary = 0 };
            Assert.AreEqual(expectedResult, a.Divide(b));
        }
    }
}



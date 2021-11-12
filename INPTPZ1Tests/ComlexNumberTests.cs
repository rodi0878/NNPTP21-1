using Microsoft.VisualStudio.TestTools.UnitTesting;
using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INPTPZ1;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class CplxTests
    {
        [TestMethod()]
        public void EqualTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            bool result = complexNumber1.Equals(complexNumber2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 1, Imaginary = 2 };
            ComplexNumber actual = complexNumber1.Add(complexNumber2);
            ComplexNumber expected = new ComplexNumber() { Real = 11, Imaginary = 22 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest2()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 1, Imaginary = -1 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 20, Imaginary = 5 };
            ComplexNumber actual = complexNumber1.Add(complexNumber2);
            ComplexNumber expected = new ComplexNumber() { Real = 21, Imaginary = 4 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubstractTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 20, Imaginary = 50 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber actual = complexNumber1.Subtract(complexNumber2);
            ComplexNumber expected = new ComplexNumber() { Real = 10, Imaginary = 30 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 20, Imaginary = 50 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber actual = complexNumber1.Multiply(complexNumber2);
            ComplexNumber expected = new ComplexNumber() { Real = -800, Imaginary = 900 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 20, Imaginary = 50 };
            ComplexNumber complexNumber2 = new ComplexNumber() { Real = 10, Imaginary = 20 };
            ComplexNumber actual = complexNumber1.Divide(complexNumber2);
            ComplexNumber expected = new ComplexNumber() { Real = 2.4, Imaginary = 0.2 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AbsoluteValueTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 20, Imaginary = 50 };
            double actual = complexNumber1.GetAbsoluteValue();
            double expected = Math.Sqrt(2900);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AngleTest()
        {
            ComplexNumber complexNumber1 = new ComplexNumber() { Real = 20, Imaginary = 50 };
            double actual = complexNumber1.GetAngle();
            double expected = Math.Atan(50.0 / 20.0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Real = 10, Imaginary = 20 };
            string expected = "(10 + 20i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest2()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Real = 1, Imaginary = 2 };
            string expected = "(1 + 2i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}



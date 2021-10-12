using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {
        public ComplexNumber ComplexNumber { get; set; }

        [TestInitialize]
        public void TestInitializePolynome()
        {
            ComplexNumber = new ComplexNumber()
            {
                Real = 10,
                Imaginary = 20
            };  
        }

        [TestMethod()]
        public void TestComplexNumberAddition()
        {
            ComplexNumber result = ComplexNumber.Add(new ComplexNumber() { Real = 1, Imaginary = 2 });
            ComplexNumber expected = new ComplexNumber()
            {
                Real = 11,
                Imaginary = 22
            };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestComplexNumberSubstraction()
        {
            ComplexNumber result = ComplexNumber.Subtract(new ComplexNumber() { Real = 1, Imaginary = 2 });
            ComplexNumber expected = new ComplexNumber()
            {
                Real = 9,
                Imaginary = 18
            };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestComplexNumberMultiplication()
        {
            ComplexNumber result = ComplexNumber.Multiply(new ComplexNumber() { Real = 5, Imaginary = 2 });
            ComplexNumber expected = new ComplexNumber()
            {
                Real = 10,
                Imaginary = 120
            };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestComplexNumberAbs()
        {
            double result = ComplexNumber.GetAbs();
            double expected = Math.Sqrt(Math.Pow(10, 2) + Math.Pow(20, 2));
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestComplexNumberAngleInRadians()
        {
            double result = ComplexNumber.GetAngleInRadians();
            Assert.AreEqual(Math.Atan(20 / 10), result);
        }

        [TestMethod()]
        public void TestComplexNumberToString()
        {
            String result = ComplexNumber.ToString();
            Assert.AreEqual("(10 + 20i)", result);
        }

        [TestMethod()]
        public void TestComplexNumberZero()
        {
            ComplexNumber result = ComplexNumber.Zero;
            ComplexNumber expected = new ComplexNumber()
            {
                Real = 0,
                Imaginary = 0
            };
            Assert.AreEqual(expected, result);
        }
    }
}



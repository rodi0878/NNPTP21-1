using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumbersTests
    {

        [TestMethod()]
        public void AddComplexNumbersRe10Im20AndRe1Im2Test()
        {
            ComplexNumber a = new ComplexNumber()
            {
                Re = 10,
                Im = 20
            };

            ComplexNumber b = new ComplexNumber()
            {
                Re = 1,
                Im = 2
            };

            ComplexNumber actualNumber = a.Add(b);

            ComplexNumber expectedNumber = new ComplexNumber()
            {
                Re = 11,
                Im = 22
            };

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod()]
        public void AddComplexNumbersRe1ImNeg1AndRe0Im0Test()
        {
            ComplexNumber a = new ComplexNumber()
            {
                Re = 1,
                Im = -1
            };

            ComplexNumber b = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };

            ComplexNumber actualNumber = a.Add(b);

            ComplexNumber expectedNumber = new ComplexNumber()
            {
                Re = 1,
                Im = -1
            };

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod()]
        public void StringValueComplexNubmerRe10Im20Test()
        {
            ComplexNumber a = new ComplexNumber()
            {
                Re = 10,
                Im = 20
            };

            string expectedNumberStringValue = "(10 + 20i)";
            string actualNumberStringValue = a.ToString();

            Assert.AreEqual(expectedNumberStringValue, actualNumberStringValue);
        }

        [TestMethod()]
        public void StringValueComplexNubmerRe1Im2Test()
        {
            ComplexNumber b = new ComplexNumber()
            {
                Re = 1,
                Im = 2
            };

            string expectedNumberStringValue = "(1 + 2i)";
            string actualNumberStringValue = b.ToString();

            Assert.AreEqual(expectedNumberStringValue, actualNumberStringValue);
        }

        [TestMethod()]
        public void StringValueComplexNubmerRe1ImNeg1Test()
        {
            ComplexNumber a = new ComplexNumber()
            {
                Re = 1,
                Im = -1
            };

            string expectedNumberStringValue = "(1 + -1i)";
            string actualNumberStringValue = a.ToString();

            Assert.AreEqual(expectedNumberStringValue, actualNumberStringValue);
        }

        [TestMethod()]
        public void StringValueComplexNubmerRe0Im0Test()
        {
            ComplexNumber b = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };

            string expectedNumberStringValue = "(0 + 0i)";
            string actualNumberStringValue = b.ToString();

            Assert.AreEqual(expectedNumberStringValue, actualNumberStringValue);
        }
    }
}
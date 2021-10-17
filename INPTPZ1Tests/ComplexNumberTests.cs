using INPTPZ1.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {
        [TestMethod()]
        public void AddPositiveComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber numberB = new ComplexNumber() { Re = 1, Im = 2 };
            ComplexNumber actual = numberA.Add(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 11, Im = 22 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNegativeComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = -1, Im = -1 };
            ComplexNumber numberB = new ComplexNumber() { Re = -5, Im = -5 };
            ComplexNumber expected = new ComplexNumber() { Re = -6, Im = -6 };
            ComplexNumber actual = numberA.Add(numberB);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractPositiveComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber numberB = new ComplexNumber() { Re = 1, Im = 2 };
            ComplexNumber actual = numberA.Subtract(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 9, Im = 18 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractNegativeComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = -1, Im = -1 };
            ComplexNumber numberB = new ComplexNumber() { Re = -5, Im = -5 };
            ComplexNumber actual = numberA.Subtract(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 4, Im = 4 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyPositiveComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber numberB = new ComplexNumber() { Re = 1, Im = 2 };
            ComplexNumber actual = numberA.Multiply(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = -30, Im = 40 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyNegativeComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = -1, Im = -1 };
            ComplexNumber numberB = new ComplexNumber() { Re = -5, Im = -5 };
            ComplexNumber actual = numberA.Multiply(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 0, Im = 10 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DividePositiveComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber numberB = new ComplexNumber() { Re = 1, Im = 2 };
            ComplexNumber actual = numberA.Divide(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 10, Im = 0 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideNegativeComplexNumbersTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = -5, Im = -5 };
            ComplexNumber numberB = new ComplexNumber() { Re = -1, Im = -1 };
            ComplexNumber actual = numberA.Divide(numberB);
            ComplexNumber expected = new ComplexNumber() { Re = 5, Im = 0 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringPositiveComplexNumberTest()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 10, Im = 20 };
            string expected = "(10 + 20i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ToStringNegativeComplexNumberTest()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = -5, Im = -10 };
            string expected = "(-5 + -10i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ToStringZeroComplexNumberTest()
        {
            ComplexNumber complexNumber = ComplexNumber.Zero;
            string expected = "(0 + 0i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void EqualsComplexNumberTest()
        {
            ComplexNumber numberA = new ComplexNumber() { Re = -5, Im = -5 };
            ComplexNumber numberB = new ComplexNumber() { Re = -5, Im = -5 };
            bool equals = numberA.Equals(numberB);
            Assert.AreEqual(equals, true);
        }
    }
}



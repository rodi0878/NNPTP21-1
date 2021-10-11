using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {

        [TestMethod()]
        public void ComplexNumberAddTest()
        {
            ComplexNumber augend = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber addend = new ComplexNumber() { Re = 1, Im = 2 };

            ComplexNumber actual = augend.Add(addend);
            ComplexNumber expected = new ComplexNumber() { Re = 11, Im = 22 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberAddTestWithNeutralElement()
        {
            ComplexNumber augend = new ComplexNumber() { Re = 1, Im = -1 };
            ComplexNumber addend = new ComplexNumber() { Re = 0, Im = 0 };

            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = -1 };
            ComplexNumber actual = augend.Add(addend);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberToStringTestWith10Re20Im()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 10, Im = 20 };

            string expected = "(10 + 20i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberToStringTestWith1Re2Im()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 1, Im = 2 };

            string expected = "(1 + 2i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberToStringTestWithNegativeImaginaryPart()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 1, Im = -1 };

            string expected = "(1 + -1i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberToStringTestWith0Re0Im()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 0, Im = 0 };

            string expected = "(0 + 0i)";
            string actual = complexNumber.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}



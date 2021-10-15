using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathematics;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {
        private ComplexNumber firstNumber;
        private ComplexNumber secondNumber;

        [TestInitialize()]
        public void TestInitialize()
        {
            firstNumber = new ComplexNumber()
            {
                RealPart = 10,
                ImaginaryPart = 20
            };

            secondNumber = new ComplexNumber()
            {
                RealPart = 1,
                ImaginaryPart = 2
            };
        }

        [TestMethod()]
        public void ComplexNumberTestAdd()
        {
            ComplexNumber actual = firstNumber.Add(secondNumber);
            ComplexNumber expected = new ComplexNumber()
            {
                RealPart = 11,
                ImaginaryPart = 22
            };

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ComplexNumberTestToStringFirstNumber()
        {
            string expected = "(10 + 20i)";
            string result = firstNumber.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ComplexNumberToStringSecondNumber() 
        {
            string expected = "(1 + 2i)";
            string result = secondNumber.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ComplexNumberAddWithDifferentValues() {
            firstNumber.RealPart = 1;
            firstNumber.ImaginaryPart = -1;

            secondNumber.RealPart = 0; 
            secondNumber.ImaginaryPart = 0;

            ComplexNumber expected = new ComplexNumber() 
            { 
                RealPart = 1, 
                ImaginaryPart = -1 
            };

            ComplexNumber result = firstNumber.Add(secondNumber);       
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ComplexNumberTestToStringWithDifferentValues()
        {
            firstNumber.RealPart = 1;
            firstNumber.ImaginaryPart = -1;
            
            string expected = "(1 + -1i)";
            string result = firstNumber.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ComplexNumberTestToStringWithZeroes()
        {
            secondNumber.RealPart = 0;
            secondNumber.ImaginaryPart = 0;

            string expected = "(0 + 0i)";
            string result = secondNumber.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}



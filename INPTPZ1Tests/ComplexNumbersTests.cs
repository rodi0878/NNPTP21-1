using INPTPZ1.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests
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

            ComplexNumber resultComplexNumber = a.Add(b);
            ComplexNumber expectedComplexNumber = new ComplexNumber()
            {
                Re = 11,
                Im = 22
            };

            Assert.AreEqual(expectedComplexNumber, resultComplexNumber);
        }

        [TestMethod()]
        public void ComplexNumberRe10Im20ToStringTest()
        {
            ComplexNumber complexNumber = new ComplexNumber()
            {
                Re = 10,
                Im = 20
            };

            string resultString = complexNumber.ToString();
            string expectedString = "(10 + 20i)";

            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod()]
        public void ComplexNumberRe1Im2ToStringTest()
        {
            ComplexNumber complexNumber = new ComplexNumber()
            {
                Re = 1,
                Im = 2
            };

            string resultString = complexNumber.ToString();
            string expectedString = "(1 + 2i)";

            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod()]
        public void AddComplexNumbersRe1ImMinus1AndRe0Im0Test()
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

            ComplexNumber resultComplexNumber = a.Add(b);
            ComplexNumber expectedComplexNumber = new ComplexNumber()
            {
                Re = 1,
                Im = -1
            };

            Assert.AreEqual(expectedComplexNumber, resultComplexNumber);
        }

        [TestMethod()]
        public void ComplexNumberRe1ImMinus1ToStringTest()
        {
            ComplexNumber complexNumber = new ComplexNumber()
            {
                Re = 1,
                Im = -1
            };

            string resultString = complexNumber.ToString();
            string expectedString = "(1 + -1i)";

            Assert.AreEqual(expectedString, resultString);

        }

        [TestMethod()]
        public void ComplexNumberRe0Im0ToStringTest()
        {
            ComplexNumber complexNumber = new ComplexNumber()
            {
                Re = 0,
                Im = 0
            };
            string resultString = complexNumber.ToString();
            string expectedString = "(0 + 0i)";

            Assert.AreEqual(expectedString, resultString);
        }

    }

}



using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {

        [TestMethod()]
        public void AddTest1()
        {
            ComplexNumber augend = new ComplexNumber() { Re = 10, Im = 20 };
            ComplexNumber addend = new ComplexNumber() { Re = 1, Im = 2 };
            ComplexNumber expected = new ComplexNumber() { Re = 11, Im = 22 };
            ComplexNumber result = augend.Add(addend);

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void AddTest2()
        {
            ComplexNumber augend = new ComplexNumber() { Re = 1, Im = -1 };
            ComplexNumber addend = new ComplexNumber() { Re = 0, Im = 0 };
            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = -1 };
            ComplexNumber result = augend.Add(addend);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 10, Im = 20 };
            string expected = "(10 + 20i)";
            string result = complexNumber.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest2()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 1, Im = 2 };
            string expected = "(1 + 2i)";
            string result = complexNumber.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest3()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 1, Im = -1 };
            string expected = "(1 + -1i)";
            string result = complexNumber.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest4()
        {
            ComplexNumber complexNumber = new ComplexNumber() { Re = 0, Im = 0 };
            string expected = "(0 + 0i)";
            string result = complexNumber.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}



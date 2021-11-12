using Microsoft.VisualStudio.TestTools.UnitTesting;
using INPTPZ1.Mathematics;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTest
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber a = new ComplexNumber() {RealPart = 10, ImaginaryPart = 20};
            ComplexNumber b = new ComplexNumber() {RealPart = 1,  ImaginaryPart = 2};
            ComplexNumber actualAnswer = a.Add(b);
            ComplexNumber expectedAnswer = new ComplexNumber() {RealPart = 11, ImaginaryPart = 22};

            Assert.AreEqual(expectedAnswer, actualAnswer);            
        }
        [TestMethod()]
        public void AddTest1()
        {
            ComplexNumber a = new ComplexNumber() { RealPart = 0, ImaginaryPart = 0 };
            ComplexNumber b = new ComplexNumber() { RealPart = 1, ImaginaryPart = -1 };
            ComplexNumber actualAnswer = a.Add(b);
            ComplexNumber expectedAnswer = new ComplexNumber() { RealPart = 1, ImaginaryPart = -1 };

            Assert.AreEqual(expectedAnswer, actualAnswer);
        }
        [TestMethod()]
        public void ToStringTest()
        {
            ComplexNumber a = new ComplexNumber() { RealPart = 10, ImaginaryPart = 20 };
            string expectedString = "(10 + 20i)";
            string actualString = a.ToString();
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod()]
        public void ToStringTest1()
        {
            ComplexNumber a = new ComplexNumber() { RealPart = 1, ImaginaryPart = 2 };
            string expectedString = "(1 + 2i)";
            string actualString = a.ToString();
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod()]
        public void ToStringTest2()
        {
            ComplexNumber a = new ComplexNumber() { RealPart = 1, ImaginaryPart = -1 };
            string expectedString = "(1 + -1i)";
            string actualString = a.ToString();
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod()]
        public void ToStringTest3()
        {
            ComplexNumber a = new ComplexNumber() { RealPart = 0, ImaginaryPart = 0 };
            string expectedString = "(0 + 0i)";
            string actualString = a.ToString();
            Assert.AreEqual(expectedString, actualString);
        }        
    }
}



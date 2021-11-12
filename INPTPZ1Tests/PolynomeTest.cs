using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using INPTPZ1.Mathematics;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolynomeTest
    {        
        [TestMethod()]
        public void EvaluatePolynomeTest()
        {
            Polynome polynome = new Mathematics.Polynome(new List<ComplexNumber>
            {
                new ComplexNumber { RealPart = 1},
                ComplexNumber.Zero,
                new ComplexNumber { RealPart = 1},
            });
            ComplexNumber actual = polynome.Evaluate(new ComplexNumber() { RealPart = 0, ImaginaryPart = 0 });
            ComplexNumber expected = new ComplexNumber() { RealPart = 1, ImaginaryPart = 0 };
            Assert.AreEqual(expected, actual);          
        }
        [TestMethod()]
        public void EvaluatePolynomeTest1()
        {
            Polynome polynome = new Mathematics.Polynome(new List<ComplexNumber>
            {
                new ComplexNumber { RealPart = 1},
                ComplexNumber.Zero,
                new ComplexNumber { RealPart = 1},
            });
            ComplexNumber actual = polynome.Evaluate(new ComplexNumber() { RealPart = 1, ImaginaryPart = 0 });
            ComplexNumber expected = new ComplexNumber() { RealPart = 2, ImaginaryPart = 0 };
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void EvaluatePolynomeTest2()
        {
            Polynome polynome = new Mathematics.Polynome(new List<ComplexNumber>
            {
                new ComplexNumber { RealPart = 1},
                ComplexNumber.Zero,
                new ComplexNumber { RealPart = 1},
            });
            ComplexNumber actual = polynome.Evaluate(new ComplexNumber() { RealPart = 2, ImaginaryPart = 0 });
            ComplexNumber expected = new ComplexNumber() { RealPart = 5, ImaginaryPart = 0 };
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void PolynomeTpStringTest()
        {
            Polynome polynome = new Mathematics.Polynome(new List<ComplexNumber>
            {
                new ComplexNumber { RealPart = 1},
                ComplexNumber.Zero,
                new ComplexNumber { RealPart = 1},
            });
            string actual = polynome.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, actual);
        }
    }
}
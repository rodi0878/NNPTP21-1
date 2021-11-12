using System;
using INPTPZ1.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests
{
    [TestClass]
    public class PolynomTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Polynom poly = new Polynom();
            poly.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            poly.Coeficients.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            poly.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber result = poly.Evaluate(new ComplexNumber() { Real = 0, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 1, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DeriveTest()
        {
            Polynom polynom = new Polynom();
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 3 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 2, Imaginary = 2 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 3, Imaginary = 1 });
            ComplexNumber result = polynom.Evaluate(new ComplexNumber() { Real = 0, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 1, Imaginary = 3 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EvaluateTest1()
        {
            Polynom polynom = new Polynom();
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber result = polynom.Evaluate(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 2, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EvaluateTest2()
        {
            Polynom polynom = new Polynom();
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber result = polynom.Evaluate(new ComplexNumber() { Real = 2, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 5.0000000000, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Polynom polynom = new Polynom();
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            polynom.Coeficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            string actual = polynom.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, actual);
        }
    }
}

using INPTPZ1.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests.Mathematics.Tests
{
    [TestClass()]
    public class PolynomeTests
    {
        [TestMethod()]
        public void PolynomeEvalComplexNumberRe0Im0Test()
        {
            Polynome poly = new Polynome();
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            poly.Coefficients.Add(ComplexNumber.Zero);
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = poly.Eval(ComplexNumber.Zero);
            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = 0 };

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeEvalComplexNumberRe1Im0Test()
        {
            Polynome poly = new Polynome();
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            poly.Coefficients.Add(ComplexNumber.Zero);
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = poly.Eval(new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 2, Im = 0 };

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeEvalComplexNumberRe2Im0Test()
        {
            Polynome poly = new Polynome();
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            poly.Coefficients.Add(ComplexNumber.Zero);
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = poly.Eval(new ComplexNumber() { Re = 2, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 5.0000000000, Im = 0 };

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeStringValueTest()
        {
            Polynome poly = new Polynome();
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            poly.Coefficients.Add(ComplexNumber.Zero);
            poly.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            string actualPolynomeString = poly.ToString();
            string expectedPolynomeString = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";

            Assert.AreEqual(expectedPolynomeString, actualPolynomeString);
        }
    }
}

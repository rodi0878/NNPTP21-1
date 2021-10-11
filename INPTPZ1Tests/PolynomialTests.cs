using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass]
    public class PolynomialTests
    {

        [TestMethod()]
        public void PolynomialEvaluateTestWithComplexNumber0Re0Im()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() { Re = 0, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomialEvaluateTestWithComplexNumber1Re0Im()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 2, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomialEvaluateTestWithComplexNumber2Re0Im()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() { Re = 2, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 5.0000000000, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomialToStringTest()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            string result = polynomial.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, result);
        }
    }
}

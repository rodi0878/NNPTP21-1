using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void AddPolynomeTest()
        {
            Polynomial polynomial = new Polynomial();
            ComplexNumber complexNumber = new ComplexNumber() { Re = 1, Im = 1 };
            polynomial.Coefficients.Add(complexNumber);
            Assert.AreEqual(complexNumber, polynomial.Coefficients[0]);
        }

        [TestMethod()]
        public void EvaluatePolynomeTest()
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
        public void ToStringPolynomeTest()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            string actual = polynomial.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, actual);
        }
    }
}
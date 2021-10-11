using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass]
    public class PolynomialTests
    {

        [TestMethod()]
        public void PolynomeEvaluateTestWithComplexNumber0Re0Im()
        {
            Polynomial polynome = new Polynomial();
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynome.Evaluate(new ComplexNumber() { Re = 0, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeEvaluateTestWithComplexNumber1Re0Im()
        {
            Polynomial polynome = new Polynomial();
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynome.Evaluate(new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 2, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeEvaluateTestWithComplexNumber2Re0Im()
        {
            Polynomial polynome = new Polynomial();
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            ComplexNumber result = polynome.Evaluate(new ComplexNumber() { Re = 2, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 5.0000000000, Im = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomeToStringTest()
        {
            Polynomial polynome = new Polynomial();
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 0, Im = 0 });
            polynome.Coefficients.Add(new ComplexNumber() { Re = 1, Im = 0 });

            string result = polynome.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, result);
        }
    }
}

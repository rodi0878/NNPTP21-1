using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace INPTPZ1.Mathematics.Tests
{
    /// <summary>
    /// Souhrnný popis pro PolynomialTests
    /// </summary>
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod()]
        public void EvaluateAtPointXTest1()
        {
            Polynomial polynomial = new Polynomial(new ComplexNumber() { Re = 1, Im = 0 }, new ComplexNumber() { Re = 0, Im = 0 }, new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 1, Im = 0 };
            ComplexNumber result = polynomial.EvaluateAtPointX(new ComplexNumber() { Re = 0, Im = 0 });

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EvaluateAtPointXTest2()
        {
            Polynomial polynomial = new Polynomial(new ComplexNumber() { Re = 1, Im = 0 }, new ComplexNumber() { Re = 0, Im = 0 }, new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber result = polynomial.EvaluateAtPointX(new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 2, Im = 0 };

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EvaluateAtPointXTest3()
        {
            Polynomial polynomial = new Polynomial(new ComplexNumber() { Re = 1, Im = 0 }, new ComplexNumber() { Re = 0, Im = 0 }, new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber result = polynomial.EvaluateAtPointX(new ComplexNumber() { Re = 2, Im = 0 });
            ComplexNumber expected = new ComplexNumber() { Re = 5.0000000000, Im = 0 };

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            Polynomial polynomial = new Polynomial(new ComplexNumber() { Re = 1, Im = 0 }, new ComplexNumber() { Re = 0, Im = 0 }, new ComplexNumber() { Re = 1, Im = 0 });
            string result = polynomial.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, result);
        }
    }
}

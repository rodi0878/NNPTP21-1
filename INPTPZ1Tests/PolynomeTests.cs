using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolynomeTests
    {
        public Polynome Polynome { get; set; }

        [TestInitialize]
        public void TestInitializePolynome()
        {
            Polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Real = 1, Imaginary = 0 },
                    ComplexNumber.ZERO,
                    new ComplexNumber() { Real = 1, Imaginary = 0 },

                }
            };
        }

        [TestMethod()]
        public void TestPolynomeEvaluationComplexNumberZero()
        {
            ComplexNumber result = Polynome.Evaluate(new ComplexNumber() { Real = 0, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 1, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestPolynomeEvaluationComplexNumberReal1Imaginary0()
        {
            ComplexNumber result = Polynome.Evaluate(new ComplexNumber() { Real = 1, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 2, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestPolynomeEvaluationComplexNumberReal2Imaginary0()
        {
            ComplexNumber result = Polynome.Evaluate(new ComplexNumber() { Real = 2, Imaginary = 0 });
            ComplexNumber expected = new ComplexNumber() { Real = 5, Imaginary = 0 };
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestPolynomeToString()
        {
            string result = Polynome.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, result);
        }
    }
}



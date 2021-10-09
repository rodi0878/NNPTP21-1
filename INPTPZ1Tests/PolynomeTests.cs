using INPTPZ1.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests
{
 
    [TestClass]
    public class PolynomeTests
    {
        [TestMethod()]
        public void PolynomeComplexNumberRe0Im0EvaluationTest()
        {
            Polynome polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Re = 1, Im = 0 },
                    ComplexNumber.Zero,
                    new ComplexNumber() { Re = 1, Im = 0 }
                }
            };

            ComplexNumber resultComplexNumber = polynome.Evaluation(new ComplexNumber() { Re = 0, Im = 0 });
            ComplexNumber expectedComplexNumber = new ComplexNumber() { Re = 1, Im = 0 };
            Assert.AreEqual(expectedComplexNumber, resultComplexNumber);
        }

        [TestMethod()]
        public void PolynomeComplexNumberRe1Im0EvaluationTest()
        {
            Polynome polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Re = 1, Im = 0 },
                    ComplexNumber.Zero,
                    new ComplexNumber() { Re = 1, Im = 0 }
                }
            };

            ComplexNumber resultComplexNumber = polynome.Evaluation(new ComplexNumber() { Re = 1, Im = 0 });
            ComplexNumber expectedComplexNumber = new ComplexNumber() { Re = 2, Im = 0 };
            Assert.AreEqual(expectedComplexNumber, resultComplexNumber);
        }

        [TestMethod()]
        public void PolynomeComplexNumberRe2Im0EvaluationTest()
        {
            Polynome polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Re = 1, Im = 0 },
                    ComplexNumber.Zero,
                    new ComplexNumber() { Re = 1, Im = 0 }
                }
            };

            ComplexNumber resultComplexNumber = polynome.Evaluation(new ComplexNumber() { Re = 2, Im = 0 });
            ComplexNumber expectedComplexNumber = new ComplexNumber() { Re = 5.0000000000, Im = 0 };
            Assert.AreEqual(expectedComplexNumber, resultComplexNumber);
        }

        public void PolynomeToStringTest()
        {
            Polynome polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Re = 1, Im = 0 },
                    ComplexNumber.Zero,
                    new ComplexNumber() { Re = 1, Im = 0 }
                }
            };

            string resultString = polynome.ToString();
            string expectedString = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expectedString, resultString);
        }
    }
}

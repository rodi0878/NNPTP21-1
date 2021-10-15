using Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests
{
    [TestClass]
    public class PolynomialTests
    {
        private Polynomial polynomial;

        [TestInitialize()]
        public void Initialize()
        {
            polynomial = new Polynomial();
            polynomial.ComplexNumbersList.Add(new ComplexNumber() { RealPart = 1, ImaginaryPart = 0 });
            polynomial.ComplexNumbersList.Add(new ComplexNumber() { RealPart = 0, ImaginaryPart = 0 });
            polynomial.ComplexNumbersList.Add(new ComplexNumber() { RealPart = 1, ImaginaryPart = 0 });
        }

        [TestMethod()]
        public void PolynomialTestEvalueteComplexNumberVersion1()
        {
            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() 
            { 
                RealPart = 0, 
                ImaginaryPart = 0 
            });

            ComplexNumber expected = new ComplexNumber() 
            { 
                RealPart = 1, 
                ImaginaryPart = 0 
            };

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void PolynomialTestEvalueteComplexNumberVersion2()
        {
            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() 
            { 
                RealPart = 1, 
                ImaginaryPart = 0 
            });

            ComplexNumber expected = new ComplexNumber() 
            { 
                RealPart = 2, 
                ImaginaryPart = 0 
            };

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomialTestEvalueteComplexNumberVersion3()
        {
            ComplexNumber result = polynomial.Evaluate(new ComplexNumber() 
            { 
                RealPart = 2, 
                ImaginaryPart = 0 
            });

            ComplexNumber expected = new ComplexNumber() 
            { 
                RealPart = 5.0000000000, 
                ImaginaryPart = 0 
            };

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PolynomialTestToString()
        {
            string result = polynomial.ToString();
            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(expected, result);
        }
    }
}

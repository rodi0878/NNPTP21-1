using Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1Tests
{
    [TestClass()]
    class PolynomeTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Polynome polynome = new Polynome();
            ComplexNumber complexNumber = new ComplexNumber { Real = 10, Imaginary = 10 };
            polynome.Add(complexNumber);
            Assert.IsTrue(polynome.Coeficients.Contains(complexNumber));
        }

        [TestMethod()]
        public void DeriveTest()
        {
            Polynome polynome = new Polynome();
            polynome.Add(new ComplexNumber { Real = 10, Imaginary = 10 });
            polynome.Add(new ComplexNumber { Real = 20, Imaginary = 20 });
            Polynome expectedPolynome = new Polynome();
            expectedPolynome.Add(new ComplexNumber { Real = 20, Imaginary = 20 });
            Polynome derivedPolynome = polynome.Derive();
            Assert.AreEqual(expectedPolynome.Coeficients.Count, derivedPolynome.Coeficients.Count);
            Assert.AreEqual(expectedPolynome.Coeficients[0], derivedPolynome.Coeficients[0]);
        }

        [TestMethod()]
        public void EvaluateRealNumber()
        {
            Polynome polynome = new Polynome();
            polynome.Add(new ComplexNumber { Real = 10, Imaginary = 10 });
            polynome.Add(new ComplexNumber { Real = 5, Imaginary = 5 });
            ComplexNumber result = polynome.Evaluate(5);
            ComplexNumber expectedResult = new ComplexNumber { Real = 35, Imaginary = 35 };
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void EvaluateComplexNumber()
        {
            Polynome polynome = new Polynome();
            polynome.Add(new ComplexNumber { Real = 10, Imaginary = 10 });
            polynome.Add(new ComplexNumber { Real = 5, Imaginary = 5 });
            ComplexNumber result = polynome.Evaluate(new ComplexNumber { Real = 20, Imaginary = 20 });
            ComplexNumber expectedResult = new ComplexNumber { Real = 10, Imaginary = 210 };
            Assert.AreEqual(expectedResult, result);

        }


    }
}

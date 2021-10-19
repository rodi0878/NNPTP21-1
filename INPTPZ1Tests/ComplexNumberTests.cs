using Microsoft.VisualStudio.TestTools.UnitTesting;
using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INPTPZ1;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTest
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber a = new ComplexNumber()
            {
                Re = 10,
                Imaginari = 20
            };
            ComplexNumber b = new ComplexNumber()
            {
                Re = 1,
                Imaginari = 2
            };

            ComplexNumber actual = a.Add(b);
            ComplexNumber shouldBe = new ComplexNumber()
            {
                Re = 11,
                Imaginari = 22
            };

            Assert.AreEqual(shouldBe, actual);

            var e2 = "(10 + 20i)";
            var r2 = a.ToString();
            Assert.AreEqual(e2, r2);
            e2 = "(1 + 2i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);

            a = new ComplexNumber()
            {
                Re = 1,
                Imaginari = -1
            };
            b = new ComplexNumber() { Re = 0, Imaginari = 0 };
            shouldBe = new ComplexNumber() { Re = 1, Imaginari = -1 };
            actual = a.Add(b);
            Assert.AreEqual(shouldBe, actual);

            e2 = "(1 + -1i)";
            r2 = a.ToString();
            Assert.AreEqual(e2, r2);

            e2 = "(0 + 0i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);
        }

        [TestMethod()]
        public void AddTestPolynome()
        {
            Polynome polynome = new Mathematics.Polynome();
            polynome.Coeficients.Add(new ComplexNumber() { Re = 1, Imaginari = 0 });
            polynome.Coeficients.Add(new ComplexNumber() { Re = 0, Imaginari = 0 });
            polynome.Coeficients.Add(new ComplexNumber() { Re = 1, Imaginari = 0 });
            ComplexNumber result = polynome.Eval(new ComplexNumber() { Re = 0, Imaginari = 0 });
            var expected = new ComplexNumber() { Re = 1, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = polynome.Eval(new ComplexNumber() { Re = 1, Imaginari = 0 });
            expected = new ComplexNumber() { Re = 2, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = polynome.Eval(new ComplexNumber() { Re = 2, Imaginari = 0 });
            expected = new ComplexNumber() { Re = 5.0000000000, Imaginari = 0 };
            Assert.AreEqual(expected, result);

            var r2 = polynome.ToString();
            var e2 = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(e2, r2);
        }
    }
}



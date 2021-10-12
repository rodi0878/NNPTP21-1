﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class CplxTests
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber a = new ComplexNumber(10, 20);

            ComplexNumber b = new ComplexNumber(1, 2);


            ComplexNumber actual = a.Add(b);
            ComplexNumber shouldBe = new ComplexNumber(11, 22);
   

            Assert.AreEqual(shouldBe, actual);

            var e2 = "(10 + 20i)";
            var r2 = a.ToString();
            Assert.AreEqual(e2, r2);
            e2 = "(1 + 2i)";
            r2 = b.ToString();
            Assert.AreEqual(e2, r2);

            a = new ComplexNumber(1, -1);

            b = new ComplexNumber(0, 0);
            shouldBe = new ComplexNumber(1,-1) ;
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
            Polynom poly = new Mathematics.Polynom();
            poly.Coeficients.Add(new ComplexNumber(1,0));
            poly.Coeficients.Add(new ComplexNumber(0,0));
            poly.Coeficients.Add(new ComplexNumber(1,0));
            ComplexNumber result = poly.Evaluate(new ComplexNumber(0,0));
            var expected = new ComplexNumber(1,0);
            Assert.AreEqual(expected, result);
            result = poly.Evaluate(new ComplexNumber(1,0));
            expected = new ComplexNumber(2,0);
            Assert.AreEqual(expected, result);
            result = poly.Evaluate(new ComplexNumber(2,0));
            expected = new ComplexNumber(5.0000000000,0) ;
            Assert.AreEqual(expected, result);

            var r2 = poly.ToString();
            var e2 = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(e2, r2);
        }
    }
}



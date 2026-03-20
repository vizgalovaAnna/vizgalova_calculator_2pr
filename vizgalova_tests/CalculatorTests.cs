using Microsoft.VisualStudio.TestTools.UnitTesting;
using vizgalova_library1;
using System;

namespace vizgalova_tests
{
    [TestClass]
    public sealed class CalculatorTests
    {
        [TestMethod]
        public void Add_5plus3_returns8()
        {
            double res = Calc.Add(5, 3);
            Assert.AreEqual(8, res);
        }

        [TestMethod]
        public void Sub_10minus4_returns6()
        {
            double res = Calc.Sub(10, 4);
            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void Mul_6x7_returns42()
        {
            double res = Calc.Mul(6, 7);
            Assert.AreEqual(42, res);
        }

        [TestMethod]
        public void Div_15div3_returns5()
        {
            double res = Calc.Div(15, 3);
            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void Div_by0_throwsException()
        {
            try
            {
                Calc.Div(10, 0);
                Assert.Fail("Должно быть исключение");
            }
            catch (DivideByZeroException ex)
            {
                Assert.AreEqual("Деление на ноль", ex.Message);
            }
        }

        [TestMethod]
        public void Pow_2v3_returns8()
        {
            double res = Calc.Pow(2, 3);
            Assert.AreEqual(8, res);
        }
        [TestMethod]
        public void Calculate_2plus2_returns4()
        {
            double res = Calc.Calculate("2+2");
            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void Calculate_2plus2x2_returns6()
        {
            double res = Calc.Calculate("2+2*2");
            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void Calculate_withBrackets_returns8()
        {
            double res = Calc.Calculate("(2+2)*2");
            Assert.AreEqual(8, res);
        }

        [TestMethod]
        public void Calculate_withPower_returns9()
        {
            double res = Calc.Calculate("2^3+1");
            Assert.AreEqual(9, res);
        }

        [TestMethod]
        public void Calculate_complex_returnsCorrect()
        {
            double res = Calc.Calculate("(2+3)*4-1");
            Assert.AreEqual(19, res);
        }
        [TestMethod]
        public void Execute_5plus3_returns8()
        {
            double res = Calc.Execute(5, '+', 3);
            Assert.AreEqual(8, res);
        }
    }
}
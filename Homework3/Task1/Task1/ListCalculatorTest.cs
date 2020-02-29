using NUnit.Framework;
using System;

namespace Task3.Tests
{
    class ListCalculatorTest
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(new StackAsList<float>());
        }

        [Test]
        public void CalculateWithCorrectExpression1Test()
        {
            string inputExpression = "7 8 +";
            Assert.AreEqual(calculator.Calculate(inputExpression), (true, 15));
        }

        [Test]
        public void CalculateWithCorrectExpression2Test()
        {
            string inputExpression = "100 100 *";
            Assert.AreEqual(calculator.Calculate(inputExpression), (true, 10000));
        }

        [Test]
        public void CalculateWithWrongExpressionWithExcessSymbols1Test()
        {
            try
            {
                string inputExpression = "1 11 -  9 * - 789 -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWithUncorrectExpressionWithUnknowCharactersTest()
        {
            try
            {
                string inputExpression = "1 2 + 3 ) = kkuyvb-- 4 / + 3 9 * -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "unknown character");
            }
        }

        [Test]
        public void CalculateWithUncorrectExpressionWithExcessValuesTest()
        {
            try
            {
                string inputExpression = "15 1548 - - 7888 45 356 759 +";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWithUncorrectExpressionWithExcessSigns2Test()
        {
            try
            {
                string inputExpression = "7 8 / 6 / * 5 - 4 + + / 4 / + -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWithEmptyExpressionTest()
        {
            try
            {
                string inputExpression = "";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

    }
}

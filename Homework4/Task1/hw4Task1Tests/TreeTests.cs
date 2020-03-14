using NUnit.Framework;
using System;

namespace hw4Task1
{
    [TestFixture]
    public class TreeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateSimpleExpressionTest()
        {
            string path = "TreeTest.txt";
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine("( * ( + 1 ( / 6   2) ) 7 )");
            }

            var tree = new Tree(path);
            Assert.AreEqual(28, tree.Calculate());
        }

        [Test]
        public void NoOperationsCalculationTest()
        {
            string path = "TreeTest.txt";
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine("100");
            }

            var tree = new Tree(path);
            Assert.AreEqual(100, tree.Calculate());
        }

        [Test]
        public void MustThrowExceptionOnWrongFileNameTest()
        {
            string path = "Nonexistant.txt";

            Assert.Throws<System.ArgumentException>(() => new Tree(path));
        }

        [Test]
        public void CalculateDivisionByZeroExpressionTest()
        {
            string path = "TreeTest.txt";
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine("( * ( - 1 ( / 20   0) ) 128 )");
            }

            var tree = new Tree(path);
            Assert.Throws<System.DivideByZeroException>(() => tree.Calculate());
        }
    }
}
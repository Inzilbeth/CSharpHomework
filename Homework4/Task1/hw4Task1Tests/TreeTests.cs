using NUnit.Framework;
using System;

namespace Task1
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
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            var tree = new Tree(reader);
            reader.Close();
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
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            var tree = new Tree(reader);
            reader.Close();
            Assert.AreEqual(100, tree.Calculate());
        }

        [Test]
        public void CalculateDivisionByZeroExpressionTest()
        {
            string path = "TreeTest.txt";
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine("( * ( - 1 ( / 20   0) ) 128 )");
            }

            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            var tree = new Tree(reader);
            reader.Close();
            System.IO.File.Delete(path);
            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }
    }
}
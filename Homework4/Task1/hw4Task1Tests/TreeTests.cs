using NUnit.Framework;
using System;
using System.IO;

namespace Task1
{
    [TestFixture]
    public class TreeTests
    {
        private string path;

        [SetUp]
        public void Setup()
        {
            path = "TreeTest.txt";
        }

        [Test]
        public void CalculateSimpleExpressionTest()
        {
            Tree tree;

            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("( * ( + 1 ( / 6   2) ) 7 )");
            }

            using (StreamReader reader = new StreamReader(path))
            {
                tree = new Tree(reader);
            }

            Assert.AreEqual(28, tree.Calculate());
        }

        [Test]
        public void NoOperationsCalculationTest()
        {
            Tree tree;

            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("100");
            }

            using (StreamReader reader = new StreamReader(path))
            {
                tree = new Tree(reader);
            }

            Assert.AreEqual(100, tree.Calculate());
        }

        [Test]
        public void CalculateDivisionByZeroExpressionTest()
        {
            Tree tree;

            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("( * ( - 1 ( / 20   0) ) 128 )");
            }

            using (StreamReader reader = new StreamReader(path))
            {
                tree = new Tree(reader);
            }

            File.Delete(path);

            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }
    }
}
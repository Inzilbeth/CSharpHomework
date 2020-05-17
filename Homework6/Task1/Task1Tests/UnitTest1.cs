using System.Collections.Generic;
using NUnit.Framework;
using Task1;

namespace Task1Tests
{
    public class Tests
    {
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int> { 1, 2, 3, 4, 5, 6 };
        }

        [Test]
        public void MapTest()
        {
            var resultantList = new List<int> { 3, 4, 5, 6, 7, 8 };
            Assert.AreEqual(resultantList, Functions.Map(list, x => x + 2));
        }

        [Test]
        public void FilterTest()
        {
            var resultantList = new List<int> { 2, 4, 6 };
            Assert.AreEqual(resultantList, Functions.Filter(list, x => x % 2 == 0));
        }

        [Test]
        public void FoldTest()
        {
            var result = 21;
            Assert.AreEqual(result, Functions.Fold(list, 0, (x, y) => x + y));
        }
    }
}
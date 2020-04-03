using System.Collections.Generic;
using NUnit.Framework;
using Task1;

namespace Task1Tests
{
    public class Tests
    {
        Functions funcs;
        List<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int> { 1, 2, 3, 4, 5, 6 };
            funcs = new Functions();
        }

        [Test]
        public void MapTest()
        {
            var reslist = new List<int> { 3, 4, 5, 6, 7, 8 };
            Assert.AreEqual(reslist, funcs.Map(list, x => x + 2));
        }

        [Test]
        public void FilterTest()
        {
            var reslist = new List<int> { 2, 4, 6 };
            Assert.AreEqual(reslist, funcs.Filter(list, x => x % 2 == 0));
        }

        [Test]
        public void FoldTest()
        {
            var res = 21;
            Assert.AreEqual(res, funcs.Fold(list, 0, (x, y) => x + y));
        }
    }
}

using NUnit.Framework;

namespace Task2.tests
{
    public class UniqueListTest
    {
        private UniqueList<int> uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new UniqueList<int>();
        }

        [Test]
        public void ListShouldBeEmptyBeforeInitializationTest()
        {
            Assert.AreEqual(0, uniqueList.Count);
            Assert.IsTrue(uniqueList.IsEmpty);
        }

        [Test]
        public void EmptyListShouldThrowExceptionAfterGetDataTest()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.GetData(1));
        }

        [Test]
        public void AddByNumberTest()
        {
            uniqueList.AddByNumber(1, 123);

            Assert.AreEqual(1, uniqueList.Count);
            Assert.IsFalse(uniqueList.IsEmpty);
        }

        [Test]
        public void GetValueTest()
        {
            var item0 = 100;
            var item1 = 500;

            uniqueList.AddByNumber(1, item0);
            uniqueList.AddByNumber(2, item1);

            Assert.AreEqual(item0, uniqueList.GetData(1));
            Assert.AreEqual(item1, uniqueList.GetData(2));
        }

        [Test]
        public void RemoveByNumberTest()
        {
            var item0 = 100;
            var item1 = 500;

            uniqueList.AddByNumber(1, item0);
            uniqueList.AddByNumber(2, item1);
            uniqueList.RemoveByNumber(1);

            Assert.AreEqual(1, uniqueList.Count);
            Assert.AreEqual(item1, uniqueList.GetData(1));
        }

        [Test]
        public void EmptyListShouldThrowExceptionAfterGetDataAfterActionsTest()
        {
            uniqueList.AddByNumber(1, 123);
            uniqueList.RemoveByNumber(1);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uniqueList.GetData(1));
        }

        [Test]
        public void ListShouldThrowExceptionIfPresentDataIsAddedTest()
        {
            uniqueList.AddByNumber(1, 100);
            uniqueList.AddByNumber(2, 500);

            Assert.Throws<ElementIsAlreadyPresentException>(() => uniqueList.AddByNumber(1, 100));
        }

        [Test]
        public void ContainsPresentDataTest()
        {
            uniqueList.AddByNumber(1, 0);
            uniqueList.AddByNumber(2, 123);

            Assert.IsTrue(uniqueList.Contains(123));
        }

        [Test]
        public void ContainsNonExistantDataTest()
        {
            uniqueList.AddByNumber(1, 100);
            uniqueList.AddByNumber(2, 200);

            Assert.IsFalse(uniqueList.Contains(500));
        }

        [Test]
        public void AddZeroTest()
        {
            uniqueList.AddByNumber(1, 0);

            Assert.IsFalse(uniqueList.IsEmpty);
        }
    }
}
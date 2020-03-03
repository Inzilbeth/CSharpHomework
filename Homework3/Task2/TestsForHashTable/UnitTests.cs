using NUnit.Framework;

namespace Task2
{
    public class Tests
    {
        private HashTable hashTable;

        [SetUp]
        public void Setup()
        {
            hashTable = new HashTable();
        }

        [Test]
        public void CheckPresenceOfAnEmptyString()
        {
            Assert.IsFalse(hashTable.HashContains(""));
        }

    }
}
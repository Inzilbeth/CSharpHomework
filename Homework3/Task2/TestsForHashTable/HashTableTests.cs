using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private HashTable hashTable;

        [SetUp]
        public void SetUp()
        {
            hashTable = new HashTable(new MD5());
        }

        static object[] AddValueCases =
        {
            new object[] {"T", true},
            new object[] {"\x12", true},
            new object[] { "こ", true},
            new object[] { "", true},
            new object[] {"T", false},
            new object[] {"\x12", false},
            new object[] { "こ", false},
            new object[] { "", false}
        };

        [TestCaseSource(nameof(AddValueCases))]
        public void AddDataTest(string data, bool addedValue)
        {
            if (addedValue)
            {
                hashTable.AddData(data);
            }
            else
            {
                hashTable.AddData("5");
            }
            Assert.AreEqual(addedValue, hashTable.HashContains(data));
        }

        [TestCase(10, 10, ExpectedResult = 0)]
        [TestCase(10, 9, ExpectedResult = 1)]
        [TestCase(10, 11, ExpectedResult = 0)]
        public int RemoveDataTest(int amountOfAddedElements, int amountOfRemovedElements)
        {
            for (int i = 0; i < amountOfAddedElements; i++)
            {
                hashTable.AddData("0");
            }

            for (int i = 0; i < amountOfRemovedElements; i++)
            {
                hashTable.DeleteData("0");
            }

            return hashTable.AmountOfElements;
        }

        static object[] ChangeHashFunctionCases =
        {
            new object[] {15, "aaaa", new MD5(), new MyHash()},
            new object[] {15, "aaaa", new MyHash(), new MD5()}
        };

        [TestCaseSource(nameof(ChangeHashFunctionCases))]
        public void ChangeHashFunctionTest(int numberOfElements, string data, IHash startingFunction, IHash finalFunction)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                hashTable.AddData("k");
            }

            hashTable.ChangeHashFunction(startingFunction);
            int startingHash = hashTable.GetHash(data);
            hashTable.ChangeHashFunction(finalFunction);
            int finalHash = hashTable.GetHash(data);

            Assert.AreNotEqual(startingHash, finalHash);
        }

    }
}

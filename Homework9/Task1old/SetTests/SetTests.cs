using System;
using NUnit.Framework;
using System.Linq;

namespace Task1
{
    public class SetTests
    {
        private Set<int> intSet;
        

        [SetUp]
        public void Setup()
        {
            intSet = new Set<int>(new CustomComparer()) { 1, 2, -10, 5, -14, -12, 3 };
        }

        [Test]
        public void SimpleAdditionTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(1);
            Assert.IsTrue(intSet.Contains(1));
        }

        [Test]
        public void AdditionOfTwoSameItemsTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(0);
            Assert.IsFalse(intSet.Add(0));
        }

        [Test]
        public void AdditionInOrderTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(0);
            intSet.Add(1);
            intSet.Add(2);
            Assert.IsTrue(intSet.Contains(0));
            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(2));
        }

        [Test]
        public void AdditionPreOrderTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(2);
            intSet.Add(1);
            intSet.Add(0);
            Assert.IsTrue(intSet.Contains(2));
            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(0));
        }

        [Test]
        public void AdditionOfManyItemsTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(1);
            intSet.Add(2);
            intSet.Add(-10);
            intSet.Add(-14);
            intSet.Add(5);
            intSet.Add(-12);
            intSet.Add(3);
            intSet.Add(4);
            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(2));
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(-14));
            Assert.IsTrue(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(-12));
            Assert.IsTrue(intSet.Contains(3));
            Assert.IsTrue(intSet.Contains(4));
        }

        [Test]
        public void ClearTest()
        {
            intSet.Clear();
            Assert.IsEmpty(intSet);
        }

        [Test]
        public void ContainsTest()
        {
            Assert.IsTrue(intSet.Contains(-14));
            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(3));
            Assert.IsFalse(intSet.Contains(0));
            Assert.IsFalse(intSet.Contains(-15));
            Assert.IsFalse(intSet.Contains(4));
        }

        [Test]
        public void CopyToTest()
        {
            var array = new int[7];
            intSet.CopyTo(array, 0);
            Assert.IsTrue(array.SequenceEqual(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
        }

        [Test]
        public void ExceptWithTest()
        {
            intSet.ExceptWith(new int[7] { -14, 10, -10, 1, 6, 5, 19 });
            Assert.IsTrue(intSet.SetEquals(new int[3] { -12, 2, 3 }));
        }

        [Test]
        public void ExceptWithItselfTest()
        {
            intSet.ExceptWith(intSet);
            Assert.IsTrue(intSet.SetEquals(new int[0] { }));
        }

        [Test]
        public void IntersectWithTest()
        {
            intSet.IntersectWith(new int[7] { -14, 10, -10, 1, 6, 5, 19 });
            Assert.IsTrue(intSet.SetEquals(new int[4] { -14, -10, 1, 5 }));
        }

        [Test]
        public void IntersectWithItselfTest()
        {
            intSet.IntersectWith(intSet);
            Assert.IsTrue(intSet.SetEquals(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsSubsetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsTrue(intSet.IsSubsetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(intSet.IsSubsetOf(new int[6] { -14, -12, -10, 1, 3, 5 }));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsProperSubsetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[6] { -14, -12, -10, 1, 3, 5 }));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsSupersetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[10] { -14, -14, -10, 1, 3, 5, -10, 3, 3, 5 }));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[12] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2, 3, 3 }));
            Assert.IsTrue(intSet.IsProperSupersetOf(new int[10] { -14, -14, -10, 1, 3, 5, -10, 3, 3, 5 }));
        }

        [Test]
        public void OverlapsTest()
        {
            Assert.IsTrue(intSet.Overlaps(new int[10] { -14, -4, -14, 6, 2, 2, 1, 15, 30, 45 }));
            Assert.IsTrue(intSet.Overlaps(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(intSet.Overlaps(new int[10] { -13, -4, -100, 6, 16, 11, 7, 15, 30, 45 }));
        }

        [Test]
        public void RemoveFirstItemTest()
        {
            intSet.Remove(1);

            Assert.IsFalse(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(2));
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(-14));
            Assert.IsTrue(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(-12));
            Assert.IsTrue(intSet.Contains(3));
        }

        [Test]
        public void RemoveSecondItemTest()
        {
            intSet.Add(-9);
            intSet.Remove(-10);
            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(2));
            Assert.IsFalse(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(-14));
            Assert.IsTrue(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(-12));
            Assert.IsTrue(intSet.Contains(3));
            Assert.IsTrue(intSet.Contains(-9));
        }

        [Test]
        public void RemoveOfOneItemTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(1);
            intSet.Remove(1);
            Assert.IsFalse(intSet.Contains(1));
        }

        [Test]
        public void RemoveFromEmptySetTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Remove(1);
        }

        [Test]
        public void RemoveOfThirdItemTest()
        {
            intSet.Remove(2);

            Assert.IsTrue(intSet.Contains(1));
            Assert.IsFalse(intSet.Contains(2));
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(-14));
            Assert.IsTrue(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(-12));
            Assert.IsTrue(intSet.Contains(3));
        }

        [Test]
        public void RemoveOfLastItemsTest()
        {
            intSet.Remove(-14);
            intSet.Remove(5);

            Assert.IsTrue(intSet.Contains(1));
            Assert.IsTrue(intSet.Contains(2));
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsFalse(intSet.Contains(-14));
            Assert.IsFalse(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(-12));
            Assert.IsTrue(intSet.Contains(3));
        }

        [Test]
        public void SetEqualsTest()
        {
            Assert.IsTrue(intSet.SetEquals(new int[10] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2 }));
            Assert.IsFalse(intSet.SetEquals(new int[11] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2, 7 }));
            Assert.IsFalse(intSet.SetEquals(new int[10] { -14, -14, -10, 1, 2, 3, 5, -14, 1, 2 }));
        }

        [Test]
        public void SymmetricExceptWithItselfTest()
        {
            intSet.SymmetricExceptWith(new int[10] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2 });
            Assert.IsTrue(intSet.SetEquals(new int[0] { }));
        }

        [Test]
        public void SimpleSymmetricExceptionTest()
        {
            intSet.SymmetricExceptWith(new int[5] { -14, -10, 4, 4, 11 });
            Assert.IsTrue(intSet.SetEquals(new int[7] { 1, 2, 4, 5, 11, -12, 3 }));
        }

        [Test]
        public void UnionWithTest()
        {
            intSet.UnionWith(new int[6] { -14, -14, 5, 4, 11, -10 });
            Assert.IsTrue(intSet.SetEquals(new int[9] { 1, 2, -10, 5, -14, -12, 3, 4, 11 }));
        }

    }
}
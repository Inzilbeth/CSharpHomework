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
            intSet = new Set<int>(new CustomComparer()) { -10, 5, 19, 0 };
        }

        [Test]
        public void AdditionTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(555);
            Assert.IsTrue(intSet.Contains(555));
            Assert.IsTrue(intSet.Count == 1);
        }

        [Test]
        public void AdditionOfSameItemsTest()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(777);
            Assert.IsFalse(intSet.Add(777));
            Assert.IsTrue(intSet.Count == 1);
        }

        [Test]
        public void MultipleAdditionsTest1()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(20);
            intSet.Add(-1);
            Assert.IsTrue(intSet.Contains(20));
            Assert.IsTrue(intSet.Contains(-1));
            Assert.IsTrue(intSet.Count == 2);
        }

        [Test]
        public void MultipleAdditionsTest2()
        {
            intSet = new Set<int>(new CustomComparer());
            intSet.Add(150);
            intSet.Add(218);
            intSet.Add(-666);
            Assert.IsTrue(intSet.Contains(150));
            Assert.IsTrue(intSet.Contains(-666));
            Assert.IsTrue(intSet.Contains(218));
            Assert.IsTrue(intSet.Count == 3);
        }

        [Test]
        public void ClearTest()
        {
            intSet.Clear();
            Assert.IsEmpty(intSet);
        }

        [Test]
        public void ShouldContainTest()
        {
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(5));
            Assert.IsTrue(intSet.Contains(19));
            Assert.IsTrue(intSet.Contains(0));
        }

        [Test]
        public void ShouldNotContainTest()
        {
            Assert.IsFalse(intSet.Contains(10));
            Assert.IsFalse(intSet.Contains(-5));
            Assert.IsFalse(intSet.Contains(100));
        }

        [Test]
        public void CopyToTest()
        {
            var array = new int[4];
            intSet.CopyTo(array, 0);
            Assert.AreEqual(new int[4] { -10, 0, 5, 19 }, array);
        }

        [Test]
        public void ExceptWithTest()
        {
            intSet.ExceptWith(new int[4] { -10, 19, 20, 185});
            Assert.IsTrue(intSet.SetEquals(new int[2] { 0, 5 }));
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
            intSet.IntersectWith(new int[4] { 2, -10, 19, 100 });
            Assert.IsTrue(intSet.SetEquals(new int[2] { 19, -10 }));
        }

        [Test]
        public void IntersectWithItselfTest()
        {
            intSet.IntersectWith(intSet);
            Assert.IsTrue(intSet.SetEquals(new int[4] { -10, 19, 0, 5 }));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsSubsetOf(new int[10] { -10, 19, 0, 5, 5, 5, 19, 0, 48, 9999 }));
            Assert.IsTrue(intSet.IsSubsetOf(new int[4] { -10, 19, 0, 5 }));
            Assert.IsFalse(intSet.IsSubsetOf(new int[6] { 0, -19, -10, 1, -19, 5 }));
            Assert.IsFalse(intSet.IsSubsetOf(new int[4] { 0, -19, -10, 1 }));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsProperSubsetOf(new int[10] { -10, 19, 0, 5, 5, 5, 19, 0, 48, 9999 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[4] { 0, -19, -10, 5 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[6] { 0, -19, -10, 1, -19, 5 }));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsSupersetOf(new int[10] { -10, 19, 0, 5, 5, 5, 19, 0, 48, 9999 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[4] { 0, 19, -10, 5 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[8] { 0, 19, -10, 5, 0, 19, -10, 5 }));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[10] { -10, 19, 0, 5, 5, 5, 19, 0, 48, 9999 }));
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[4] { 0, -19, -10, 5 }));
            Assert.IsTrue(intSet.IsProperSupersetOf(new int[8] { 0, 19, -10, -10, 0, 19, -10, 19 }));
        }

        [Test]
        public void OverlapsTest()
        {
            Assert.IsTrue(intSet.Overlaps(new int[10] { -10, 19, 0, 5, 5, 5, 19, 0, 48, 9999 }));
            Assert.IsTrue(intSet.Overlaps(new int[7] { -1000, 2, 777, 1, 2, 3, 5 }));
            Assert.IsFalse(intSet.Overlaps(new int[10] { 95, 36, 7896, -568, 1, 23, 47, 83, 67, 796 }));
        }

        [Test]
        public void RemoveTest()
        {
            intSet.Remove(-10);

            Assert.IsFalse(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(0));
            Assert.IsTrue(intSet.Contains(19));
            Assert.IsTrue(intSet.Contains(5));
        }

        [Test]
        public void RemoveFromMiddleTest()
        {
            intSet.Remove(5);
            Assert.IsTrue(intSet.Contains(-10));
            Assert.IsTrue(intSet.Contains(0));
            Assert.IsFalse(intSet.Contains(-5));
            Assert.IsTrue(intSet.Contains(19));
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
        public void MultipleRemovalTest()
        {
            intSet.Remove(-10);
            intSet.Remove(5);

            Assert.IsTrue(intSet.Contains(19));
            Assert.IsTrue(intSet.Contains(0));
            Assert.IsFalse(intSet.Contains(-10));
            Assert.IsFalse(intSet.Contains(5));
        }

        [Test]
        public void SetEqualsTest()
        {
            Assert.IsTrue(intSet.SetEquals(new int[4] { -10, 5, 19, 0 }));
            Assert.IsFalse(intSet.SetEquals(new int[4] { -10, 5, 19, 7 }));
            Assert.IsFalse(intSet.SetEquals(new int[5] { -10, 5, 19, 0, 15 }));
        }

        [Test]
        public void SymmetricExceptWithItselfTest()
        {
            intSet.SymmetricExceptWith(new int[4] { -10, 5, 19, 0 });
            Assert.IsTrue(intSet.SetEquals(new int[0] { }));
        }

        [Test]
        public void SymmetricExceptionTest()
        {
            intSet.SymmetricExceptWith(new int[5] { -10, 0, 18, -1000, 11 });
            Assert.IsTrue(intSet.SetEquals(new int[5] { 19, 5, 18, -1000, 11 }));
        }

        [Test]
        public void UnionWithTest()
        {
            intSet.UnionWith(new int[6] { -10, 0, 56, 128, -88, 200 });
            Assert.IsTrue(intSet.SetEquals(new int[8] { -10, 0, 56, 128, -88, 200, 19, 5 }));
        }
    }
}
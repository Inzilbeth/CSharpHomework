using NUnit.Framework;
using System;

namespace Task1
{
    public class Tests
    {
        PriorityQueue<string> pQueue;
        
        [SetUp]
        public void Setup()
        {
            pQueue = new PriorityQueue<string>();
        }

        [Test]
        public void CorrectDequeueTest()
        {
            pQueue.Enqueue("p1", 1);
            Assert.IsFalse(pQueue.IsEmpty());
        }

        [Test]
        public void IsEmptyAfterAddTest()
        {
            pQueue.Enqueue("p1", 1);
            Assert.AreEqual(pQueue.Dequeue(), "p1");
        }

        [Test]
        public void DequeueAfterAddShouldMakeEmptyTest()
        {
            pQueue.Enqueue("p4", 4);
            pQueue.Dequeue();
            Assert.IsTrue(pQueue.IsEmpty());
        }

        [Test]
        public void ReturnsHighestPriorityTest()
        {
            pQueue.Enqueue("acb", 4);
            pQueue.Enqueue("abc", 10);
            pQueue.Enqueue("cca", 2);
            Assert.AreEqual(pQueue.Dequeue(),"abc");
        }

        [Test]
        public void EqualPriorityShouldReturnEarliestTest()
        {
            pQueue.Enqueue("boo", 15);
            pQueue.Enqueue("foo", 15);
            Assert.AreEqual(pQueue.Dequeue(), "boo");
        }

        [Test]
        public void DequeOnEmptyShouldThrowAnErrorTest()
        {
            try
            {
                pQueue.Dequeue();
            }
            catch(ArgumentException) 
            {
                Assert.Pass();
            }
        }
        [Test]
        public void DequeOnEmptyAfterAddingShouldThrowAnErrorTest()
        {
            pQueue.Enqueue("aaaa", 1);
            pQueue.Dequeue();
            try
            {
                pQueue.Dequeue();
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }
    }
}
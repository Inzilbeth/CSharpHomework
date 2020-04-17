using NUnit.Framework;

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
    }
}
using NUnit.Framework;
using System;

namespace Task3.Tests
{
    public class StackAsListTests
    {
        private StackAsList<float> stack;

        [SetUp]
        public void Setup()
        {
            stack = new StackAsList<float>();
        }

        [Test]
        public void TestEmptyStackOnEmptiness()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void TestFilledStackOnEmptiness()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void TestEmptyStackOnEmptinessAfterPushAndPop()
        {
            stack.Push(789);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void TestPopWithoutPush()
        {
            try
            {
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Stack is empty");
            }
        }

        [Test]
        public void IsEmptyTestPopTwiceAfterOnePop()
        {
            try
            {
                stack.Push(2);
                stack.Pop();
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Stack is empty");
            }
        }

        [Test]
        public void ClearingAnEmptyStackTest()
        {
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void ClearFilledStack()
        {
            stack.Push(8);
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void PeekFromEmptyStack()
        {
            try 
            {
                stack.Peek();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Stack is empty");
            }
        }

        [Test]
        public void PeekFromFilledStack()
        {
            stack.Push(8);
            stack.Push(5);
            stack.Pop();
            Assert.AreEqual(stack.Peek(), 8);
        }
    }
}
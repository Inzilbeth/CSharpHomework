using NUnit.Framework;
using System;

namespace Task3.Tests
{
    public class StackTest
    {

        public void TestEmptyStackOnEmptiness(IStack<float> stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        public void TestFilledStackOnEmptiness(IStack<float> stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        public void TestEmptyStackOnEmptinessAfterPushAndPop(IStack<float> stack)
        {
            stack.Push(789);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
        }

        public void TestPopWithoutPush(IStack<float> stack)
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

        public void IsEmptyTestPopTwiceAfterOnePop(IStack<float> stack)
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

        public void ClearingAnEmptyStackTest(IStack<float> stack)
        {
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        public void ClearFilledStack(IStack<float> stack)
        {
            stack.Push(8);
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
        }

        public void PeekFromEmptyStack(IStack<float> stack)
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

        public void PeekFromFilledStack(IStack<float> stack)
        {
            stack.Push(8);
            stack.Push(5);
            stack.Pop();
            Assert.AreEqual(stack.Peek(), 8);
        }
    }
}
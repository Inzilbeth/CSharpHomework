using NUnit.Framework;
using System;

namespace Task3.Tests
{
    class StackArrayTest : StackTest
    {
        private IStack<float> stack = new StackAsArray<float>();

        [SetUp]
        public void Setup()
        {
            stack = new StackAsArray<float>();
        }

        [Test]
        public void TestEmptyStackOnEmptiness() => base.TestEmptyStackOnEmptiness(stack);
        
        [Test]
        public void TestFilledStackOnEmptiness() => base.TestFilledStackOnEmptiness(stack);
        
        [Test]
        public void TestEmptyStackOnEmptinessAfterPushAndPop() => TestEmptyStackOnEmptinessAfterPushAndPop(stack);

        [Test]
        public void TestPopWithoutPush() => TestPopWithoutPush(stack);

        [Test]
        public void IsEmptyTestPopTwiceAfterOnePop() => IsEmptyTestPopTwiceAfterOnePop(stack);

        [Test]
        public void ClearingAnEmptyStackTest() => ClearingAnEmptyStackTest(stack);

        [Test]
        public void ClearFilledStack() => ClearFilledStack(stack);

        [Test]
        public void PeekFromEmptyStack() => PeekFromEmptyStack(stack);

        [Test]
        public void PeekFromFilledStack() => PeekFromFilledStack(stack);
    }
}

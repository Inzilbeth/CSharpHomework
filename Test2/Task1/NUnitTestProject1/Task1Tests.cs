using NUnit.Framework;
using NUnit.Framework.Api;
using System;

namespace Forms
{
    public class Tests
    {
        Controller controller;

        [SetUp]
        public void Setup()
        {
            controller = new Controller(4);
        }

        [Test]
        public void initializationTest()
        {
            int[] testArray = new int[8];

            foreach (var item in controller.valueArray)
            {
                testArray[item]++;
            }

            foreach (var item in testArray)
            {
                if (item != 2)
                { 
                    Assert.Fail(); 
                }
            }

            Assert.Pass();
        }
    }
}
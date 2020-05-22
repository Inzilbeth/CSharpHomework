using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forms
{
    [TestClass]
    public class Tests
    {
        Controller controller;

        [TestMethod]
        public void initializationTest()
        {
            controller = new Controller(4);
            
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
        }
    }
}

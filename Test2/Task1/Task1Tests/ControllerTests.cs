using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Forms
{
    [TestClass]
    public class Tests
    {
        Controller controller;

        [TestMethod]
        public void InitializationTest()
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

        [TestMethod]
        public void ClickTwiceOnTheSameButtonTest()
        {
            controller = new Controller(4);
            controller.Click(1, 1);
            controller.Click(1, 1);

            Assert.IsTrue(controller.buttonArray[1, 1].Enabled);
        }

        [TestMethod]
        public void WinCheckWithoutMoves()
        {
            controller = new Controller(4);
            Assert.IsFalse(controller.WinCheck());
        }

        [TestMethod]
        public void WinCheckWithMoves()
        {
            controller = new Controller(2);

            controller.Click(0, 1);
            controller.Click(1, 1);

            Assert.IsFalse(controller.WinCheck());
        }

        [TestMethod]
        public void WinCheckWithAllButtonsCovered()
        {
            controller = new Controller(4);

            controller.Click(0, 0);
            controller.Click(0, 1);
            controller.Click(0, 2);
            controller.Click(0, 3);
            controller.Click(1, 0);
            controller.Click(1, 1);
            controller.Click(1, 2);
            controller.Click(1, 3);
            controller.Click(2, 0);
            controller.Click(2, 1);
            controller.Click(2, 2);
            controller.Click(2, 3);
            controller.Click(3, 0);
            controller.Click(3, 1);
            controller.Click(3, 2);
            controller.Click(3, 3);

            Assert.IsFalse(controller.WinCheck());
        }

        [TestMethod]
        public void ProperWinCheck()
        {
            controller = new Controller(4);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    controller.buttonArray[i, j].Enabled = false;
                }
            }

            Assert.IsTrue(controller.WinCheck());
        }
    }
}

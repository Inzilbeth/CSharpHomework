using NUnit.Framework;
using System.IO;
using Task2;

namespace Task2Tests
{
    public class TilemapTests
    {
        private Tilemap tmap;

        [SetUp]
        public void Setup()
        {
            File.WriteAllText("setupMap.txt", @"#####################
#    #              #
#    #     #        #
#          #        #
#          #        #
#    ###########    #
#      #            #
#  @   #            #
#      #       #    #
#              #    #
#####################");
            tmap = new Tilemap("setupMap.txt");
        }

        [Test]
        public void ConstructorTest()
        {
            var rightMap = new char[3, 4];
            File.WriteAllText("map.txt", @"####
#@ #
####");
            tmap = new Tilemap(@"map.txt");

            for (int i = 0; i < rightMap.GetLength(0); i++)
            {
                for (int j = 0; j < rightMap.GetLength(1); j++)
                {
                    rightMap[i, j] = '#';
                }
            }

            rightMap[1, 1] = '@';
            rightMap[1, 2] = ' ';

            Assert.AreEqual(rightMap, tmap.Map);
        }

        [Test]
        public void IsOnMapTest()
        {
            Assert.IsTrue(tmap.IsOnMap(2, 1));
            Assert.IsTrue(tmap.IsOnMap(5, 5));
            Assert.IsFalse(tmap.IsOnMap(30, 1));
        }

        [Test]
        public void MoveRightTest()
        {
            (int, int) correctCoords = (7, 4);
            (int, int)? coords = null;
            tmap.MoveRight();
            for (int i = 0; i < tmap.Height; i++)
            {
                for (int j = 0; j < tmap.Width; j++)
                {
                    if(tmap.Map[i,j] == '@')
                    {
                        coords = (i, j);
                    }
                }
            }
            Assert.AreEqual(correctCoords, coords);
        }

        [Test]
        public void MoveLeftTest()
        {
            (int, int) correctCoords = (7, 2);
            (int, int)? coords = null;
            tmap.MoveLeft();
            for (int i = 0; i < tmap.Height; i++)
            {
                for (int j = 0; j < tmap.Width; j++)
                {
                    if (tmap.Map[i, j] == '@')
                    {
                        coords = (i, j);
                    }
                }
            }
            Assert.AreEqual(correctCoords, coords);
        }

        [Test]
        public void MoveUpTest()
        {
            (int, int) correctCoords = (6, 3);
            (int, int)? coords = null;
            tmap.MoveUp();
            for (int i = 0; i < tmap.Height; i++)
            {
                for (int j = 0; j < tmap.Width; j++)
                {
                    if (tmap.Map[i, j] == '@')
                    {
                        coords = (i, j);
                    }
                }
            }
            Assert.AreEqual(correctCoords, coords);
        }

        [Test]
        public void MoveDownTest()
        {
            (int, int) correctCoords = (8, 3);
            (int, int)? coords = null;
            tmap.MoveDown();
            for (int i = 0; i < tmap.Height; i++)
            {
                for (int j = 0; j < tmap.Width; j++)
                {
                    if (tmap.Map[i, j] == '@')
                    {
                        coords = (i, j);
                    }
                }
            }
            Assert.AreEqual(correctCoords, coords);
        }
    }
}
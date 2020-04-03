using NUnit.Framework;
using System.IO;
using Task2;

namespace Task2Tests
{
    public class TilemapTests
    {
        Tilemap tmap;

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
            var rightmap = new char[3, 4];
            File.WriteAllText("map.txt", @"####
#@ #
####");
            tmap = new Tilemap(@"map.txt");

            for (int i = 0; i < rightmap.GetLength(0); i++)
            {
                for (int j = 0; j < rightmap.GetLength(1); j++)
                {
                    rightmap[i, j] = '#';
                }
            }

            rightmap[1, 1] = '@';
            rightmap[1, 2] = ' ';

            Assert.AreEqual(rightmap, tmap.Map);
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
            Assert.AreEqual(coords, correctCoords);
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
            Assert.AreEqual(coords, correctCoords);
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
            Assert.AreEqual(coords, correctCoords);
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
            Assert.AreEqual(coords, correctCoords);
        }
    }
}
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
        }

        [Test]
        public void ConstructorTest()
        {
            var rightmap = new char[3, 4];
            File.WriteAllText("map.txt", @"####
#  #
####");
            tmap = new Tilemap(@"map.txt");
            
            for(int i = 0; i < rightmap.GetLength(0); i++)
            {
                for(int j = 0; j < rightmap.GetLength(1); j++)
                {
                    rightmap[i, j] = '#';
                }
            }

            rightmap[1, 1] = ' ';
            rightmap[1, 2] = ' ';

            Assert.AreEqual(rightmap, tmap.Map);
        }
    }
}
using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class HashTests
    {
        static object[] MyHashTests =
        {
            new object[] { new MyHash(), "теСтОвАяСтРоКа", 12, 8 },

            new object[] { new MyHash(), "\x00\x01\x02", 4, 2 },
            
            new object[] { new MyHash(), "مرحبااناكارل", 20, 5 },

            new object[] { new MyHash(), "77777799999999998798741aaaa", 99, 21 },

            new object[] { new MyHash(), "", 111, 0 }
        };

        static object[] MD5Tests =
        {
            new object[] { new MD5(), "теСтОвАяСтРоКа", 12, 3 },
            
            new object[] { new MD5(), "\x00\x01\x02", 4, 3 },
            
            new object[] { new MD5(), "مرحبااناكارل", 20, 19 },

            new object[] { new MD5(), "77777799999999998798741aaaa", 99, 21 },

            new object[] { new MD5(), "", 111, 13 }
        };

        [TestCaseSource(nameof(MyHashTests))]
        [TestCaseSource(nameof(MD5Tests))]
        public void HashTest(IHash hash, string data, int size, int expectedHash)
        {
            Assert.AreEqual(expectedHash, hash.Hash(data, size));
        }
    }
}
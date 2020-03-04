using System;
using System.Security.Cryptography;
using System.Text;

namespace Task2
{
    public class MD5 : IHash
    {
        /// <summary>
        /// Calculates MD5 hash of the input string.
        /// </summary>
        /// <param name="data">String to be MD5-hashed.</param>
        /// <param name="size">Hash table size or the biggest possible value of MD5 hash.</param>
        /// <returns>MD5 hash of input string.</returns>
        public int Hash(string data, int size)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return (Convert.ToInt32(hash.ToString().Substring(0, 7), 16) % size);
        }
    }
}

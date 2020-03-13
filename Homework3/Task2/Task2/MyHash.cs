using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class MyHash : IHash
    {
        /// <summary>
        /// Calculates hash of the input string.
        /// </summary>
        /// <param name="data">String to be hashed.</param>
        /// <param name="size">Hash table size or the biggest possible value of hash.</param>
        /// <returns>Hash of input string.</returns>
        public int Hash(string data, int size)
        {
            int result = 0;
            foreach (var symbol in data)
            {
                result = (result * 109 + symbol) % size;
            }
            return result;
        }
    }
}
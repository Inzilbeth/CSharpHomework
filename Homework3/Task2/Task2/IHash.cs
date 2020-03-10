using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Interface for hash functions.
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Hash function.
        /// </summary>
        /// <param name="data">String to be hashed.</param>
        /// <param name="size">Current size of hash table.</param>
        public int Hash(string data, int size);
    }
}

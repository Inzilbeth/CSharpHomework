using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    /// <summary>
    /// Implementation of the hash table.
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// FillFactor exceeding this value leads to a resize.
        /// </summary>
        private const float MaxFillFactor = 1.2F;

        /// <summary>
        /// Size of the hash table.
        /// </summary>
        private int size;

        /// <summary>
        /// Load factor (if > 1, forces a resize of the hash table).
        /// </summary>
        private float loadFactor;

        /// <summary>
        /// Current amounts of elements within the hash table.
        /// </summary>
        private int amountOfElements;

        /// <summary>
        /// Returns current amount of elements in the hash table.
        /// </summary>
        public int AmountOfElements => amountOfElements;

        /// <summary>
        /// Elements of the hash table.
        /// </summary>
        private LinkedList<string>[] buckets;

        /// <summary>
        /// Currently used type of hash function.
        /// </summary>
        private IHash hash;

        /// <summary>
        /// Hash table constructor.
        /// </summary>
        public HashTable(IHash hash)
        {
            size = 10;
            InitializeBuckets();
            this.hash = hash;
        }

        /// <summary>
        /// Initializes buckets within the array.
        /// </summary>
        private void InitializeBuckets()
        {
            buckets = new LinkedList<string>[size];
            for (int i = 0; i < size; ++i)
            {
                buckets[i] = new LinkedList<string>();
            }
        }

        /// <summary>
        /// Doubles the size of a hash table.
        /// </summary>
        private void ReSize(int size)
        {
            if (size <= 0)
            {
                throw new InvalidOperationException("Size < 0");
            }
            var tempTable = new LinkedList<string>[size];
            for (int i = 0; i < tempTable.Length; i++)
            {
                tempTable[i] = new LinkedList<string>();
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i].IsEmpty)
                {
                    continue;
                }
                var temporaryNodes = buckets[i].ReturnAllNodes();
                foreach (var item in temporaryNodes)
                {
                    tempTable[CalculateHash(item, tempTable.Length)].AddByNumber(1, item);
                }
            }

            buckets = tempTable;
            FillFactorCheck();
        }

        /// <summary>
        /// Adds the hash of a string to the hash table.
        /// </summary>
        /// <param name="data">String which hash will be added to the hash table.</param>
        private void Add(string data)
        {
            int hashValue = CalculateHash(data, size);
            buckets[hashValue].AddByNumber(1, data);
        }

        private int CalculateHash(string data, int size)
        {
            return Math.Abs(hash.Hash(data, size) % size);
        }

        /// <summary>
        /// Adds the hash of a string to the hash table and resizes the hash table if needed.
        /// </summary>
        /// <param name="data">String which hash will be added to the hash table.</param>
        public void AddData(string data)
        {
            Add(data);
            amountOfElements++;
            loadFactor = (float)amountOfElements / size;

            if (loadFactor > MaxFillFactor)
            {
                size *= 2;
                ReSize(size);
            }
        }

        /// <summary>
        /// Deletes the selected string from the hash table.
        /// </summary>
        /// <param name="data">String which will be removed.</param>
        /// <returns>Indicates whether removal was successful or not.</returns>
        public bool DeleteData(string data)
        {
            var hashValue = CalculateHash(data, size);
            var valueDeleted = buckets[hashValue].RemoveByData(data);
            if (valueDeleted)
            {
                amountOfElements--;
                loadFactor = ((float)amountOfElements / size);
            }
            return valueDeleted;
        }

        /// <summary>
        /// Checks whether the hash table has the selected string or not.
        /// </summary>
        /// <param name="data">String to check.</param>
        /// <returns>Indicates whether the string is present in the hash table or not.</returns>
        public bool HashContains(string data)
        {
            var hashValue = CalculateHash(data, size);
            return buckets[hashValue].Contains(data);
        }

        /// <summary>
        /// Clears the hash table.
        /// </summary>
        public void Clear()
        {
            size = 10;
            amountOfElements = 0;
            loadFactor = 0;
            InitializeBuckets();
        }

        /// <summary>
        /// Changes hash function.
        /// </summary>
        /// <param name="hash">Hash to be changed to.</param>
        public void ChangeHashFunction(IHash hash)
        {
            this.hash = hash;
            ReSize(size);
        }

        /// <summary>
        /// Checks if a fill factor exceeds MaxFillFactor.
        /// </summary>
        private void FillFactorCheck()
        {
            if (amountOfElements / buckets.Length <= MaxFillFactor)
            {
                return;
            }

            ReSize(buckets.Length * 2);
        }

        /// <summary>
        /// Calculates hash of the input string and returns it.
        /// </summary>
        /// <param name="data">Input string.</param>
        /// <returns>hash value of input data</returns>
        public int GetHash(string data)
        {
            return CalculateHash(data, size);
        }
    }
}
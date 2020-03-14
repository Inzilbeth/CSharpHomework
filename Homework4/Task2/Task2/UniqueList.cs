using System;

/// <summary>
/// Global namespace.
/// </summary>
namespace Task2
{
    public class UniqueList<T> : LinkedList<T>
    {
        /// <summary>
        /// Adds only unique data to the list.
        /// </summary>
        /// <param name="data">Data to be added.</param>
        /// <param name="number">Position for the new value to be set at.</param>
        public override void AddByNumber(int number, T data)
        {
            if (Contains(data))
            {
                throw new ElementIsAlreadyPresentException($"Element {data} already exist.");
            }
            else
            {
                base.AddByNumber(number, data);
            }
        }
    }
}

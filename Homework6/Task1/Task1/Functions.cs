using System;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Class with the implementation of list modifying functions.
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Applies a function to each element of the list.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="function">Function to be applied.</param>
        /// <returns>Result.</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = function(list[i]);
            }

            return list;
        }

        /// <summary>
        /// Filters the list returning the list only with the elements
        /// that passed the filter.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="function">Function to be applied.</param>
        /// <returns>Filtered list.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (!function(list[i]))
                {
                    list.RemoveAt(i);
                }
            }

            return list;
        }

        /// <summary>
        /// Accumulates the value prior to the input function.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="startValue">Starting value for the function.</param>
        /// <param name="function">Input function.</param>
        /// <returns>Result.</returns>
        public static int Fold(List<int> list, int startValue, Func<int, int, int> function)
        {
            foreach (int el in list)
            {
                startValue = function(startValue, el);
            }

            return startValue;
        }
    }
}

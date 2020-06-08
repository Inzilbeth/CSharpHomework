using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// Int comparator.
    /// </summary>
    public class CustomComparer : IComparer<int>
    {
        public int Compare(int first, int second)
            => first > second ? 1 : first == second ? 0 : -1;
    }
}

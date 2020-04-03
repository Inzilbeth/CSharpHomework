using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Functions
    {
        public List<int> Map(List<int> list, Func<int, int> function)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = function(list[i]);
            }

            return list;
        }

        public List<int> Filter(List<int> list, Func<int, bool> function)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(!function(list[i]))
                {
                    list.RemoveAt(i);
                }
            }

            return list;
        }

        public int Fold(List<int> list, int startValue, Func<int, int, int> function)
        {
            foreach (int el in list)
            {
                startValue = function(startValue, el);
            }

            return startValue;
        }

    }
}

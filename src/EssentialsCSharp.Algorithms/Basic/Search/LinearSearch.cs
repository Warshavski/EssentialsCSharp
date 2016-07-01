using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Algorithms.Basic.Search
{
    public static class LinearSearch
    {
        public static int Search(int[] array, int valueKey)
        {
            var indexTotal = array.Length;
            for (int indexCount = 0; indexCount < indexTotal; ++indexCount)
            {
                if (array[indexCount] == valueKey)
                {
                    return indexCount;
                }
            }

            return -1;
        }

        public static int SearchOptimaze(int[] array, int valueKey)
        {
            var indexTotal = array.Length;
            array[indexTotal] = valueKey;

            var indexCount = 0;
            while (array[indexCount] != valueKey)
            {
                ++indexCount;
            }

            if (indexCount < indexTotal)
            {
                return indexCount;
            }
            else
            {
                return -1;
            }
        }
    }
}

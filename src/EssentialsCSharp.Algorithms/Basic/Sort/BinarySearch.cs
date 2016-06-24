using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Algorithms.Basic.Sort
{
    public static class BinarySearch
    {
        public static int Search(int[] array, int valueKey)
        {
            throw new NotImplementedException();
        }

        private static int BinarySearchAlgo(int[] array, int valueKey)
        {
            var lowerBound = 0;
            var upperBound = array.Length - 1;

            while (lowerBound < upperBound)
            {
                var middleIndex = (lowerBound + upperBound) / 2;

                if (array[middleIndex] == valueKey)
                {
                    return middleIndex;
                }

                if (array[middleIndex] < valueKey)
                {
                    lowerBound = middleIndex + 1;
                }

                if (array[middleIndex] > valueKey)
                {
                    upperBound = middleIndex - 1;
                }
            }

            return -1;
        }

        private static int BinarySearchAlgo(int[] array, int valueKey, int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound)
            {
                return -1;
            }

            var middleIndex = (lowerBound + upperBound) / 2;

            if (array[middleIndex] == valueKey)
            {
                return middleIndex;
            }

            if (array[middleIndex] < valueKey)
            {
                return BinarySearchAlgo(array, valueKey, middleIndex + 1, upperBound);
            }

            if (array[middleIndex] > valueKey)
            {
                return BinarySearchAlgo(array, valueKey, lowerBound , middleIndex -1);
            }

            return -1;
        }
    }
}
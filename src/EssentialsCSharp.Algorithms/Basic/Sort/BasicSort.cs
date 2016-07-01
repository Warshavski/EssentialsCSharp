using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Algorithms.Basic.Sort
{
    public static class BasicSort<TValue> where TValue : IComparable
    {
        public static void BubbleSort(TValue[] array) 
        {
            for (int i = 0; i < array.Length; ++i)
            {
                for (int comparisonIndex = 0; comparisonIndex < array.Length - i - 1; ++comparisonIndex)
                {
                    var comparisonResult = array[comparisonIndex].CompareTo(array[comparisonIndex + 1]);
                    if (comparisonResult > 0)
                    {
                        var temp = array[comparisonIndex];
                        array[comparisonIndex] = array[comparisonIndex + 1];
                        array[comparisonIndex + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(TValue[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                var selectedIndex = i;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    var comparisonResult = array[j].CompareTo(array[selectedIndex]);
                    if (comparisonResult < 0)
                    {
                        selectedIndex = j;
                    }
                }

                var temp = array[selectedIndex];
                array[selectedIndex] = array[i];
                array[i] = temp;
            }
        }

        public static void InsertionSort(TValue[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                var insertedValue = array[i];
                var insertedIndex = i;
                
                while (insertedIndex > 0 && 
                    (array[insertedIndex-1].CompareTo(insertedValue) >= 0))
                {
                    array[insertedIndex] = array[insertedIndex - 1];
                    --insertedIndex;
                }
                array[insertedIndex] = insertedValue;
            }
        }
    }
}

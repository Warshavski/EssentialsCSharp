using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Algorithms.Basic.Sort
{
    public static class ShellSort
    {
        public static void Sort<TValue>(TValue[] array) 
            where TValue : IComparable
        {
            int inner;
            int outer;
            TValue tempValue;
            int increment = 1;

            int itemsTotal = array.Count();

            while (increment <= itemsTotal / 3)
            {
                increment = increment * 3 + 1;
            }

            while (increment > 0)
            {
                for (outer = increment; outer < itemsTotal; ++outer)
                {
                    tempValue = array[outer];
                    inner = outer;

                    while (inner > increment - 1 && array[inner - increment].CompareTo(tempValue)>= 0)
                    {
                        array[inner] = array[inner - increment];
                        inner -= increment;
                    }

                    array[inner] = tempValue;
                }
                increment = (increment - 1) / 3;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EssentialsCSharp.Algorithms.Basic.Sort;

using EssentialsCSharp.Patterns.Creational.AbstractFactory;
using System.Collections;

namespace EssentialsCSharp.Console.App
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Factory pattern test
            var outputWriter = System.Console.Out;

            outputWriter.WriteLine("Factory ONE : " + Environment.NewLine);
            var productFactoryOne = new ConcreteFactoryOne();
            var client = new Client(productFactoryOne);

            client.TestFactory(outputWriter);

            outputWriter.WriteLine(Environment.NewLine);

            outputWriter.WriteLine("Factory TWO : " + Environment.NewLine);
            var productFactoryTwo = new ConcreteFactoryTwo();
            client = new Client(productFactoryTwo);

            client.TestFactory(outputWriter);
            */
            var array = new int[100];
            Random rndValue = new Random(1);

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rndValue.Next(1000);
            }

            System.Console.WriteLine("Before sort : ");
            PrintArray<int[]>(array);

            BasicSort<int>.InsertionSort(array);
            System.Console.Write(Environment.NewLine + "--------------" + Environment.NewLine);

            System.Console.WriteLine("Afer sort : ");
            PrintArray<int[]>(array);
        }

        public static void PrintArray<TValue>(TValue array)  where TValue : IEnumerable
        {
            foreach (var item in array)
            {
                System.Console.Write(item + " ");
            }
        }
    }
}

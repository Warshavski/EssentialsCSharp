using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EssentialsCSharp.Patterns.Creational.AbstractFactory;

namespace EssentialsCSharp.Console.App
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}

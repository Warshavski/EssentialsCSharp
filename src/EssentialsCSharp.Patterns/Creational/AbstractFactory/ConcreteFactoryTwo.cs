using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public class ConcreteFactoryTwo : AbstactFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ConcreteProductATwo("Product from factory TWO");
        }

        public override AbstractProductB CreateProductB()
        {
            return new ConcreteProductBTwo(20);
        }
    }
}

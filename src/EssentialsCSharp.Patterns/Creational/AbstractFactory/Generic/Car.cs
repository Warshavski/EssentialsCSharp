using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    // concrete factory
    class Car : IFactory<Car>
    {
        public TProduct Build<TProduct>() where TProduct : IProduct<Car>, new()
        {
            return new TProduct();
        }
    }
}

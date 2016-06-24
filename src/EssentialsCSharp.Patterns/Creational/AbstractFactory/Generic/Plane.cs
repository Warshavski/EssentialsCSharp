using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    // concrete factory
    class Plane : IFactory<Plane>
    {
        public TProduct Build<TProduct>() where TProduct : IProduct<Plane>, new()
        {
            return new TProduct();
        }
    }
}

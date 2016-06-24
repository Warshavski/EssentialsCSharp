using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    // concrete product
    class ConcreteCarOne : IProduct<Car>
    {
        public void Operate()
        {
            throw new NotImplementedException();
        }

        public string CarOneSpecificOperation()
        {
            return "This is car one specific operation";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    class ConcreteCarTwo : IProduct<Car>
    {
        public void Operate()
        {
            throw new NotImplementedException();
        }

        public string CarTwoSpecific()
        {
            return "This is specific car two!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    class Client
    {
        public void FactoryTest()
        {
            var carFactory = new Factory<Car>();
            var car = carFactory.Create<ConcreteCarOne>();
            
            car.Operate();
            car.CarOneSpecificOperation();
        }
    }
}

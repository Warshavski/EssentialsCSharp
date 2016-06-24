using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    class ConcretePlaneTwo : IProduct<Plane>
    {
        public void Operate()
        {
            throw new NotImplementedException();
        }

        public string GetPlaneSpecification()
        {
            return "No specification awaliable for plane two";
        }
    }
}

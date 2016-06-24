using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    class ConcretePlaneOne : IProduct<Plane>
    {
        public void Operate()
        {
            throw new NotImplementedException();
        }

        public string GetPlaneDescription()
        {
            return "This is plane one";
        }
    }
}

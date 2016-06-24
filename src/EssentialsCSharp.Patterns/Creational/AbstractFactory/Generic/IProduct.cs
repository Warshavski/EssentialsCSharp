using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory.Generic
{
    // abstract product
    interface IProduct<TFactory>
    {
        void Operate();
    }
}

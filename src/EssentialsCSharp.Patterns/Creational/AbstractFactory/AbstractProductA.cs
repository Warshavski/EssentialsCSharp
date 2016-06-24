using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public abstract class AbstractProductA
    {
        protected string _name;
        public abstract string Name { get; }

        protected AbstractProductA(string name)
        {
            _name = name;
        }

        public abstract void Execute();
        public abstract void Print(TextWriter writer);
    }
}

using System.IO;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public abstract class AbstractProductB
    {
        public int Value { get; protected set; }
        
        protected AbstractProductB(int value)
        {
            Value = value;
        }

        public abstract void Calculate(int addition);
        public abstract void Print(TextWriter writer);
    }
}

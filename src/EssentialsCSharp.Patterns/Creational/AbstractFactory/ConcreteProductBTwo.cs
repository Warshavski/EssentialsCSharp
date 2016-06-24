
namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class ConcreteProductBTwo : AbstractProductB
    {
        private const string OBJECT_TYPE = "Type B TWO";

        public ConcreteProductBTwo(int initialValue)
            : base(initialValue)
        {

        }

        public override void Calculate(int addition)
        {
            Value *= addition;
        }

        public override void Print(System.IO.TextWriter writer)
        {
            writer.WriteLine(
               string.Format("{0} after multiplication : {1}", OBJECT_TYPE, Value));
        }
    }
}

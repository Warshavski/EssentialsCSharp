
namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class ConcreteProductBOne : AbstractProductB
    {
        private const string OBJECT_TYPE = "Type B ONE";

        public ConcreteProductBOne(int initialValue)
            : base(initialValue)
        {

        }

        public override void Calculate(int addition)
        {
            Value += addition;
        }

        public override void Print(System.IO.TextWriter writer)
        {
            writer.WriteLine(
                string.Format("{0} after addition : {1}", OBJECT_TYPE, Value));
        }
    }
}

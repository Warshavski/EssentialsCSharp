
namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class ConcreteProductAOne : AbstractProductA
    {
        private const string OBJECT_TYPE = "Type A ONE";

        private string _innerState;

        public override string Name
        {
            get 
            {
                return string.Format("{0} - {1}", base._name, OBJECT_TYPE);
            }
        }

        public ConcreteProductAOne(string productName)
            : base(productName)
        {
            _innerState = "initialized";
        }

        public override void Execute()
        {
            _innerState = "some operation was executed";
        }

        public override void Print(System.IO.TextWriter writer)
        {
            writer.WriteLine(string.Format("{0} : {1}", Name, _innerState));
        }
    }
}

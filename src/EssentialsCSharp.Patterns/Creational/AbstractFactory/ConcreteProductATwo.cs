using System;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class ConcreteProductATwo : AbstractProductA
    {
        private const string OBJECT_TYPE = "Type A TWO";

        private string _operationState;

        public override string Name
        {
            get
            {
                return string.Format("{0} - {1}", base._name, OBJECT_TYPE);
            }
        }

        public ConcreteProductATwo(string productName)
            : base(productName)
        {
            _operationState = "not executed";
        }

        public override void Execute()
        {
            _operationState = "operation was initialized";
        }

        public override void Print(System.IO.TextWriter writer)
        {
            var timeStamp = DateTime.Today;
            writer.Write(timeStamp + " | ");
            writer.WriteLine(string.Format("{0} : {1}", Name, _operationState));
        }
    }
}

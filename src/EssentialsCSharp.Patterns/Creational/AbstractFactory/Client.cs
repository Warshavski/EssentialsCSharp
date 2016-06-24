using System.IO;

namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class Client
    {
        private readonly AbstactFactory _factory;

        public Client(AbstactFactory factory)
        {
            _factory = factory;
        }

        public void TestFactory(TextWriter outputStream)
        {
            var productOne = _factory.CreateProductA();
            var productTwo = _factory.CreateProductB();

            productOne.Print(outputStream);
            productOne.Execute();
            productOne.Print(outputStream);

            outputStream.WriteLine("------------------------------");

            productTwo.Calculate(20);
            productTwo.Print(outputStream);
        }
    }
}

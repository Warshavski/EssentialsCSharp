
namespace EssentialsCSharp.Patterns.Creational.AbstractFactory
{
    public sealed class ConcreteFactoryOne : AbstactFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ConcreteProductAOne("Product from factory ONE");
        }

        public override AbstractProductB CreateProductB()
        {
            return new ConcreteProductBOne(10);
        }
    }
}

using DB_SOLID.Structural_Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Structural_Patterns
{

    public interface IComponent
    {
        string Operation();
    }

    // Concrete component
    public class ConcreteComponent : IComponent
    {
        public string Operation()
        {
            return "ConcreteComponent";
        }
    }
    public class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual string Operation() => _component.Operation();
    }
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }
    internal class Decarator_Pattern
    {
        static void Main()
        {
            IComponent component = new ConcreteComponent();
            Console.WriteLine("ConcreteComponent: " + component.Operation());

            IComponent decoratorA = new ConcreteDecoratorA(component);
            Console.WriteLine("ConcreteDecoratorA: " + decoratorA.Operation());

            IComponent decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("ConcreteDecoratorB: " + decoratorB.Operation());
        }
    }
}

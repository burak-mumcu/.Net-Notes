namespace DB_SOLID.Structural_Patterns
{
    public interface IImplementation
    {
        void Operation();
    }
    public class ConcreteImplementationA : IImplementation
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteImplementationA Operation.");
        }
    }
    public class ConcreteImplementationB : IImplementation
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteImplementationB Operation.");
        }
    }

    public class Abstraction
    {
        protected IImplementation _implementation;
        public Abstraction(IImplementation implementation)
        {
            
        _implementation = implementation;
        }
        public virtual void Operation()
        {
            _implementation.Operation();
        }
    }

    class Bridge_Pattern
    {
        static void Main(string[] args)
        {
            IImplementation implementationA = new ConcreteImplementationA();
            Abstraction abstractionA = new Abstraction(implementationA);
            abstractionA.Operation();

            IImplementation implementationB = new ConcreteImplementationB();
            Abstraction abstractionB = new Abstraction(implementationB);
            abstractionB.Operation();
        }
    }
}

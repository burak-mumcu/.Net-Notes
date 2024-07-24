using System;
using System.Collections.Generic;

namespace Patterns.Behavioral_Patterns
{
    // Mediator arayüzü
    public interface IMediator
    {
        void Send(string message, Colleague colleague);
    }

    // Concrete Mediator
    public class ConcreteMediator : IMediator
    {
        private List<Colleague> _colleagues = new List<Colleague>();

        public void Register(Colleague colleague)
        {
            _colleagues.Add(colleague);
        }

        public void Send(string message, Colleague colleague)
        {
            foreach (var c in _colleagues)
            {
                if (c != colleague)
                {
                    c.Receive(message);
                }
            }
        }
    }

    // Colleague arayüzü
    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract void Receive(string message);
    }

    // Concrete Colleague 1
    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(IMediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            Console.WriteLine($"Colleague1 sends message: {message}");
            _mediator.Send(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine($"Colleague1 receives message: {message}");
        }
    }

    // Concrete Colleague 2
    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(IMediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            Console.WriteLine($"Colleague2 sends message: {message}");
            _mediator.Send(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine($"Colleague2 receives message: {message}");
        }
    }

    class Mediator_Pattern
    {
        static void Main(string[] args)
        {
            ConcreteMediator mediator = new ConcreteMediator();

            ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
            ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

            mediator.Register(colleague1);
            mediator.Register(colleague2);

            // Mesaj gönder
            colleague1.Send("Hello, World!");
            colleague2.Send("Hi there!");
        }
    }
}

using System;

namespace Patterns.Behavioral_Patterns
{
    // Durum arayüzü
    public interface IState
    {
        void Handle(Context context);
    }

    // Concrete State A
    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State A: Handling request and changing to State B.");
            context.State = new ConcreteStateB();
        }
    }

    // Concrete State B
    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State B: Handling request and changing to State A.");
            context.State = new ConcreteStateA();
        }
    }

    // Context
    public class Context
    {
        private IState _state;

        public Context(IState state)
        {
            State = state;
        }

        public IState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine($"State: {_state.GetType().Name}");
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    class State_Pattern
    {
        static void Main(string[] args)
        {
            // Başlangıç durumunu ayarla
            Context context = new Context(new ConcreteStateA());

            // İstekleri gönder ve durumu değiştir
            context.Request();
            context.Request();
        }
    }
}


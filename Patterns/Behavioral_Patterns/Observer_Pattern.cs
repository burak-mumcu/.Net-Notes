using System;
using System.Collections.Generic;

namespace Patterns.Behavioral_Patterns
{
    // Gözlemci arayüzü
    public interface IObserver
    {
        void Update(string message);
    }

    // Konu (Subject) arayüzü
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Concrete Subject
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_state);
            }
        }
    }

    // Concrete Observer
    public class ConcreteObserver : IObserver
    {
        private string _name;

        public ConcreteObserver(string name)
        {
            _name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Observer {_name} has received update with message: {message}");
        }
    }

    class Observer_Pattern
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();

            ConcreteObserver observer1 = new ConcreteObserver("A");
            ConcreteObserver observer2 = new ConcreteObserver("B");

            subject.Attach(observer1);
            subject.Attach(observer2);

            // Durumu güncelle ve gözlemcileri bilgilendir
            subject.State = "State has changed";
        }
    }
}


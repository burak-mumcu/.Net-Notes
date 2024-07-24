using System;
using System.Collections.Generic;

namespace Patterns.Behavioral_Patterns
{
    // Memento
    public class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Originator
    public class Originator
    {
        public string State { get; set; }

        public Memento SaveStateToMemento()
        {
            return new Memento(State);
        }

        public void GetStateFromMemento(Memento memento)
        {
            State = memento.State;
        }
    }

    // Caretaker
    public class Caretaker
    {
        private List<Memento> _mementoList = new List<Memento>();

        public void Add(Memento state)
        {
            _mementoList.Add(state);
        }

        public Memento Get(int index)
        {
            return _mementoList[index];
        }
    }

    class Memento_Pattern
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            // Durumu kaydet
            originator.State = "State #1";
            originator.State = "State #2";
            caretaker.Add(originator.SaveStateToMemento());

            originator.State = "State #3";
            caretaker.Add(originator.SaveStateToMemento());

            originator.State = "State #4";
            Console.WriteLine("Current State: " + originator.State);

            // Önceki durumu geri yükle
            originator.GetStateFromMemento(caretaker.Get(0));
            Console.WriteLine("First saved State: " + originator.State);
            originator.GetStateFromMemento(caretaker.Get(1));
            Console.WriteLine("Second saved State: " + originator.State);
        }
    }
}

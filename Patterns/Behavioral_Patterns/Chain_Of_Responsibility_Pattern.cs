using System;

namespace Patterns.Behavioral_Patterns
{
    // Handler arayüzü
    public abstract class Handler
    {
        protected Handler? _nextHandler;

        public void SetNextHandler(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(int request);
    }

    // Concrete Handler 1
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine($"{GetType().Name} handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    // Concrete Handler 2
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"{GetType().Name} handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    // Concrete Handler 3
    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"{GetType().Name} handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    class Chain_Of_Responsibility_Pattern
    {
        static void Main(string[] args)
        {
            // Handler zincirini oluştur
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            h1.SetNextHandler(h2);
            h2.SetNextHandler(h3);

            // İstekleri işle
            int[] requests = { 5, 14, 22, 18, 3, 27 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }
}


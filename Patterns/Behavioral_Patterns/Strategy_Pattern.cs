

using System;

namespace Patterns.Behavioral_Patterns
{
    // Strateji arayüzü
    public interface IStrategy
    {
        int DoOperation(int num1, int num2);
    }

    // Concrete Strategy A
    public class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    // Concrete Strategy B
    public class OperationSubtract : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    // Concrete Strategy C
    public class OperationMultiply : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    // Context
    public class ContextData
    {
        private IStrategy _strategy;

        public ContextData(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int ExecuteStrategy(int num1, int num2)
        {
            return _strategy.DoOperation(num1, num2);
        }
    }

    class Strategy_Pattern 
    {
        static void Main(string[] args)
        {
            ContextData context = new ContextData(new OperationAdd());
            Console.WriteLine("10 + 5 = " + context.ExecuteStrategy(10, 5));

            context = new ContextData(new OperationSubtract());
            Console.WriteLine("10 - 5 = " + context.ExecuteStrategy(10, 5));

            context = new ContextData(new OperationMultiply());
            Console.WriteLine("10 * 5 = " + context.ExecuteStrategy(10, 5));
        }
    }
}

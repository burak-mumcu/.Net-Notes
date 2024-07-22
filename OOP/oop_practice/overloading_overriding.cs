namespace oop_practice
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class overloading_overriding
    {
        public static void Main()
        {
            MathOperations mathOperations = new MathOperations();
            Console.WriteLine(mathOperations.Add(1, 5));
            Console.WriteLine(mathOperations.Add(2.5, 6.2));

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Display(); // Derived display.
        }
    }

    public class BaseClass
    {
        public virtual void Display()
        { 
            Console.WriteLine("Base display.");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void Display()
        {
            Console.WriteLine("Derived display.");
        }
    }

}

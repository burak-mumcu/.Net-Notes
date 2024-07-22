using System;

namespace oop_practice
{

    public class Animal2
    {
        public virtual void Sound()
        {
            Console.WriteLine("Making Sound...");
        }
    }

    public class Cat : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("More Sound...");
        }
    }

    public class Bird : Animal2
    {
        public override void Sound()
        {
            Console.WriteLine("Different Sound...");
        }
    }
    public class Polymorphism
    {
        public static void Main()
        {
            Animal2 animal = new Cat();
            animal.Sound(); // More Sound...

            animal = new Bird();
            animal.Sound(); // Different Sound...
        }
    }
}

using System;

namespace oop_practice
{
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }
   // burada dog sınıfı animal'dan türüyor
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
    }
    class Inheritance
    {
        public static void Main()
        {
            var dog = new Dog();
            // dog sınıfı animaldan türediği için animal'a ait özellikleri kullanabiliyor
            dog.Eat(); // Eating...
            dog.Bark(); // Barking...
        }
    }
}


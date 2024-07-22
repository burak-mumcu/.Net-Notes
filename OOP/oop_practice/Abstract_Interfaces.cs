namespace oop_practice
{
    class Abstract_Interfaces
    {
        static void Main()
        {
            Circle circle = new Circle { Radius = 5 };
            Console.WriteLine($"Circle's area: {circle.GetArea()}");

            // Car2 sınıfının bir örneğini oluşturma ve hareket ettirme
            Car2 car = new Car2();
            car.Move();
        }
    }

    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

    }

    public interface IMovable
    {
        void Move();
    }

    public class Car2 : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Car is moving.");
        }
    }

}

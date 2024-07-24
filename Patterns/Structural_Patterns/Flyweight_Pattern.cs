using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural_Patterns
{
    public interface IShape
    {
        void Draw();
    }

    // Concrete Flyweight
    public class Circle : IShape
    {
        private string _color;
        private int _x;
        private int _y;
        private int _radius;

        public Circle(string color)
        {
            _color = color;
        }

        public void SetX(int x)
        {
            _x = x;
        }

        public void SetY(int y)
        {
            _y = y;
        }

        public void SetRadius(int radius)
        {
            _radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Circle: Draw() [Color : {_color}, x : {_x}, y :{_y}, radius :{_radius}]");
        }
    }

    // Flyweight Factory
    public class ShapeFactory
    {
        private static Dictionary<string, IShape> _circleMap = new Dictionary<string, IShape>();

        public static IShape GetCircle(string color)
        {
            if (!_circleMap.ContainsKey(color))
            {
                Circle circle = new Circle(color);
                _circleMap[color] = circle;
                Console.WriteLine($"Creating circle of color : {color}");
            }

            return _circleMap[color];
        }
    }

    class Flyweight_Pattern
    {
        private static readonly string[] colors = { "Red", "Green", "Blue", "White", "Black" };

        static void Main(string[] args)
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetCircle(getRandomColor());
                circle.SetX(getRandomX());
                circle.SetY(getRandomY());
                circle.SetRadius(100);
                circle.Draw();
            }
        }

        private static string getRandomColor()
        {
            Random rand = new Random();
            return colors[rand.Next(colors.Length)];
        }

        private static int getRandomX()
        {
            Random rand = new Random();
            return rand.Next(100);
        }

        private static int getRandomY()
        {
            Random rand = new Random();
            return rand.Next(100);
        }
    }
}

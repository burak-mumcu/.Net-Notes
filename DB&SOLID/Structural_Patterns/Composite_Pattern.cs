using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Structural_Patterns
{
    public interface IComponent
    {
        void Operation();
    }
    public class Leaf : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("Leaf operation.");
        }
    }
    public class Composite : IComponent
    {
        private List<IComponent> _children = new List<IComponent>
       ();
        public void Add(IComponent component)
        {
            _children.Add(component);
        }
       
        public void Remove(IComponent component)
        {
            _children.Remove(component);
        }
        public void Operation()
        {
            foreach (var child in _children)
            {
                child.Operation();
            }
        }
    }

    class Composite_Pattern
    {
        static void Main()
        {
            Leaf leaf1 = new Leaf();
            Leaf leaf2 = new Leaf();
            Leaf leaf3 = new Leaf();

            // Create composite objects
            Composite composite1 = new Composite();
            Composite composite2 = new Composite();

            // Add leaf objects to composite1
            composite1.Add(leaf1);
            composite1.Add(leaf2);

            // Add composite1 and leaf3 to composite2
            composite2.Add(composite1);
            composite2.Add(leaf3);

            // Execute operations
            Console.WriteLine("Composite 1 Operation:");
            composite1.Operation();

            Console.WriteLine("Composite 2 Operation:");
            composite2.Operation();
        }

    }

}



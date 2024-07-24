using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural_Patterns
{
    public class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("Subsystem A, Method A");
        }
    }

    // Subsystem class B
    public class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("Subsystem B, Method B");
        }
    }

    // Subsystem class C
    public class SubsystemC
    {
        public void OperationC()
        {
            Console.WriteLine("Subsystem C, Method C");
        }
    }

    // Facade class
    public class Facade
    {
        private SubsystemA _subsystemA;
        private SubsystemB _subsystemB;
        private SubsystemC _subsystemC;

        public Facade()
        {
            _subsystemA = new SubsystemA();
            _subsystemB = new SubsystemB();
            _subsystemC = new SubsystemC();
        }

        public void Operation()
        {
            _subsystemA.OperationA();
            _subsystemB.OperationB();
            _subsystemC.OperationC();
        }
    }


    class Facade_Pattern
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.Operation();
        }
    }
}

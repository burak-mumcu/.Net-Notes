using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Dependency_Injections
{
    internal class Constructor_Injection
    {
        private readonly IDependency _dependency;

        public Constructor_Injection(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void DoWork()
        {
            _dependency.PerformOperation();
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Dependency_Injections
{
    public class Method_Injection
    {
        public void DoWork(IDependency dependency)
        {
            dependency.PerformOperation();
        }
    
    }

}

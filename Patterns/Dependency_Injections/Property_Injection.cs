using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Dependency_Injections
{
    public class Property_Injection
    {
        public IDependency Dependency { get; set; }

        public void DoWork()
        {
            Dependency.PerformOperation();
        }
    }
}

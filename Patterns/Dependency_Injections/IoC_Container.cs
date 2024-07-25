using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Dependency_Injections
{
    public interface IDependency
    {
        void PerformOperation();
    }

    public class Dependency : IDependency
    {
        public void PerformOperation()
        {
            // İşlemleri gerçekleştir
        }
    }

    public class IoC_Container
    {
        private readonly IDependency _dependency;

        public IoC_Container(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void DoWork()
        {
            _dependency.PerformOperation();
        }
    }

}

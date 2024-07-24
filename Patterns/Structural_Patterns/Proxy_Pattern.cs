using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural_Patterns
{

    // Subject interface
    public interface ISubject
    {
        void Request();
    }

    // Real Subject
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // Proxy
    public class Proxy : ISubject
    {
        private RealSubject? _realSubject;

        public void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            Console.WriteLine("Proxy: Logging request before calling RealSubject.");
            _realSubject.Request();
        }
    }
    class Proxy_Pattern
    {
        static void Main(string[] args)
        {
            ISubject proxy = new Proxy();
            proxy.Request();
        }
    }
}

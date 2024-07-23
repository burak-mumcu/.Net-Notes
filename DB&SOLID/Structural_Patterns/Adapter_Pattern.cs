using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Structural_Patterns
{
    public interface ITarget
    {
        void Request();
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Specific request.");
        }
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    class Adapter_Pattern
    {
        static void Main(string[] args)
        {
            // Adaptee nesnesi oluşturuluyor
            Adaptee adaptee = new Adaptee();

            // Adapter kullanılarak ITarget arayüzüne uyumlu hale getiriliyor
            ITarget target = new Adapter(adaptee);

            // Adapter üzerinden Request metodu çağrılıyor
            target.Request();
        }
    }
}

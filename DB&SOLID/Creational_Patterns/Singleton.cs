using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Creational_Patterns
{
    // sealed anahtar kelimesi ile sınıfın türetilmesi engellenir
    public sealed class Singleton
    {
        // sınıfın örneği bu değişkende tutulur
        private static Singleton _instance = null;
        //Thread-safe erişimi sağlamak için kullanılır
        private static readonly object _lock = new object();

        //Sınıfın dışarıdan örneklenmesini engelleyen private constructor.
        private Singleton()
        {
        }

        /* 
         public static Singleton Instance: Singleton örneğine global erişim noktası.
         Bu property, lock anahtar kelimesi ile thread-safe hale getirilmiştir.
         */
        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is doing something!");
        }
    }

    class SingletonTest
    {
        static void Main()
        {
            Singleton singleton1 = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance;

            singleton1.DoSomething();

            if (singleton1 == singleton2)
            {
                Console.WriteLine("Both instances are the same.");
            }
            else
            {
                Console.WriteLine("Instances are different.");
            }
        }
    }

}

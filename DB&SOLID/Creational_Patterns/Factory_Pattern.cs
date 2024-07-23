using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB_SOLID.Creational_Patterns
{
    public abstract class Creator
    {
        public abstract Singleton FactoryMethod();
    }

    //SingletonCreator adında, Creator sınıfından türeyen bir sınıf oluşturulmuştur.
    //Bu sınıf, FactoryMethod metodunu override ederek Singleton nesnesini döner.

    public class SingletonCreator : Creator
    {
        public override Singleton FactoryMethod()
        {
            return Singleton.Instance;
        }
    }
}

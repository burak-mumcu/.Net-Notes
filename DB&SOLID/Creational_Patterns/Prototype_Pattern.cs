using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Creational_Patterns
{
    public abstract class Prototype
    {
        //Prototype sınıfı, klonlama işlemi için bir Clone metoduna sahip soyut bir sınıftır.
        //Bu sınıf, klonlanacak nesneler için bir şablon görevi görür.
        public abstract Prototype Clone();
    }

    public class ConcretePrototype : Prototype
    {
        //ConcretePrototype sınıfı, Prototype sınıfından türetilmiştir ve Clone metodunu implemente eder.
        //MemberwiseClone metodunu kullanarak, nesnenin yüzeysel bir kopyasını oluşturur.
        //Bu kopyalama yöntemi, nesnenin tüm alanlarını (primitive tipler, stringler, ve diğer referans tipli alanlar) kopyalar,
        //ancak referans tipli alanların derin kopyasını oluşturmaz.
        public string Data { get; set; }
        public override Prototype Clone()
        {
            return (Prototype)MemberwiseClone();

        }
    }

    class Prototype_Pattern
    {
        static void Main(string[] args)
        {
            // Orijinal nesneyi oluştur
            ConcretePrototype original = new ConcretePrototype();
            original.Data = "Original Data";

            // Orijinal nesneyi klonla
            ConcretePrototype clone = (ConcretePrototype)original.Clone();
            clone.Data = "Cloned Data";

            // Orijinal ve klonlanmış nesnelerin verilerini yazdır
            Console.WriteLine("Original Data: " + original.Data);
            Console.WriteLine("Cloned Data: " + clone.Data);

            // Orijinal ve klonlanmış nesnelerin referanslarını karşılaştır
            if (original == clone)
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

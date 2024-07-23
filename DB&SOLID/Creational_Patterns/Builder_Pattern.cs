using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID.Creational_Patterns
{

    public class Product
    {
        //Product sınıfı, oluşturulacak nesneyi temsil eder ve
        //üç parçadan (PartA, PartB, PartC) oluşur.
        //Show metodu, parçaların değerlerini konsola yazdırır.
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public void Show()
        {
            Console.WriteLine("PartA: " + PartA);
            Console.WriteLine("PartB: " + PartB);
            Console.WriteLine("PartC: " + PartC);
        }
    }

    public interface IBuilder
    {
        //IBuilder arayüzü, Product nesnesini oluşturmak için gerekli
        //metotları tanımlar: BuildPartA, BuildPartB, BuildPartC ve GetResult.
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetResult();
    }

    public class ConcreteBuilder : IBuilder
    {
        //ConcreteBuilder sınıfı, IBuilder arayüzünü implemente eder
        //ve Product nesnesinin parçalarını oluşturur.
        private Product _product = new Product();

        public void BuildPartA()
        {
            _product.PartA = "PartA built";
        }

        public void BuildPartB()
        {
            _product.PartB = "PartB built";
        }

        public void BuildPartC()
        {
            _product.PartC = "PartC built";
        }

        public Product GetResult()
        {
            return _product;
        }
    }
    public class Director
    {
        //Director sınıfı, Product nesnesini oluşturma sürecini kontrol eder
        //ve hangi parçaların hangi sırayla oluşturulacağını belirler.

        public void Construct(IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    class Builder_Pattern
    {
        //Main metodunda, Director ve ConcreteBuilder nesneleri oluşturulur.
        //Director nesnesi, ConcreteBuilder nesnesini kullanarak Product nesnesini oluşturur
        //ve Product nesnesi üzerinde işlemler yapılır.
        static void Main(string[] args)
        {
            Director director = new Director();
            IBuilder builder = new ConcreteBuilder();

            director.Construct(builder);

            Product product = builder.GetResult();
            product.Show();
        }
    }
}

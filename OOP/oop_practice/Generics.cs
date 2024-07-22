namespace oop_practice
{
    class Generics
    {
        public static void main() 
        {
            var intInstance = new GenericClass<int> { Data = 10 };
            var StrInstance = new GenericClass<string> { Data = "test" };
            Console.WriteLine(intInstance.Data); // 10
            Console.WriteLine(StrInstance.Data); // test
        }
    }

    public class GenericClass<T>
    { 
        // Genericsleri kullanarak tipi belirtilmemiş sınıf metod veya interfaceler tanımlayabiliriz
        public required T Data { get; set; }
    }
}

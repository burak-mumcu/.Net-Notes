
namespace oop_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new() { Id=1, Make = "Toyota", Model = "Corolla" };
            car.Drive(); // Toyota Corolla is driving.
        }
    }

    public class Car
    {
        //required Id değerine zorunluluk verir
        public required int Id {  get; set; }
        // type'tan sonra gelen ? özelliğin null olabileceğini ifade eder
        public string? Make { get; set; }
        public string? Model { get; set; }

        public void Drive()
        {
            Console.WriteLine($"{Make} {Model} is driving.");
        }
    }
}


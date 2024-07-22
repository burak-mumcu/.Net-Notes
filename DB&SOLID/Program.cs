using System;
using System.Linq;
using DB_SOLID;

class Program
{
    static void Main()
    {

        using (var context = new AppDbContext())
        {
            // Veri Ekleme
            var newFood = new Food
            {
                name = "WaterMelon",
                price = 25M,
                description = null,
            };

            context.Foods.Add(newFood);
            context.SaveChanges();
            Console.WriteLine("Yeni veri eklendi!");

            // Verileri Listeleme
            var foods = context.Foods.ToList();
            foreach (var food in foods)
            {
                Console.WriteLine($"ID: {food.id}, Name: {food.name}, Price: {food.price}, Description: {food?.description}");
            }
        }
    }
}
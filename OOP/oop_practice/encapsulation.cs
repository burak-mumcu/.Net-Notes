using System;

namespace oop_practice
{
    public class BankAccount
    {
        // price'a doğrudan erişim private ile engellenmiş
        private decimal price;

        public void Deposit(decimal amount)
        {
            price += amount;
        }

        public decimal GetPrice()
        {
            // ancak GetPrice public olduğundan bu metod aracılığıyla price'a erişebiliyoruz
            return price;
        }
    }

    class Encapsulation
    {
        public static void Main()
        {
            var account = new BankAccount();
            account.Deposit(100);
            Console.WriteLine(account.GetPrice()); // 100
            account.Deposit(200);
            Console.WriteLine(account.GetPrice()); // 300
        }
       
    }


}

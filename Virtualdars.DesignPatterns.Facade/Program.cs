using System;

namespace Facade.RealWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Facade
            Financing application = new();

            Customer customer = new("Falonchi Pistonchi");
            decimal amount = 20000;
            bool isEligible = application.IsEligible(customer, amount);
            string result = isEligible ? "LOYIQ" :"NOLOYIQ";
            Console.WriteLine($"Natija: {customer.Name} 70% miqdorda moliyalashtirish uchun {result}.");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 'Subsystem ClassA' class
    /// </summary>
    public class Bank
    {
        public bool HasEnoughDownpaymentFunds(Customer customer)
        {
            Console.WriteLine($"Avvaldan to'lanadigan to'lov miqdori tekshirilmoqda...");
            Console.WriteLine("OK!");
            return true;
        }
    }

    /// <summary>
    /// 'Subsystem ClassB' class
    /// </summary>
    public class DM
    {
        public bool HasAllRequiredDocuments(Customer customer)
        {
            Console.WriteLine($"Kerakli xujjatlar tekshirilmoqda...");
            Console.WriteLine("OK!"); 
            return true;
        }
    }

    /// <summary>
    /// GFDSAGHJK'Subsystem ClassC' class
    /// </summary>
    public class CTOS
    {
        public bool HasGoodCreditScore(Customer customer)
        {
            Console.WriteLine("Kredit reytingi tekshirilmoqda...");
            Console.WriteLine("OK!");
            return true;
        }
    }

    /// <summary>
    /// 'Subsystem ClassD' class
    /// </summary>

    public class BNM
    {
        public bool IsBlacklisted(Customer customer)
        {
            Console.WriteLine("Qora ro'yxatda turishi tekshirilmoqda...");
            Console.WriteLine("OK!");
            return false;
        }
    }

    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }

    /// <summary>
    /// 'Facade' class
    /// </summary>
    public class Financing
    {
        Bank bank = new();
        DM dm = new();
        BNM bnm = new();
        CTOS ctos = new();

        public bool IsEligible(Customer cust, decimal amount)
        {
            Console.WriteLine($"{cust.Name} {amount}$ miqdorda moliyalashtirishga ariza berdi.");

            bool eligible = true;
            if (!dm.HasAllRequiredDocuments(cust))
            {
                eligible = false;
            }
            if (!bank.HasEnoughDownpaymentFunds(cust))
            {
                eligible = false;
            }
            else if (!ctos.HasGoodCreditScore(cust))
            {
                eligible = false;
            }
            else if (bnm.IsBlacklisted(cust))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}

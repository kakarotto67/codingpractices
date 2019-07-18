using System;

namespace ChainOfResponsibility
{
    // The Handler
    internal abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    // The ConcreteHandler
    internal class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // The ConcreteHandler
    internal class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // The ConcreteHandler
    internal class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }

    // Class holding request details
    internal class Purchase
    {
        // Gets or sets purchase number
        public int Number { get; set; }

        // Gets or sets purchase amount
        public double Amount { get; set; }

        // Gets or sets purchase purpose
        public string Purpose { get; set; }

        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this.Number = number;
            this.Amount = amount;
            this.Purpose = purpose;
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Setup Chain of Responsibility
            Approver director = new Director();
            Approver vicePresident = new VicePresident();
            Approver president = new President();

            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            // Generate and process purchase requests
            var p = new Purchase(2034, 350.00, "Assets");
            director.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            director.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            director.ProcessRequest(p);
        }
    }
}

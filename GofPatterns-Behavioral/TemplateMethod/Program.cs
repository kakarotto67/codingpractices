using System;
using System.Data;

namespace TemplateMethod
{
    // The AbstractClass
    abstract class DataAccessObject
    {
        protected string connectionString;

        public virtual void Connect()
        {
            connectionString = "connection string";
            Console.WriteLine("Connected to DB");
        }

        public abstract void Select();
        public abstract void Process();

        public virtual void Disconnect()
        {
            connectionString = String.Empty;
            Console.WriteLine("Disconnected from DB");
        }

        // The Template Method
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }

    // A ConcreteClass1
    class Categories : DataAccessObject
    {
        public override void Select()
        {
            Console.WriteLine("Selected 'Categories' from DB");
        }

        public override void Process()
        {
            Console.WriteLine("Processed 'Categories' from DB");
        }
    }

    // A ConcreteClass2
    class Products : DataAccessObject
    {
        public override void Select()
        {
            Console.WriteLine("Selected 'Products' from DB");
        }

        public override void Process()
        {
            Console.WriteLine("Processed 'Products' from DB");
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();
        }
    }
}

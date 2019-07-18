using System;

namespace Memento
{
    // The Originator
    class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Console.WriteLine("Name: " + name);
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                Console.WriteLine("Phone: " + phone);
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                budget = value;
                Console.WriteLine("Budget: " + budget);
            }
        }

        // Stores memento
        public Memento SaveMemento()
        {
            Console.WriteLine("Saving state");
            return new Memento(name, phone, budget);
        }

        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("Restoring state");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    // The Memento
    class Memento
    {
        // Gets or sets name
        public string Name { get; set; }

        // Gets or set phone
        public string Phone { get; set; }

        // Gets or sets budget
        public double Budget { get; set; }

        // Constructor
        public Memento(string name, string phone, double budget)
        {
            Name = name;
            Phone = phone;
            Budget = budget;
        }
    }

    // The Caretaker
    class ProspectMemory
    {
        public Memento Memento { get; set; }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            SalesProspect s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);
        }
    }
}

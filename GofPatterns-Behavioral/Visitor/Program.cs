using System;
using System.Collections.Generic;

namespace Visitor
{
    // The Visitor
    interface IVisitor
    {
        void Visit(Element element);
    }

    // A ConcreteVisitor1
    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
              employee.GetType().Name, employee.Name,
              employee.Income);
        }
    }

    // A ConcreteVisitor2
    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
              employee.GetType().Name, employee.Name,
              employee.VacationDays);
        }
    }

    // The Element
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    // The ConcreteElement
    class Employee : Element
    {
        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }

        // Constructor
        public Employee(string name, double income, int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // The ObjectStructure
    class Employees
    {
        private List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in employees)
            {
                e.Accept(visitor);
            }
        }
    }

    // Three employee types
    class Clerk : Employee
    {
        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        public Director()
            : base("Elly", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        public President()
            : base("Dick", 45000.0, 21)
        {
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Setup employee collection
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());
        }
    }
}

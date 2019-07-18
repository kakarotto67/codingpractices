using System;
using System.Collections.Generic;

namespace Strategy
{
    // The Strategy
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    // A ConcreteStrategy1
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            // Default is Quicksort
            list.Sort();
            Console.WriteLine("QuickSorted list");
        }
    }

    // A ConcreteStrategy2
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted list");
        }
    }

    // A ConcreteStrategy3
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list");
        }
    }

    // The Context
    class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortStrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortStrategy = sortstrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortStrategy.Sort(list);

            // Iterate over list and display results
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Create list of students
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");

            // Sort list using QuickSort strategy
            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            // Sort list using ShellSort strategy
            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            // Sort list using MergeSort strategy
            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
        }
    }
}

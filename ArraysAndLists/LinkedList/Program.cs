using LinkedList.LinkedList;
using System;

namespace LinkedList
{
   class Program
   {
      static void Main()
      {
         // Create linked list
         // 1 -> 5 -> 12 -> 11 -> 4 -> null

         // Option 1 - via constructors
         //var linkedList = new LinkedList<Int32>
         //{
         //   Root = new Node<Int32>(1,
         //             new Node<Int32>(5,
         //                new Node<Int32>(12,
         //                   new Node<Int32>(11,
         //                      new Node<Int32>(4, null)))))
         //};

         // Option 2 - via methods
         var linkedList = new LinkedList<Int32>()
            .AddNode(Node<Int32>.CreateNode(1))
            .AddNode(Node<Int32>.CreateNode(5))
            .AddNode(Node<Int32>.CreateNode(12))
            .AddNode(Node<Int32>.CreateNode(11))
            .AddNode(Node<Int32>.CreateNode(4));

         // Display linked list
         Console.WriteLine("Whole list:");
         linkedList.Print();

         Console.WriteLine("Last node:");
         linkedList.GetLast().PrintNode();

         // Reverse linked list
         // 4 -> 11 -> 12 -> 5 -> 1 -> null
         linkedList.Reverse();
         Console.WriteLine("Reversed list:");
         linkedList.Print();

         Console.ReadKey();
      }
   }
}
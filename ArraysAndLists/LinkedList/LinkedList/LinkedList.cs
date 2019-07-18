using System;

namespace LinkedList.LinkedList
{
   public class LinkedList<T>
   {
      public Node<T> Root { get; set; }

      // In linked list new node is added to the end and points to null
      // when previous node next have to point to new node
      public LinkedList<T> AddNode(Node<T> node)
      {
         if (node.Next != null)
         {
            throw new ArgumentException("Last node must point to null!");
         }

         if(Root == null)
         {
            Root = node;
         }
         else
         {
            GetLast().Next = node;
         }

         return this;
      }

      public Node<T> GetLast()
      {
         return GetLast(Root);
      }

      public void Print()
      {
         PrintNodes(Root);
      }

      public void Reverse()
      {
         // Set current to root to start with root
         Node<T> current = Root;
         // Set previous to null since there is no previous before root at the beginning
         Node<T> previous = null;

         // At the end current will become null, so check for null in while loop
         while(current != null)
         {
            // Presave next
            // Root.Next at the first iteration
            var tmp = current.Next;

            // Update current.Next to previous
            // At the first iteration it will set Root.Next to null
            // since Root is goint to be the last one and point to null
            current.Next = previous;

            // Set previous to be current
            // At the first iteration it will set previous (was null) to be Root
            previous = current;

            // Set current to its presaved next to simply go
            // to the next element in the linked list and proceed to next iteration
            current = tmp;
         }

         // Set Root to be previous, which after while loop will be
         // the last element in original linked list
         Root = previous;
      }

      private Node<T> GetLast(Node<T> node)
      {
         var last = node;

         if(node.Next != null)
         {
            return GetLast(node.Next);
         }
         else
         {
            return last;
         }
      }

      private void PrintNodes(Node<T> root)
      {
         root.PrintNode();
         if (root.Next != null)
         {
            PrintNodes(root.Next);
         }
      }
   }
}
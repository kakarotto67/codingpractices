using System;

namespace LinkedList.LinkedList
{
   public class Node<T>
   {
      private readonly T value;

      public Node<T> Next { get; set; }

      public Node(T value)
      {
         this.value = value;
         Next = null;
      }

      public Node(T value, Node<T> next)
      {
         this.value = value;
         Next = next;
      }

      public T GetNodeValue()
      {
         return value;
      }

      public void PrintNode()
      {
         PrintNode(this);
      }

      private void PrintNode(Node<T> node)
      {
         Console.WriteLine($"Node: value - {node.GetNodeValue()}");
      }

      public static Node<T> CreateNode(T value)
      {
         return new Node<T>(value);
      }
   }
}
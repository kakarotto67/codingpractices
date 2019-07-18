using System;

namespace Graphs
{
   public class Edge<T>
   {
      public Node<T> From { get; set; }
      public Node<T> To { get; set; }
      public int? Weight { get; set; }

      public override string ToString()
      {
         return $"Edge: {From} --{(Weight.HasValue ? $"{Weight}" : String.Empty)}--> {To}";
      }
   }
}
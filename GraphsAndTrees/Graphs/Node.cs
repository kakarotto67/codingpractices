using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Graphs
{
   public class Node<T> : IEquatable<Node<T>>
   {
      private readonly List<Edge<T>> _edges = new List<Edge<T>>();

      public int Index { get; set; }
      public T Data { get; set; }
      public ReadOnlyCollection<Edge<T>> Edges => _edges.AsReadOnly();
      public ReadOnlyCollection<Node<T>> Neighbors => Edges.Select(x => x.To)
         .Distinct(new NodeEqualityComparer<T>()).ToList().AsReadOnly();

      public void AddNeighbor(Node<T> node, int? weight = null)
      {
         var edge = GetEdgeToNode(node, weight);
         _edges.Add(edge);
      }

      /// <summary>
      /// Removes all neighbor edges associated with given node.
      /// </summary>
      public void RemoveNeighbor(Node<T> node)
      {
         _edges.RemoveAll(x => x.To == node);
      }

      public bool Equals(Node<T> other)
      {
         return Index == other.Index && Data.Equals(other.Data);
      }

      public override string ToString()
      {
         return $"[{Data}]";
      }

      private Edge<T> GetEdgeToNode(Node<T> node, int? weight = null)
      {
         return new Edge<T>
         {
            From = this,
            To = node,
            Weight = weight
         };
      }
   }

   internal class NodeEqualityComparer<T> : IEqualityComparer<Node<T>>
   {
      public bool Equals(Node<T> x, Node<T> y)
      {
         return x.Index == y.Index && x.Data.Equals(y.Data);
      }

      public int GetHashCode(Node<T> obj)
      {
         return obj.Index.GetHashCode() + obj.Data.GetHashCode();
      }
   }
}
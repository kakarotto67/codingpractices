using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Graphs
{
   public class Graph<T>
   {
      private readonly bool _isDirected = false;
      private readonly bool _isWeighted = false;

      public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

      public Graph()
      {
         _isDirected = false;
         _isWeighted = false;
      }

      public Graph(bool isDirected, bool isWeighted)
      {
         _isDirected = isDirected;
         _isWeighted = isWeighted;
      }

      public Node<T> AddNode(T nodeData)
      {
         var node = new Node<T>
         {
            Index = GetIndexOfNewNode(),
            Data = nodeData
         };

         Nodes.Add(node);
         return node;
      }

      public void RemoveNode(Node<T> nodeToRemove)
      {
         if (!Nodes.Contains(nodeToRemove))
         {
            return;
         }

         // Remove node from graph
         Nodes.Remove(nodeToRemove);

         // Remove associated edges
         foreach (var node in Nodes)
         {
            node.RemoveNeighbor(nodeToRemove);
         }
      }

      public void AddEdge(Node<T> from, Node<T> to, int? weight = null)
      {
         if (!Nodes.Contains(from))
         {
            throw new ArgumentException("<from> node doesn't exist in the graph!");
         }

         if (!Nodes.Contains(to))
         {
            throw new ArgumentException("<to> node doesn't exist in the graph!");
         }

         if (_isWeighted && weight == null)
         {
            throw new ArgumentNullException("Weight cannot be null for weighted graph!");
         }

         if(!_isWeighted && weight != null)
         {
            throw new ArgumentNullException("Weight cannot be set for non-weighted graph!");
         }

         if(ContainsEdge(from, to))
         {
            throw new ArgumentNullException("Edge between <from> and <to> already exists!");
         }

         from.AddNeighbor(to, weight);

         if (!_isDirected)
         {
            to.AddNeighbor(from, weight);
         }
      }

      public void RemoveEdge(Node<T> from, Node<T> to)
      {
         from.RemoveNeighbor(to);

         if (!_isDirected)
         {
            to.RemoveNeighbor(from);
         }
      }

      public ReadOnlyCollection<Edge<T>> GetEdges()
      {
         var edges = new List<Edge<T>>();
         foreach (var node in Nodes)
         {
           edges = edges.Concat(node.Edges).ToList();
         }

         return edges.AsReadOnly();
      }

      public Node<T> DepthFirstSearch(T searchedNodeData)
      {
         return DepthFirstSearchRecursion(Nodes[0], new bool[Nodes.Count], searchedNodeData);
      }

      private Node<T> DepthFirstSearchRecursion(Node<T> node, bool[] visitedNodes, T searchedNodeData)
      {
         if (node.Data.Equals(searchedNodeData))
         {
            return node;
         }

         // Keep array of visited nodes to process each node only once
         visitedNodes[node.Index] = true;

         if (node.Neighbors != null && node.Neighbors.Any())
         {
            foreach (var neighborNode in node.Neighbors)
            {
               if (!visitedNodes[neighborNode.Index])
               {
                  return DepthFirstSearchRecursion(neighborNode, visitedNodes, searchedNodeData);
               }
            }
         }

         return null;
      }

      public Node<T> DepthFirstSearch(int searchedNodeIndex)
      {
         return DepthFirstSearchRecursion(Nodes[0], new bool[Nodes.Count], searchedNodeIndex);
      }

      private Node<T> DepthFirstSearchRecursion(Node<T> node, bool[] visitedNodes, int searchedNodeIndex)
      {
         if (node.Index == searchedNodeIndex)
         {
            return node;
         }

         // Keep array of visited nodes to process each node only once
         visitedNodes[node.Index] = true;

         if (node.Neighbors != null && node.Neighbors.Any())
         {
            foreach (var neighborNode in node.Neighbors)
            {
               if (!visitedNodes[neighborNode.Index])
               {
                  return DepthFirstSearchRecursion(neighborNode, visitedNodes, searchedNodeIndex);
               }
            }
         }

         return null;
      }

      public ReadOnlyCollection<Node<T>> DepthFirstTraversal()
      {
         var result = new List<Node<T>>();
         DepthFirstTraversalRecursion(Nodes[0], new bool[Nodes.Count], result);
         return result.AsReadOnly();
      }

      private void DepthFirstTraversalRecursion(Node<T> node, bool[] visitedNodes,
         List<Node<T>> result)
      {
         // Add found node to the result list
         // Start from the initially passed node
         result.Add(node);

         // Keep array of visited nodes to process each node only once
         visitedNodes[node.Index] = true;

         foreach(var neighborNode in node.Neighbors)
         {
            // If this node isn't visited yet - run DFS recursively for it
            // and then go deeper into its neighbors
            if (!visitedNodes[neighborNode.Index])
            {
               DepthFirstTraversalRecursion(neighborNode, visitedNodes, result);
            }
         }
      }

      public bool ContainsEdge(Node<T> from, Node<T> to)
      {
         var graphEdges = GetEdges();
         return graphEdges.Any(x => x.From == from && x.To == to);
      }

      /// <summary>
      /// Returns edge between specified nodes' indexes if exists, otherwise returns null.
      /// </summary>
      public Edge<T> this[int indexFrom, int indexTo]
      {
         get
         {
            var nodeFrom = Nodes[indexFrom];
            var nodeTo = Nodes[indexTo];

            var edgeBetweenRequestedNodes = nodeFrom.Edges.FirstOrDefault(x => x.To == nodeTo);
            return edgeBetweenRequestedNodes;
         }
      }

      private int GetIndexOfNewNode()
      {
         return Nodes.Count;
      }
   }
}
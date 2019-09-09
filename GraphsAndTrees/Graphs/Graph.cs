using Graphs.Helpers;
using Priority_Queue;
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

      public int NodesCount => Nodes.Count;

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
            if (ContainsEdge(to, from))
            {
               throw new ArgumentNullException("Edge between <from> and <to> already exists!");
            }

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

      /// <summary>
      /// Gets all edges in graph using DFS traversal.
      /// </summary>
      public ReadOnlyCollection<Edge<T>> GetEdges()
      {
         var edges = new List<Edge<T>>();
         foreach (var node in Nodes)
         {
           edges = edges.Concat(node.Edges).ToList();
         }

         return edges.AsReadOnly();
      }

      public List<Edge<T>> GetShortestPath(Node<T> source, Node<T> target)
      {
         // TODO: Another class have to be extracted
         if (!_isWeighted)
         {
            throw new NotSupportedException();
         }

         return GetShortestPathDijkstra(source, target);
      }

      private List<Edge<T>> GetShortestPathDijkstra(Node<T> source, Node<T> target)
      {
         if(source == null || target == null)
         {
            return null;
         }

         // previous array initialized with -1 for each node [-1, -1, -1, ...]
         var previous = new int[NodesCount];
         ArrayHelpers.Fill(previous, -1);

         // distances array intialized with max for each node [max, max, max, ...]
         var distances = new int[NodesCount];
         ArrayHelpers.Fill(distances, int.MaxValue);

         // Set distances for source's index to 0 since its the beginning of the path
         distances[source.Index] = 0;

         // Create priority queue of all graph nodes
         // with priority for each node being initialized with respective value
         // from distances array (max value initially)
         // node - max, node - max, ..., source node - 0, ..., node - max, ...
         var nodesQueue = new SimplePriorityQueue<Node<T>>();
         for (var i = 0; i < NodesCount; i++)
         {
            nodesQueue.Enqueue(Nodes[i], distances[i]);
         }

         // Dequeue nodes from the queue until queue is empty
         while(nodesQueue.Count != 0)
         {
            // Since it is a priority queue, nodes is dequeued from highest priority first
            // Highest priority - is the lowest value in the priority queue
            // Since we set source's node priority to 0 - it will be dequeued first
            var dequeuedNode = nodesQueue.Dequeue();

            if(dequeuedNode.Neighbors == null)
            {
               continue;
            }

            // Check all neighbors of current node
            for (var i = 0; i < dequeuedNode.Neighbors.Count; i++)
            {
               // Get current neighbor
               var neighbor = dequeuedNode.Neighbors[i];

               // Get edge to current neighbor
               var edgeToNeighbor = dequeuedNode.GetEdgeToNeighbor(neighbor);

               // Get weight to current neightbor
               var weightToNeighbor = edgeToNeighbor?.Weight ?? 0;

               // Get total weight - value from distances array + weight to neighbor node
               // Will be max + weight to neihbor for non source node
               // Will be 0 + weight to neighbor for source node
               var weightTotal = distances[dequeuedNode.Index] + weightToNeighbor;

               // If distance to current neighbor is greater than weight total, then:
               // - set it to weight total
               // - update previous array's element to current dequeued node's index
               // - update priority of current neighbor to be weight total
               if (distances[neighbor.Index] > weightTotal)
               {
                  // Distance will be set to the actual distance to the neighbor node from the source node
                  distances[neighbor.Index] = weightTotal;

                  // Index of dequeued node is set into previous array, so later the shortest path can be calculated
                  previous[neighbor.Index] = dequeuedNode.Index;

                  // Priority will be updated to the actual distance to the neighbor node from the source node
                  nodesQueue.UpdatePriority(neighbor, distances[neighbor.Index]);
               }
            }
         }

         // Form list of indices
         var indices = new List<Int32>();

         // Initialize first index to target's index
         var index = target.Index;

         while (index >= 0)
         {
            // Add index into list
            // Initially, target's index will be added
            indices.Add(index);

            // Update index to value from previous array
            index = previous[index];
         }

         // Reverse the list to go from source to target at the end
         indices.Reverse();

         // Form the result list using indicies
         var result = new List<Edge<T>>();

         for (int i = 0; i < indices.Count - 1; i++)
         {
            // Get edge using indexes
            var indexFrom = indices[i];
            var indexTo = indices[i + 1];
            var edge = this[indexFrom, indexTo];

            // Add edge into result list
            result.Add(edge);
         }

         return result;
      }

      public Node<T> DepthFirstSearch(T searchedNodeData)
      {
         var result = new List<Node<T>>();
         DFSImplementation(Nodes[0], new bool[Nodes.Count], result,
            (nextNode) =>
            {
               if (nextNode.Data.Equals(searchedNodeData))
               {
                  result.Add(nextNode);
                  // To stop when searched node is found
                  return true;
               }

               // Move to next node
               return false;
            });

         return result?.FirstOrDefault();
      }

      public Node<T> DepthFirstSearch(int searchedNodeIndex)
      {
         var result = new List<Node<T>>();
         DFSImplementation(Nodes[0], new bool[Nodes.Count], result,
            (nextNode) =>
            {
               if (nextNode.Index == searchedNodeIndex)
               {
                  result.Add(nextNode);
                  // To stop when searched node is found
                  return true;
               }

               // Move to next node
               return false;
            });

         return result?.FirstOrDefault();
      }

      public ReadOnlyCollection<Node<T>> DepthFirstTraversal()
      {
         var result = new List<Node<T>>();
         DFSImplementation(Nodes[0], new bool[Nodes.Count], result,
            (nextNode) =>
            {
               result.Add(nextNode);

               // Move to next node
               return false;
            });
         return result?.AsReadOnly();
      }

      /// <summary>
      /// DFS algorithm in single place.
      /// </summary>
      /// <param name="node">The node to start from.</param>
      /// <param name="visitedNodes">List of visited nodes.</param>
      /// <param name="result">List with traversed nodes.</param>
      /// <param name="func">Usually, this func supposed to add next node into a list.
      /// It should return false to move to next node. Usually, true is returned if we search for particular node
      /// and there is no reason to move on.</param>
      /// <returns>Returnst list of all found nodes in the graph or stops when needed node is found.</returns>
      private void DFSImplementation(Node<T> node, bool[] visitedNodes, List<Node<T>> result,
         Func<Node<T>, bool> func)
      {
         if (node == null || visitedNodes == null || func == null)
         {
            return;
         }

         if (func(node))
         {
            return;
         }

         // Keep array of visited nodes to process each node only once
         visitedNodes[node.Index] = true;

         if (node.Neighbors != null && node.Neighbors.Any())
         {
            foreach (var neighborNode in node.Neighbors)
            {
               if (!visitedNodes[neighborNode.Index])
               {
                  DFSImplementation(neighborNode, visitedNodes, result, func);
               }
            }
         }
      }

      public Node<T> BreadthFirstSearch(T searchedNodeData)
      {
         return BFSImplementation(Nodes[0],
            (result, nextNode) =>
            {
               if (nextNode.Data.Equals(searchedNodeData))
               {
                  result.Add(nextNode);
                  // To stop when searched node is found
                  return true;
               }

               // Move to next node
               result = null;
               return false;
            }).FirstOrDefault();
      }

      public Node<T> BreadthFirstSearch(int searchedNodeIndex)
      {
         return BFSImplementation(Nodes[0],
            (result, nextNode) =>
            {
               if (nextNode.Index == searchedNodeIndex)
               {
                  result.Add(nextNode);
                  // To stop when searched node is found
                  return true;
               }

               // Move to next node
               result = null;
               return false;
            }).FirstOrDefault();
      }

      public ReadOnlyCollection<Node<T>> BreadthFirstTraversal()
      {
         return BFSImplementation(Nodes[0],
            (result, nextNode) =>
            {
               result.Add(nextNode);

               // Move to next node
               return false;
            })
            .AsReadOnly();
      }

      /// <summary>
      /// BFS algorithm in single place.
      /// </summary>
      /// <param name="node">The node to start from.</param>
      /// <param name="func">Usually, this func supposed to add next node into a list.
      /// It should return false to move to next node. Usually, true is returned if we search for particular node
      /// and there is no reason to move on.</param>
      /// <returns>Returnst list of all found nodes in the graph or stops when needed node is found.</returns>
      private List<Node<T>> BFSImplementation(Node<T> node, Func<List<Node<T>>, Node<T>, bool> func)
      {
         if(node == null || func == null)
         {
            return null;
         }

         // Track visited nodes
         var isVisited = new bool[Nodes.Count];
         isVisited[node.Index] = true;

         var result = new List<Node<T>>();
         var queue = new Queue<Node<T>>();

         // Add node to the end of queue
         queue.Enqueue(node);

         while (queue.Count > 0)
         {
            // Get node from queue and push into result
            var nextNode = queue.Dequeue();
            if (func(result, nextNode))
            {
               return result;
            }

            // Add those node's neighbors to the queue that weren't visited yet
            foreach (var neighbor in nextNode.Neighbors)
            {
               if (!isVisited[neighbor.Index])
               {
                  isVisited[neighbor.Index] = true;
                  queue.Enqueue(neighbor);
               }
            }
         }

         return result;
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
         return NodesCount;
      }
   }
}
using Graphs;
using System;

namespace GraphsDijkstraShortestPath
{
   public class Program
   {
      public static void Main()
      {
         var graph = new Graph<City>(false, true);

         //
         //                                                                       Kyiv
         //     Lviv
         //           IvanoFrankivsk
         //                                Ternopil
         //  Uzhgorod
         //                                           Odessa
         var lviv = graph.AddNode(City.Lviv);
         var ivanoFrankivsk = graph.AddNode(City.IvanoFrankivsk);
         var ternopil = graph.AddNode(City.Ternopil);
         var kyiv = graph.AddNode(City.Kyiv);
         var uzhgorod = graph.AddNode(City.Uzhgorod);
         var odessa = graph.AddNode(City.Odessa);

         graph.AddEdge(lviv, ivanoFrankivsk, 130);
         graph.AddEdge(ivanoFrankivsk, ternopil, 140);
         graph.AddEdge(lviv, ternopil, 120);
         graph.AddEdge(ternopil, kyiv, 420);
         graph.AddEdge(ternopil, odessa, 660);
         graph.AddEdge(ivanoFrankivsk, uzhgorod, 290);
         graph.AddEdge(lviv, uzhgorod, 260);

         // Throws exception since nodes don't exist in the graph
         //graph.AddEdge(new Node<City> { Data = City.None }, new Node<City> { Data = City.None }, 100);

         Console.WriteLine("Graph edges:");
         var edges = graph.GetEdges();
         foreach (var edge in edges)
         {
            Console.WriteLine(edge);
         }

         Console.WriteLine("\nGraph nodes (DFS):");
         var dfsTraversal = graph.DepthFirstTraversal();
         foreach (var graphNode in dfsTraversal)
         {
            Console.WriteLine(graphNode);
         }

         var dfsByData = graph.DepthFirstSearch(City.Ternopil);
         Console.WriteLine($"\nNode found by data (DFS): {dfsByData}");

         var dfsByIndex = graph.DepthFirstSearch(3);
         Console.WriteLine($"\nNode found by index (DFS): {dfsByIndex}");

         //foreach (var lvivNeighbor in lviv.Neighbors)
         //{
         //   Console.WriteLine(lvivNeighbor);
         //}

         Console.ReadKey();
      }
   }
}
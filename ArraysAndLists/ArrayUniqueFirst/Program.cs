using System;

namespace UniqueFirst
{
   class Program
   {
      static void Main()
      {
         // Input: 0 1 1 1 2 3 3 4 4 4 5
         // Output: 0 1 2 3 4 5 1 1 3 4 4
         // Current Output: 0 1 2 3 4 5 3 1 4 4 1 (order of duplicates is broken)

         var input = new[] { 0, 1, 1, 1, 2, 3, 3, 4, 4, 4, 5 };

         int indexOfCurrent = 0;
         int indexOfCurrentUnique = 0;
         var complexity = 0;
         while (indexOfCurrentUnique < input.Length)
         {
            // Increment until find index of next unique element in the array
            var indexOfNextUnique = indexOfCurrentUnique + 1;
            while (indexOfNextUnique < input.Length && input[indexOfNextUnique] == input[indexOfCurrentUnique])
            {
               indexOfNextUnique++;

               complexity++;
            }

            // Swap current position (identified by i)
            // by next different element (identified by j)
            if (indexOfCurrent != indexOfCurrentUnique)
            {
               int tmp = input[indexOfCurrent];
               input[indexOfCurrent] = input[indexOfCurrentUnique];
               input[indexOfCurrentUnique] = tmp;
               //Console.WriteLine("[{0}]", String.Join(", ", input));
            }

            // Set index of current unique to index of next unique
            // since it is going to be used in next iteration
            indexOfCurrentUnique = indexOfNextUnique;
            // Increment index of current for next iteration
            // to go through unique count
            indexOfCurrent++;

            complexity++;
         }

         Console.WriteLine("Unique first result:");
         Console.WriteLine("[{0}]", String.Join(", ", input));
         Console.WriteLine($"Array size: {input.Length}");

         var complexityString = complexity == input.Length ? "O(n)"
            : complexity == input.Length * input.Length ? "O(n2)" :
            $"{complexity} iterations";
         Console.WriteLine($"Complexity: {complexityString}");

         Console.ReadKey();
      }
   }
}

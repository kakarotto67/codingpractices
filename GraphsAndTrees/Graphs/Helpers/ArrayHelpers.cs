
namespace Graphs.Helpers
{
   internal static class ArrayHelpers
   {
      // Auxiliary method to fill the whole array with specified value
      internal static void Fill<Y>(Y[] array, Y value)
      {
         if (array == null || array.Length <= 0)
         {
            return;
         }

         for (int i = 0; i < array.Length; i++)
         {
            array[i] = value;
         }
      }
   }
}
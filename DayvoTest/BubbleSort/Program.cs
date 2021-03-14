using System;
using System.Globalization;
using System.Text.Json;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 0, 2, 5, -1, 4, 1, 10, 21, -99 };
            // Initialize the sorter and inject the translator with the desired language
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            var sorter = new BubbleSortCollectionSorter(translator);

            try
            {  
                // We use JSONSerializer to show the ouput
                var result = JsonSerializer.Serialize(sorter.SortDescending(numbers));

                Console.WriteLine(sorter.LastSortSwapCounter.ToString() + " swaps performed.");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has ocurred: " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

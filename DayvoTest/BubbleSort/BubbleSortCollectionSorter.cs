using System;
using System.Collections.Generic;

namespace BubbleSort
{
    /// <summary>
    /// Class that performs a sort operation using a Bubble Sort algorithm.
    /// </summary>
    public class BubbleSortCollectionSorter : ICollectionSorter
    {
        private INumberTranslator _numberTranslator;

        public BubbleSortCollectionSorter(INumberTranslator numberTranslate) {
            _numberTranslator = numberTranslate;
        }

        public int LastSortSwapCounter { get; private set; }

        /// <summary>
        /// Takes an array of integers and sorts it using the provided comparer function.
        /// </summary>
        /// <param name="numbers">Array to be sorted.</param>
        /// <param name="comparer">Comparer function.</param>
        private void Sort(int[] numbers, Func<int, int, bool> comparer) {            
            var arrayLength = numbers.Length;            
            int tempNumber;
            bool swapped;
            LastSortSwapCounter = 0;

            // Loop indefinitely until there's no more swapping
            while (true)
            {
                swapped = false;

                for (int i = 1; i <= arrayLength - 1; i++)
                {
                    // Use the comparer function for ordering evaluation
                    if (comparer(numbers[i - 1], numbers[i]))
                    {
                        // Save the number in a temp variable and swap the values
                        tempNumber = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = tempNumber;

                        // There was a swap
                        swapped = true;
                        LastSortSwapCounter++;

                        if (LastSortSwapCounter == ushort.MaxValue) {
                            throw new InvalidOperationException("Maximum number of swaps reached.");
                        }
                    }
                }

                // If there's no more swapping, break the loop
                if (!swapped)
                    break;
            }
        }

        /// <summary>
        /// Sorts an array in ascending order.
        /// </summary>
        /// <param name="numbers">Array to be sorted.</param>
        /// <returns>IEnumerable containing the word representation of the sorted array.</returns>
        public IEnumerable<string> SortAscending(int[] numbers)
        {
            Sort(numbers, (a, b) => a > b);
            return _numberTranslator.Translate(numbers);
        }

        /// <summary>
        /// Sorts an array in descending order.
        /// </summary>
        /// <param name="numbers">Array to be sorted.</param>
        /// <returns>IEnumerable containing the word representation of the sorted array.</returns>
        public IEnumerable<string> SortDescending(int[] numbers)
        {
            Sort(numbers, (a, b) => a < b);
            return _numberTranslator.Translate(numbers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort
{
    public interface ICollectionSorter
    {
        IEnumerable<string> SortAscending(int[] numbers);

        IEnumerable<string> SortDescending(int[] numbers);
    }
}

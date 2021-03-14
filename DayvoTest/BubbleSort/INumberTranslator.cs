using System.Collections.Generic;

namespace BubbleSort
{
    public interface INumberTranslator
    {
        IEnumerable<string> Translate(int[] numbers);
    }
}
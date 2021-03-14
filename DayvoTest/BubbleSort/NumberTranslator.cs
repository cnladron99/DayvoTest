using System;
using System.Collections.Generic;
using System.Globalization;

namespace BubbleSort
{
    /// <summary>
    /// Class to generate the word representation of a given array of numbers.
    /// </summary>
    public class NumberTranslator : INumberTranslator
    {
        private CultureInfo _culture;

        public NumberTranslator(CultureInfo culture) {
            _culture = culture;
        }

        public string TranslateNumber(int number)
        {
            // Get the describing word for the number
            var resultText = Language.ResourceManager.GetString(number.ToString(), _culture) ?? number.ToString();


            if (number % 2 == 0)
            {
                // If zero, alternate uppercase
                if (number == 0)
                {
                    resultText = resultText?.ToAlternatedUpper() ?? number.ToString();
                }
                else
                {
                    resultText = resultText ?? number.ToString();
                }
            }
            else
            {
                // If odd, uppercase
                resultText = resultText?.ToUpper() ?? number.ToString(); 
            }

            return resultText;
        }

        public IEnumerable<string> Translate(int[] numbers)
        {
            foreach (int number in numbers)
            {
                yield return TranslateNumber(number);
            }
        }
    }
}

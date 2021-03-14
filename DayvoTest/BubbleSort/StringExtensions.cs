using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BubbleSort
{
    public static class StringExtensions
    {
        /// <summary>
        /// Alternate capitalization on the given string.
        /// </summary>
        /// <param name="str">The string to be transformed.</param>
        /// <returns></returns>
        public static string ToAlternatedUpper(this String str)
        {
            Regex rx = new Regex(@"([a-zA-Z]){2}");

            return rx.Replace(str, new MatchEvaluator(m => char.ToUpper(m.ToString()[0]) + m.ToString().Substring(1, m.ToString().Length - 1)));
        }
    }
}

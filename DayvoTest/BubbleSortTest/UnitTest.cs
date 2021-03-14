using NUnit.Framework;
using BubbleSort;
using System.Globalization;
using System.Text.Json;

namespace BubbleSortTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAlternatedUpper()
        {
            Assert.AreEqual("zero".ToAlternatedUpper(), "ZeRo");
        }

        [Test]
        public void TestZeroTranslate()
        {
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(translator.TranslateNumber(0), "ZeRo");
        }

        [Test]
        public void TestEvenBetweenZeroAndNineTranslate()
        {
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(translator.TranslateNumber(2), "two");
        }

        [Test]
        public void TestOddBetweenZeroAndNineTranslate()
        {
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(translator.TranslateNumber(3), "THREE");
        }

        [Test]
        public void TestGreaterThanNineTranslate()
        {
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(translator.TranslateNumber(10), "10");
        }

        [Test]
        public void TestLessThanZeroTranslate()
        {
            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(translator.TranslateNumber(-2), "-2");
        }

        [Test]
        public void TestArrayTranslate()
        {
            int[] numbers = { 3, 0, 2, 5, -1, 4, 1, 10, 21, -99 };

            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            Assert.AreEqual(JsonSerializer.Serialize(translator.Translate(numbers)), @"[""THREE"",""ZeRo"",""two"",""FIVE"",""-1"",""four"",""ONE"",""10"",""21"",""-99""]");
        }

        [Test]
        public void TestSortAscending()
        {
            int[] numbers = { 3, 0, 2, 5, -1, 4, 1, 10, 21, -99 };

            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            var sorter = new BubbleSortCollectionSorter(translator);
            var result = JsonSerializer.Serialize(sorter.SortAscending(numbers));
            Assert.AreEqual(result, @"[""-99"",""-1"",""ZeRo"",""ONE"",""two"",""THREE"",""four"",""FIVE"",""10"",""21""]");
        }

        [Test]
        public void TestSortDescending()
        {
            int[] numbers = { 3, 0, 2, 5, -1, 4, 1, 10, 21, -99 };

            var translator = new NumberTranslator(CultureInfo.GetCultureInfo("en"));
            var sorter = new BubbleSortCollectionSorter(translator);
            var result = JsonSerializer.Serialize(sorter.SortDescending(numbers));
            Assert.AreEqual(result, @"[""21"",""10"",""FIVE"",""four"",""THREE"",""two"",""ONE"",""ZeRo"",""-1"",""-99""]");
        }
    }
}
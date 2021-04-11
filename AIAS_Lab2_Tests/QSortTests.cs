using System;
using System.Linq;
using AIAS_Lab2;
using NUnit.Framework;

namespace AIAS_Lab2_Tests
{
    public class QSortTests
    {
        [TestCase(new [] {0}, new []{0}, TestName = "OneItemArray")]
        [TestCase(new [] {0, 0, 0,0,0,0}, new []{0,0,0,0,0,0}, TestName = "AllArrayItemsAreTheSame")]
        [TestCase(new [] {0, 0, 2,2,1,1}, new []{0,0,1,1,2,2}, TestName = "SomeArrayItemsAreTheSame")]
        [TestCase(new [] {0, 1, 2,3,4,5}, new []{0,1,2,3,4,5}, TestName = "ArrayItemsInRightOrder")]
        [TestCase(new [] {5,4,3,2,1,0}, new []{0,1,2,3,4,5}, TestName = "ArrayItemsInReverseOrder")]
        [TestCase(new [] {1,3,4,0,5,2}, new []{0,1,2,3,4,5}, TestName = "ArrayItemsInRandomOrder")]
        public void QuickSortIntTest(int[] array, int[] expected)
        {
            var operationsCount = 0;
            Qsort.QuickSort(array, 0, array.Length - 1, ref operationsCount);
            Assert.That(array.SequenceEqual(expected));
        }
        
        [TestCase(new [] {"a"}, new []{"a"}, TestName = "OneItemArray")]
        [TestCase(new [] {"a", "a", "a", "a"}, new []{"a", "a", "a", "a"}, TestName = "AllArrayItemsAreTheSame")]
        [TestCase(new [] {"a", "a", "c", "c", "b"}, new []{"a", "a", "b","c","c"}, TestName = "SomeArrayItemsAreTheSame")]
        [TestCase(new [] {"a", "b", "c", "d", "e"}, new []{"a", "b", "c", "d", "e"}, TestName = "ArrayItemsInRightOrder")]
        [TestCase(new [] {"e", "d", "c", "b", "a"}, new []{"a", "b", "c", "d", "e"}, TestName = "ArrayItemsInReverseOrder")]
        [TestCase(new [] {"b", "a", "c", "e", "d"}, new []{"a", "b", "c", "d", "e"}, TestName = "ArrayItemsInRandomOrder")]
        public void QuickSortStringTest(string[] array, string[] expected)
        {
            var operationsCount = 0;
            Qsort.QuickSort(array, 0, array.Length - 1, ref operationsCount);
            Assert.That(array.SequenceEqual(expected));
        }
    }
}
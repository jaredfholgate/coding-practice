using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace coding_practice.unittests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void CanPerformQuickSort()
        {
            var array = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 }; 
            var arrayToSort = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            var sorter = new Sorter();
            sorter.QuickSort(arrayToSort);

            Assert.AreEqual(array.Length, arrayToSort.Length);

            var previousItem = array.Min() - 1;
            foreach(var item in arrayToSort)
            {
                Assert.IsTrue(array.Contains(item));
                Assert.IsTrue(previousItem < item);

                previousItem = item;
            }
        }
    }
}

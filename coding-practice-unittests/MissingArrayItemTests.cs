using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace coding_practice_unittests
{
    [TestClass]
    public class MissingArrayItemsTests
    {
        [TestMethod]
        public void CanFindTheValueOf2MissingArrayItems()
        {
            var start = 1;
            var end = 100000;
            var length = end - (start - 1);
            var array = new long[length];
           
            for(var i = 0; i < length; i++)
            {
                array[i] = i + start;
            }

            var random = new Random();            
            var first = random.Next(start, end);
            var second = random.Next(first, end);

            array = array.Where(o => o != first && o != second).ToArray();

            var max = array.Max();

            var finder = new Finder();
            var result = finder.FindMissing(array);

            Assert.AreEqual(first, result.first);
            Assert.AreEqual(second, result.second);

        }
    }
}

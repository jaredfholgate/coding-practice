using System;
using System.Linq;

namespace coding_practice
{
    public class Finder
    {
        public (long first, long second) FindMissing(long[] array)
        {
            long length = array.Length + 2;
            var totalArraySum = ((length) * (length + 1)) / 2;
            var sumOfArrayWithMissing = array.Sum();

            var totalMissing = totalArraySum - sumOfArrayWithMissing;
            var averageOfMissing = totalMissing / 2;

            var sumSmallerHalf = array.Where(o => o <= averageOfMissing).Sum();
            var sumGreaterHalf = array.Where(o => o > averageOfMissing).Sum();

            var totalSmallerHalf = (averageOfMissing * (averageOfMissing + 1)) /2;
            var totalGreaterHalf = totalArraySum - totalSmallerHalf;
            
            return (totalSmallerHalf - sumSmallerHalf, totalGreaterHalf - sumGreaterHalf);
        }

        private long SumArray(int[] array)
        {
            long sum = 0;
            foreach(var item in array)
            {
                sum += item;
            }
            return sum;
        }
    }
}
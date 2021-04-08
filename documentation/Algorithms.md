## Quick Sort

A recursive algorithm for sorting based on comparison. Can work with many data types.

O(n*log(n)): Because it uses a divide an conqor approach to split the array into small chunks either side of a pivot.

The pivot can the left, right, random or median.

The array can be sorted in place (mutated) or a new array can be created and returned.

E.g. 

```csharp

        public void Demo()
        {
            var array = new int[] { 90, 30, 40, 70, 80, 10, 50, 60, 20, 100, 20 };    
            QuickSort(arrayToSort);
        }

        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length -1);
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                var pivot = Partition(array, left, right);
                //Split the array either side of the correctly positioned partition and run the partitioning on each side recursively.
                QuickSort(array, left, pivot -1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            var pivot = array[right];

            var lastLessThanPivotIndex = left -1;

            for(int checkIndex = left; checkIndex < right; checkIndex++)
            {
                //If the item is less than the pivot, then move it to the left of the pivots final position.
                if(array[checkIndex] < pivot) 
                {
                    lastLessThanPivotIndex++;
                    Swap(array, lastLessThanPivotIndex, checkIndex);
                }
            }

            //Move the Pivot to the position where all items to the left are lower and all items to the right are higher.
            var pivotPosistion = lastLessThanPivotIndex + 1;
            Swap(array, pivotPosistion, right);

            return pivotPosistion;
        }

        private void Swap(int[] array, int item1, int item2)
        {
            var temp = array[item1];
            array[item1] = array[item2];
            array[item2] = temp;
        }
```

### Find Two Missing Items from a contiguous array

There are two methods to achieve;

1. Iterate the whole array looking for a missing item.
2. Calculate the average value of the missing items, then split the array on the average and calculate the value of the missing item.

Option 2 is faster for a large array, but it still requires iterating the array twice to sum up all the values.

e.g.

```csharp
        public void Demonstration()
        {
            var end = 100000;
            var array = Enumerable.Range(1, end).ToArray();
            var random = new Random();
            var first = random.Next(0, end);
            var second = random.Next(first + 1, end);

            array = array.Where(o => o != first && o != second).ToArray();

            var result = FindMissing(array);

            Assert.AreEqual(first, result.first);
            Assert.AreEqual(second, result.second);
         }

         public (long first, long second) FindMissing(int[] array)
         {

            var longArray = array.Select(o => (long)o).ToArray();
            var length = (long)(array.Length + 2);

            var expectedTotalSum = (length * (length + 1)) / 2;
            var actualTotalSum = longArray.Sum();

            var totalMissing = expectedTotalSum - actualTotalSum;
            var averageOfMissing = totalMissing / 2;

            var expectedFirstSum = (averageOfMissing * (averageOfMissing + 1)) / 2;
            var actualFirstSum = longArray.Where(o => o <= averageOfMissing).Sum();

            var expectedSecondSum = expectedTotalSum - expectedFirstSum;
            var actualSecondSum = actualTotalSum - actualFirstSum;

            return (expectedFirstSum - actualFirstSum, expectedSecondSum - actualSecondSum);
         }
```
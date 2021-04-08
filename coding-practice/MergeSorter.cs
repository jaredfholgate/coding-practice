namespace coding_practice
{
    public class MergeSorter
    {
        public void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                var middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            var leftArray = new int[(middle - left) + 1];
            var rightArray = new int[(right - (middle + 1)) + 1];

            var index = 0;
            for(var i = left; i <= middle; i++)
            {
                leftArray[index] = array[i];
                index++;
            }

            index = 0;
            for(var i = middle + 1; i <= right; i++)
            {
                rightArray[index] = array[i];
                index++;
            }

            var leftIndex = 0;
            var rightIndex = 0;

            for(int i = left; i <= right; i++)
            {
                if(leftIndex < leftArray.Length && rightIndex < rightArray.Length)
                {
                    if(leftArray[leftIndex] > rightArray[rightIndex])
                    {
                        array[i] = rightArray[rightIndex];
                        rightIndex++;
                    }
                    else
                    {
                        array[i] = leftArray[leftIndex];
                        leftIndex++;
                    }
                }
                else if(leftArray.Length <= leftIndex)
                {
                    array[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if(rightArray.Length <= rightIndex)
                {
                    array[i] = leftArray[leftIndex];
                    leftIndex++;
                }
            }
        }
    }
}
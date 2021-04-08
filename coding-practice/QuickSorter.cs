namespace coding_practice
{
    public class QuickSorter
    {
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }
        private int Partition(int[] array, int left, int right)
        {
            var pivot = array[right];
            var lastLessThanPivotItem = left -1;

            for(var currentItem = left; currentItem <= right -1; currentItem++)
            {
                if(array[currentItem] < pivot)
                {
                    lastLessThanPivotItem++;
                    Swap(array, lastLessThanPivotItem, currentItem);
                }
            }
            
            lastLessThanPivotItem++;
            Swap(array, lastLessThanPivotItem, right);
            return (lastLessThanPivotItem);
        }

        private void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
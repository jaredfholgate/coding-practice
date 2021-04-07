namespace coding_practice_unittests
{
    public class Sorter
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
            var checkItem = left -1;

            for(var compareItem = left; compareItem <= right; compareItem++)
            {
                if(array[compareItem] < pivot)
                {
                    checkItem++;
                    Swap(array, checkItem, compareItem);
                }
            }

            Swap(array, checkItem + 1, right);
            return (checkItem + 1);
        }

        private void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
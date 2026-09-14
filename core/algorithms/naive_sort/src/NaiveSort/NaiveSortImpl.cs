namespace NaiveSort;

public static class NaiveSortImpl
{
    // Selection sort: repeatedly finds the minimum element from the unsorted part and puts it at the beginning.
    // Input: an arr of integers.
    // Output: the sorted arr in ascending order.
    public static int[] SelectionSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return arr;
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        return arr;
    }

    // Bubble sort: repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.
    // Input: an arr of integers.
    // Output: the sorted arr in ascending order.
    public static int[] BubbleSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return arr;
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
        return arr;
    }

    // Insertion sort: builds the sorted arr one item at a time by repeatedly taking the next element and inserting it into the correct position.
    // Input: an arr of integers.
    // Output: the sorted arr in ascending order.
    public static int[] InsertionSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return arr;
        }

        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }

        return arr;
    }
}

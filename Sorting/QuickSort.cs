
/*

Sorted array: Quick sort
9 13 20 24 46 52

*/

// QuickSort

using System;
using System.Collections.Generic;

public class Solution
{
    public int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[low];
        int i = low;
        int j = high;
        
        while( i < j)
        {
            while(arr[i] <= pivot && i <= high - 1)
            {
                i++;
            }
             while(arr[j] > pivot && j >= low + 1)
            {
                j--;
            }
            if(i < j)
            {
                int temp1 = arr[i];
                arr[i] = arr[j];
                arr[j] = temp1;
            }
        }
        int temp2 = arr[low];
        arr[low] = arr[j];
        arr[j] = temp2;

        return j;
    }

    public void QuickSort(int[] inputArray, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(inputArray, low, high);
            QuickSort(inputArray, low, partitionIndex - 1);
            QuickSort(inputArray, partitionIndex + 1, high);
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 13, 46, 24, 52, 20, 9 };

        // Call MergeSort with correct bounds
        solution.QuickSort(inputArray, 0, inputArray.Length - 1);

        // Print sorted array
        Console.WriteLine("Sorted array: Quick sort");
        foreach (int num in inputArray)
        {
            Console.Write(num + " ");
        }
    }
}

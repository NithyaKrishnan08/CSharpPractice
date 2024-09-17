/*

Sorted array:
9 13 20 24 46 52

*/

// MergeSort

using System;
using System.Collections.Generic;

public class Solution
{
    public void Merge(int[] arr, int low, int mid, int high)
    {
        // Use a temporary list to store the merged result
        List<int> temp = new List<int>();

        int left = low;
        int right = mid + 1;

        // Merging two sorted halves
        while (left <= mid && right <= high)
        {
            if (arr[left] <= arr[right])
            {
                temp.Add(arr[left]);
                left++;
            }
            else
            {
                temp.Add(arr[right]);
                right++;
            }
        }

        // Adding remaining elements from the left half, if any
        while (left <= mid)
        {
            temp.Add(arr[left]);
            left++;
        }

        // Adding remaining elements from the right half, if any
        while (right <= high)
        {
            temp.Add(arr[right]);
            right++;
        }

        // Copy the sorted values back into the original array
        for (int i = low; i <= high; i++)
        {
            arr[i] = temp[i - low];
        }
    }

    public void MergeSort(int[] inputArray, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        int mid = (low + high) / 2;
        MergeSort(inputArray, low, mid);
        MergeSort(inputArray, mid + 1, high);
        Merge(inputArray, low, mid, high);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 13, 46, 24, 52, 20, 9 };

        // Call MergeSort with correct bounds
        solution.MergeSort(inputArray, 0, inputArray.Length - 1);

        // Print sorted array
        Console.WriteLine("Sorted array:");
        foreach (int num in inputArray)
        {
            Console.Write(num + " ");
        }
    }
}

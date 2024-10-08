/*

Brute force solution: 
Number of reverse pairs in the array: 3

Optimal solution: 
Number of reverse pairs in the array: 3

Problem Statement: Given an array of numbers, you need to return the count of reverse pairs. Reverse Pairs are those pairs where i<j and arr[i]>2*arr[j]

*/

// Count reverse pairs in an array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int ReversePairs1(int[] arr)
    {
        int n = arr.Length;
        int count = 0;
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if(arr[i] > 2 * arr[j])
                    count++;
            }
        }
        return count;
    }
    
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

    public int MergeSort(int[] inputArray, int low, int high)
    {
        int count = 0;
        if (low >= high)
        {
            return count;
        }

        int mid = (low + high) / 2;
        count += MergeSort(inputArray, low, mid);
        count += MergeSort(inputArray, mid + 1, high);
        count += ReversePairs2(inputArray, low, mid, high);
        Merge(inputArray, low, mid, high);
        return count;
    }
    
    // Optimal solution using Merge Sort algorithm
    public int ReversePairs2(int[] arr, int low, int mid, int high)
    {
        int right = mid + 1;
        int count = 0;
        for(int i = low; i <= mid; i++)
        {
            while(right <= high && arr[i] > 2 * arr[right])
                right++;
            count += (right - (mid + 1));
        }
        return count;
    }
    
    public int CountReversePairs(int[] arr, int n)
    {
        return MergeSort(arr, 0, n-1);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr1 = {4, 1, 2, 3, 1};
        int result1 = solution.ReversePairs1(arr1);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"Number of reverse pairs in the array: {result1}");
        Console.WriteLine();
        
        int[] arr2 = {4, 1, 2, 3, 1};
        int result2 = solution.CountReversePairs(arr2, arr2.Length);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"Number of reverse pairs in the array: {result2}");
        Console.WriteLine();
    }
}

/*

Brute force solution: 
Numebr of inversions in the array: 10

Optimal force solution: 
Numebr of inversions in the array: 10

Problem Statement: Given an array of N integers, count the inversion of the array (using merge-sort).

*/

// Count inversions in an array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int NumberOfInversions1(int[] arr)
    {
        int n = arr.Length;
        int count = 0;
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if(arr[i] > arr[j])
                    count++;
            }
        }
        return count;
    }
    
    public int Merge(int[] arr, int low, int mid, int high)
    {
        // Use a temporary list to store the merged result
        List<int> temp = new List<int>();

        int left = low;
        int right = mid + 1;

        int count = 0;
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
                count += (mid - left + 1);
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
        
        return count;
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
        count += Merge(inputArray, low, mid, high);
        return count;
    }
    
    // Optimal solution using Merge Sort algorithm
    public int NumberOfInversions2(int[] arr)
    {
        int n = arr.Length;
        int count = MergeSort(arr, 0, n-1);
        return count;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr1 = {5, 4, 3, 2, 1};
        int result1 = solution.NumberOfInversions1(arr1);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"Number of inversions in the array: {result1}");
        Console.WriteLine();
        
        int[] arr2 = {5, 4, 3, 2, 1};
        int result2 = solution.NumberOfInversions2(arr2);
        Console.WriteLine("Optimal force solution: ");
        Console.WriteLine($"Number of inversions in the array: {result2}");
        Console.WriteLine();
        
    }
}

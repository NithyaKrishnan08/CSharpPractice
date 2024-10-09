/*

1 occurs in the array at position: 3

Problem Statement: Given an integer array arr of size N, sorted in ascending order (with distinct values) and a target value k. Now the array is rotated at some pivot point unknown to you. Find the index at which k is present and if k is not present return -1.

*/

// Search Element in a Rotated Sorted Array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int SearchRotatedArray(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == x)
            {
                return mid;
            }
            
            // To check if the left array is sorted
            if(arr[low] <= arr[mid])
            {
                if(arr[low] <= x && x <= arr[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            // To check if the right array is sorted
            else
            {
                if(arr[mid] <= x && x <= arr[high])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {7, 8, 9, 1, 2, 3, 4, 5, 6};
        int x = 1;
        
        int result = solution.SearchRotatedArray(arr, x);
        if(result == -1)
            Console.WriteLine($"No {x} exists in the array.");
        else
            Console.WriteLine($"{x} occurs in the array at position: {result}");
    }
}

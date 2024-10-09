/*

1 occurs in the array at position: 3

Problem Statement: Given an integer array arr of size N, sorted in ascending order (may contain duplicate values) and a target value k. Now the array is rotated at some pivot point unknown to you. Return True if k is present and otherwise, return False. 

*/

// Search Element in a Rotated Sorted Array with duplicates

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public bool SearchRotatedArrayWithDuplicates(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == x)
            {
                return true;
            }
            
            if(arr[low] == arr[mid] && arr[mid] == arr[high])
            {
                low = low + 1;
                high = high - 1;
                continue;
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
        return false;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {7, 8, 1, 2, 3, 3, 3, 4, 5, 6};
        int x = 3;
        
        bool result = solution.SearchRotatedArrayWithDuplicates(arr, x);
        if(!result)
            Console.WriteLine($"No {x} exists in the array.");
        else
            Console.WriteLine($"{x} exists in the array.");
    }
}

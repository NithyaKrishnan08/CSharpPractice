/*

The minimum element in the array: 0

Problem Statement: Given an integer array arr of size N, sorted in ascending order (with distinct values). Now the array is rotated between 1 to N times which is unknown. Find how many times the array has been rotated.  

*/

// Find out how many times the array has been rotated

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int FindkRotation(int[] arr)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = Int32.MaxValue;
        int index = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[low] <= arr[high])
            {
                answer = Math.Min(answer, arr[low]);
                index = low;
                break;
            }
            
            // If the left array is sorted
            if(arr[low] <= arr[mid])
            {
                answer = Math.Min(answer, arr[low]);
                index = low;
                low = mid + 1;
            }
            // If the right array is sorted
            else
            {
                answer = Math.Min(answer, arr[mid]);
                index = mid;
                high = mid - 1;
            }
        }
        return index;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {4, 5, 6, 7, 0, 1, 2, 3};
        
        int result = solution.FindkRotation(arr);
        Console.WriteLine($"The array is rotated {result} times");
    }
}

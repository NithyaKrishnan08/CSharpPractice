/*

The ceil of 5 in the array: 7
The floor of 5 in the array: 4

Problem Statement: You're given an sorted array arr of n integers and an integer x. Find the floor and ceiling of x in arr[0..n-1].
The floor of x is the largest element in the array which is smaller than or equal to x.
The ceiling of x is the smallest element in the array greater than or equal to x.

--Ceil -> Figure out the lower bound in the sorted array and return the index

*/

// Search Insert Position

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Ceil - finding the lower bound
    public int FindCeil(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] >= x)
            {
                answer = arr[mid];
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return answer;
    }
    
    // Floor 
    public int FindFloor(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] <= x)
            {
                answer = arr[mid];
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {3, 4, 4, 7, 8, 10};
        int x = 5;
        
        int result1 = solution.FindCeil(arr, x);
        if(result1 == -1)
            Console.WriteLine($"No ceil exists for {x} in the array.");
        else
            Console.WriteLine($"The ceil of {x} in the array: {result1}");
        
        int result2 = solution.FindFloor(arr, x);
        if(result2 == -1)
            Console.WriteLine($"No floor exists for {x} in the array.");
        else
            Console.WriteLine($"The floor of {x} in the array: {result2}");
    }
}

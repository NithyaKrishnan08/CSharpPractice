/*

Brute force solution: 
The search insert position in the array: 3
Optimal solution: 
The search insert position in the array: 3

Problem Statement: You are given a sorted array arr of distinct values and a target value x. You need to search for the index of the target value in the array.

If the value is present in the array, then return its index. Otherwise, determine the index where it would be inserted in the array while maintaining the sorted order.

--Figure out the lower bound in the sorted array and return the index

*/

// Search Insert Position

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int SearchInsertPosition1(int[] arr, int x)
    {
        int n = arr.Length;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] > x)
            {
                return i;
            }
        }
        return n;
    }
    
    // Optimal solution
    public int SearchInsertPosition2(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = n;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] >= x)
            {
                answer = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
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
        
        int[] arr = {1, 2, 4, 7};
        int x = 6;
        
        int result1 = solution.SearchInsertPosition1(arr, x);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"The search insert position in the array: {result1}");
        
        int result2 = solution.SearchInsertPosition2(arr, x);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The search insert position in the array: {result2}");
    }
}

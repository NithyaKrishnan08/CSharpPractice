/*

The Length of the longest subarray with zero Sum: 5

Problem Statement: Given an array containing both positive and negative integers, we have to find the length of the longest subarray with the sum of all elements equal to zero.

*/

// Length of the longest subarray with zero Sum

using System;
using System.Collections.Generic;

public class Solution
{
    public int maximumLength(int[] arr)
    {
        int n = arr.Length;
        
        Dictionary<int, int> preSumMap = new Dictionary<int, int>();
        int sum = 0;
        int maximum = 0;
        
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
            
            if(sum == 0)
            {
                maximum = i + 1;
            }
            else
            {
                if (preSumMap.ContainsKey(sum))
                {
                    maximum = Math.Max(maximum, i - preSumMap[sum]);
                }
                else
                {
                    preSumMap[sum] = i; 
                }
            }
        }

        return maximum;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] arr = new int[] { 9, -3, 3, -1, 6, -5 };
        
        int result = solution.maximumLength(arr);
        
        Console.WriteLine($"The Length of the longest subarray with zero Sum: {result}");
    }
}

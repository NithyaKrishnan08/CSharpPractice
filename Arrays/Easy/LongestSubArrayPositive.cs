/*

The length of the longest subarray is: 3

*/

// Longest Subarray with sum K (positives)

using System;
using System.Collections.Generic;

public class Solution
{
    public int getLongestSubArray(int[] arr, int k)
    {
        int n = arr.Length;
        
        int left = 0, right = 0;
        long sum = arr[0];
        int maxLen = 0;
        
        while(right < n)
        {
            while(left <= right && sum > k)
            {
                sum += arr[left];
                left++;
            }
            if(sum == k)
            {
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            right++;
            if(right < n)
            {
                sum += arr[right];
            }
        }

        return maxLen;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int k = 10;
        int[] arr = new int[] { 2, 3, 5, 1, 9 };
        
        int result = solution.getLongestSubArray(arr, k);
        
        Console.WriteLine($"The length of the longest subarray is: {result}");
    }
}

/*

The length of the longest subarray is: 3

*/

// Longest Subarray with sum K (positive & negatives)

using System;
using System.Collections.Generic;

public class Solution
{
    public int getLongestSubArray(int[] arr, int k)
    {
        int n = arr.Length;
        
        Dictionary<int, int> preSumMap = new Dictionary<int, int>();
        int sum = 0;
        int maxLen = 0;
        
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];

            // Check if sum itself equals k
            if (sum == k)
            {
                maxLen = Math.Max(maxLen, i + 1);
            }

            int remaining = sum - k;

            // If remaining sum was seen before, calculate the length of the subarray
            if (preSumMap.ContainsKey(remaining))
            {
                int len = i - preSumMap[remaining];
                maxLen = Math.Max(maxLen, len);
            }

            // Store the first occurrence of sum in the map
            if (!preSumMap.ContainsKey(sum))
            {
                preSumMap[sum] = i;
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
        int k = 1;
        int[] arr = new int[] { -1, 1, 1 };
        
        int result = solution.getLongestSubArray(arr, k);
        
        Console.WriteLine($"The length of the longest subarray is: {result}");
    }
}

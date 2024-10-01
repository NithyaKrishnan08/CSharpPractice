/*

The number of sub-arrays with sum 6: 2

*/

// Count Subarray sum Equals K

using System;
using System.Collections.Generic;

public class Solution
{
    public int CountSubArrayWithKSum(int[] arr, int k)
    {
        int n = arr.Length;
        
        Dictionary<int, int> preSumMap = new Dictionary<int, int>();
        int preSum = 0;
        int count = 0;
        
        preSumMap[0] = 1;
        
        for (int i = 0; i < n; i++)
        {
            preSum += arr[i];

            int remove = preSum - k;

            if (preSumMap.ContainsKey(remove))
            {
                count += preSumMap[remove];
            }

            if (preSumMap.ContainsKey(preSum))
            {
                preSumMap[preSum]++;
            }
            else
            {
                preSumMap[preSum] = 1;  
            }
        }

        return count;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int k = 6;
        int[] arr = new int[] { 3, 1, 2, 4 };
        
        int result = solution.CountSubArrayWithKSum(arr, k);
        
        Console.WriteLine($"The number of sub-arrays with sum {k}: {result}");
    }
}

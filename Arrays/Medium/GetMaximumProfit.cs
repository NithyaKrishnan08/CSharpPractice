/*

The maximum profit: 5

*/

// To find maximum profit in buying and selling of stocks given in n number of days

using System;
using System.Collections.Generic;

public class Solution
{
    public int GetMaximumProfit(int[] arr)
    {
        int n = arr.Length;
        int minimumPrice = arr[0];
        int maxProfit = 0;

        for(int i = 0; i < n; i++)
        {
            minimumPrice = Math.Min(minimumPrice, arr[i]);
            maxProfit = Math.Max(maxProfit, arr[i] - minimumPrice);
        }
        return maxProfit;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {7,1,5,3,6,4};
        
        long result = solution.GetMaximumProfit(arr);
        
        Console.WriteLine($"The maximum profit: {result}");
    }
}

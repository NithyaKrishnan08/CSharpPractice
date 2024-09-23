/*

The maximum number of consecutive ones: 3

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int maximumConsecutiveOnes(int[] arr, int n)
    {
        int count = 0, max = 0;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] == 1)
            {
                count++;
                max = Math.Max(max, count);
            }
            else
            {
                count = 0;
            }
        }
        return max;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] arr = new int[] { 1, 1, 0, 1, 1, 1, 0, 1, 1};
        int result = solution.maximumConsecutiveOnes(arr, arr.Length);
        
        Console.WriteLine($"The maximum number of consecutive ones: {result}");
    }
}


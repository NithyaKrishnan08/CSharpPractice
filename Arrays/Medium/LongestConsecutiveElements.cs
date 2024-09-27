/*

The longest consecutive elements in the array: 4

*/

// Longest consecutive elements in an array

using System;
using System.Collections.Generic;

public class Solution
{
    public int LongestConsecutiveElements(int[] arr)
    {
        int n = arr.Length;
        
        if(n == 0)
        {
            return 0;
        }

        int longest = 1;
        HashSet<int> uniqueSet = new HashSet<int>();
        
        for(int i = 0; i < n; i++)
        {
            uniqueSet.Add(arr[i]);
        }
        
        foreach(int number in uniqueSet)
        {
            if(!uniqueSet.Contains(number - 1))
            {
                int count = 1;
                int temp = number;
                while(uniqueSet.Contains(temp + 1))
                {
                    temp = temp + 1;
                    count = count + 1;
                }
                longest = Math.Max(longest, count);
            }
        }
        
        return longest;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {100, 200, 1, 2, 3, 4};
        
        int result = solution.LongestConsecutiveElements(arr);
        
        Console.WriteLine($"The longest consecutive elements in the array: {result}");
    }
}

/*

The number that appears only once: 2

*/

// To find the number that appears only once
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int numberAppearsOnce(int[] arr, int n)
    {
        int xor = 0;
        for(int i = 0; i < n; i++)
        {
            xor = xor ^ arr[i];
        }
        return xor;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] arr = new int[] { 1, 1, 2, 3, 3, 4, 4};
        int result = solution.numberAppearsOnce(arr, arr.Length);
        
        Console.WriteLine($"The number that appears only once: {result}");
    }
}


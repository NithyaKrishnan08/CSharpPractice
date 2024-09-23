/*

The missing number: 3
The missing number: 3

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    //Method 1 - Using of sum of n natural numbers
    public int missingNumber(int[] arr, int n)
    {
        int sum1 = (n * (n + 1)) / 2;
        int sum2 = 0;
        for(int i = 0; i < n - 1; i++)
        {
            sum2 += arr[i];
        }
        int missingNumber = sum1 - sum2;
        return missingNumber;
    }
    
    //Method 2 - Using XOR method
    public int missingMethodXOR(int[] arr, int n)
    {
        int xor1 = 0, xor2 = 0;
        
        for(int i = 0; i < n-1; i++)
        {
            xor2 = xor2 ^ arr[i];
            xor1 = xor1 ^ (i + 1);
        }
        xor1 = xor1 ^ n;
        
        return (xor1 ^ xor2);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int n = 5;
        int[] arr = new int[] { 1, 2, 4, 5};
        int result1 = solution.missingNumber(arr, n);
        int result2 = solution.missingMethodXOR(arr, n);
        
        Console.WriteLine($"The missing number: {result1}");
        Console.WriteLine($"The missing number: {result2}");
    }
}


/*

Brute force method
The maximum sum of subarray: 6

*/

// To find maximum subarray sum of a given array

using System;
using System.Collections.Generic;

public class Solution
{
    // Brute force method
    public int maxSubArraySum1(int[] arr)
    {
        int n = arr.Length;
        int maximum = Int32.MinValue;

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                int sum = 0;
                for(int k = i; k <= j; k++)
                {
                    sum += arr[k];
                }
                
                maximum = Math.Max(maximum, sum);
            }
        }
        return maximum;
    }
    
    // Better solution method
    public int maxSubArraySum2(int[] arr)
    {
        int n = arr.Length;
        int maximum = Int32.MinValue;

        for(int i = 0; i < n; i++)
        {
            int sum = 0;
            for(int j = i; j < n; j++)
            {
                sum += arr[j];
                maximum = Math.Max(maximum, sum);
            }
        }
        return maximum;
    }
    
    // Optimal solution using Kadane's Algorithm
    public long maxSubArraySum3(int[] arr)
    {
        int n = arr.Length;
        long maximum = Int64.MinValue;
        long sum = 0;

        for(int i = 0; i < n; i++)
        {
            sum += arr[i];
            if(sum > maximum)
            {
                maximum = sum;
            }
            if(sum < 0)
            {
                sum = 0;
            }
        }
        if(maximum < 0)
        {
            maximum = 0;
        }
        return maximum;
    }
    
    // Optimal solution using Kadane's Algorithm - by printing the subarray
    public long maxSubArraySumPrint(int[] arr)
    {
        int n = arr.Length;
        long maximum = Int64.MinValue;
        long sum = 0;
        
        int start = 0;
        int ansStart = -1;
        int ansEnd = -1;

        for(int i = 0; i < n; i++)
        {
            if(sum == 0)
            {
                start = i;
            }
        
            sum += arr[i];
            
            if(sum > maximum)
            {
                maximum = sum;
                ansStart = start;
                ansEnd = i;
            }
            
            if(sum < 0)
            {
                sum = 0;
            }
        }
        
        if(maximum < 0)
        {
            maximum = 0;
        }
        
        Console.WriteLine("The subarray is: ");
        for(int i = ansStart; i <= ansEnd; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
        
        return maximum;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {-2,1,-3,4,-1,2,1,-5,4};
        
        long result = solution.maxSubArraySumPrint(arr);
        
        Console.WriteLine($"The maximum sum of subarray: {result}");
    }
}

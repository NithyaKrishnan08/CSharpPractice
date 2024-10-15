/*

Brute Force solution: 
The answer: 60

Optimal solution: 
The answer: 60

Problem Statement: Given an integer array ‘A’ of size ‘N’ and an integer ‘K'. Split the array ‘A’ into ‘K’ non-empty subarrays such that the largest sum of any subarray is minimized. Your task is to return the minimized largest sum of the split.
A subarray is a contiguous part of the array.

*/
// Same as Allocaiton of pages for students
// Split Array - Largest Sum / Painters partition

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int CountPartitions(int[] arr, int maxSum)
    {
        int n = arr.Length;
        int partitions = 1;
        long subArraySum = 0;
        
        for(int i = 0; i < n; i++)
        {
            if(subArraySum + arr[i] <= maxSum)
            {
                subArraySum += arr[i];
            }
            else
            {
                partitions++;
                subArraySum = arr[i];
            }
        }
        return partitions;
    }
    
    // Brute Force solution
    public int LargestSubarraySumMinimized1(int[] arr, int k)
    {
        int n = arr.Length;
        
        if(k > n)
            return -1;
            
        int low = arr.Max();
        int high = arr.Sum();
        
        for(int maxSum = low; maxSum <= high; maxSum++)
        {
            if(CountPartitions(arr, maxSum) == k)
                return maxSum;
        }
        return low;
    }
    
    // Optimal solution
    public int LargestSubarraySumMinimized2(int[] arr, int k)
    {
        int n = arr.Length;
        
        if(k > n)
            return -1;
            
        int low = arr.Max();
        int high = arr.Sum();
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int partitions = CountPartitions(arr, mid);
            if(partitions > k)
                low = mid + 1;
            else
                high = mid - 1;
        }
        
        return low;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {10, 20, 30, 40};
        int k = 2;
        
        int result1 = solution.LargestSubarraySumMinimized1(arr, k);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"There is no result");
        else
            Console.WriteLine($"The answer: {result1}");
        Console.WriteLine();
        
        int result2 = solution.LargestSubarraySumMinimized2(arr, k);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"There is no result");
        else
            Console.WriteLine($"The answer: {result2}");
        Console.WriteLine();
    }
}

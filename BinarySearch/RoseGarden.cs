/*

Brute force solution: 
We can make bouquets on day 12

Optimal solution: 
We can make bouquets on day 12

Problem Statement: You are given 'N’ roses and you are also given an array 'arr'  where 'arr[i]'  denotes that the 'ith' rose will bloom on the 'arr[i]th' day.
You can only pick already bloomed roses that are adjacent to make a bouquet. You are also told that you require exactly 'k' adjacent bloomed roses to make a single bouquet.
Find the minimum number of days required to make at least ‘m' bouquets each containing 'k' roses. Return -1 if it is not possible.

*/

// Minimum days to make M bouquets

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public bool Possible(int[] arr, int day, int m, int k)
    {
        int n = arr.Length;
        int count = 0;
        int noOfBouq = 0;
        
        for(int i = 0; i < n; i++)
        {
            if(arr[i] <= day)
                count++;
            else
            {
                noOfBouq += (count / k);
                count = 0;
            }
        }
        
        noOfBouq += (count / k);
        
        if(noOfBouq >= m)
            return true;
        else
            return false;
    }
    
    public int[] MinMaxArray(int[] arr)
    {
        int n = arr.Length;
        int min = Int32.MaxValue, max = Int32.MinValue;
        
        for(int i = 0; i < n; i++)
        {
            min = Math.Min(arr[i], min);
            max = Math.Max(arr[i], max);
        }
        return new int[] {min, max};
    }
    
    // Brute force solution
    public int roseGarden1(int[] arr, int m, int k)
    {
        int n = arr.Length;
        long maxValue = m * k;
        
        if(maxValue > n)
            return -1;
            
        int[] range = MinMaxArray(arr);
        
        for(int i = range[0]; i <= range[1]; i++)
        {
            if(Possible(arr, i, m, k))
                return i;
        }
        return -1;
    }
    
    // Optimal solution
    public int roseGarden2(int[] arr, int m, int k)
    {
        int n = arr.Length;
        long maxValue = m * k;
        
        if(maxValue > n)
            return -1;
            
        int[] range = MinMaxArray(arr);
        int low = range[0], high = range[1];
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            if(Possible(arr, mid, m, k))
            {
                answer = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }
        
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {7, 7, 7, 7, 13, 11, 12, 7};
        int m = 2;
        int k = 3;
        
        int result1 = solution.roseGarden1(arr, m, k);
        Console.WriteLine("Brute force solution: ");
        if (result1 == -1)
            Console.WriteLine($"We cannot make {m} bouquets.");
        else
            Console.WriteLine($"We can make bouquets on day {result1}");
        Console.WriteLine();
        
        int result2 = solution.roseGarden2(arr, m, k);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"We cannot make {m} bouquets.");
        else
            Console.WriteLine($"We can make bouquets on day {result2}");
        Console.WriteLine();
    }
}

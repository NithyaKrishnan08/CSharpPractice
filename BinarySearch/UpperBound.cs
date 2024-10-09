/*

Brute force solution: 
The upper bound is the index: 4
Optimal solution: 
The upper bound is the index: 4

Problem Statement: Given a sorted array of N integers and an integer x, write a program to find the upper bound of x

*/

// Implement Upper Bound

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int UpperBound1(int[] arr, int x)
    {
        int n = arr.Length;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] > x)
            {
                return i;
            }
        }
        return n;
    }
    
    // Optimal solution
    public int UpperBound2(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = n;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] > x)
            {
                answer = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {3, 5, 8, 9, 15, 19};
        int x = 9;
        
        int result1 = solution.UpperBound1(arr, x);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"The upper bound is the index: {result1}");
        
        int result2 = solution.UpperBound2(arr, x);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The upper bound is the index: {result2}");
    }
}

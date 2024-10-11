/*

Optimal solution
The 3th root of 27: 3

Optimal solution
The 4th root of 69 does not exist.

Problem Statement: Given two numbers N and M, find the Nth root of M. The nth root of a number M is defined as a number X when raised to the power N equals M. If the 'nth root is not an integer, return -1.

*/

// Nth Root of a Number using Binary Search

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // return 1, if == m
    // return 0, if < m
    // return 2, if > m
    // Optimal solution
    int FuncBinarySearch(int mid, int n, int m)
    {
        long answer = 1;
        for(int i = 1; i <= n; i++)
        {
            answer = answer * mid;
            if(answer > m)
                return 2;
        }
        if(answer == m)
            return 1;
        return 0;
    }
    
    public int NthRoot(int n, int m)
    {
        int low = 1, high = m;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int midN = FuncBinarySearch(mid, n, m);
            
            if(midN == 1)
            {
                return mid;
            }
            else if (midN == 0)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int n = 4, m = 69;
        
        Console.WriteLine("Optimal solution");
        int result = solution.NthRoot(n, m);
        if(result != -1)
            Console.WriteLine($"The {n}th root of {m}: {result}");
        else
            Console.WriteLine($"The {n}th root of {m} does not exist.");
    }
}

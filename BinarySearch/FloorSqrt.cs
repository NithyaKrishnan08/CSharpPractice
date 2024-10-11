/*

Brute force solution
The floor sqrt of 28: 5
Optimal solution
The floor sqrt of 28: 5

Problem Statement: You are given a positive integer n. Your task is to find and return its square root. If ‘n’ is not a perfect square, then return the floor value of 'sqrt(n)'.

Note: The question explicitly states that if the given number, n, is not a perfect square, our objective is to find the maximum number, x, such that x squared is less than or equal to n (x*x <= n). In other words, we need to determine the floor value of the square root of n. 

*/

// Finding Sqrt of a number using Binary Search

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int FloorSqrt1(int n)
    {
        int answer = 1;
            
        for(long i = 1; i <= n; i++)
        {
            long value = i * i;
            if(value <= n)
                answer = (int)i;
            else
                break;
        }
        return answer;
    }
    
    // Optimal solution
    public int FloorSqrt2(int n)
    {
        int low = 1, high = n;
        int answer = 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            long value = mid * mid;
            
            if(value <= (long)n)
            {
                answer = mid;
                low = mid + 1;
            }
            else
                high = mid - 1;
        }
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int n = 28;
        
        Console.WriteLine("Brute force solution");
        int result1 = solution.FloorSqrt1(n);
        Console.WriteLine($"The floor sqrt of {n}: {result1}");
        
        Console.WriteLine("Optimal solution");
        int result2 = solution.FloorSqrt2(n);
        Console.WriteLine($"The floor sqrt of {n}: {result2}");
    }
}

/*

Brute force solution: 
Repeating number: 5
Missing number: 8

Better solution: 
Repeating number: 5
Missing number: 8

Optimal solution1: 
Repeating number: 5
Missing number: 8

Problem Statement: You are given a read-only array of N integers with values also in the range [1, N] both inclusive. Each integer appears exactly once except A which appears twice and B which is missing. The task is to find the repeating and missing numbers A and B where A repeats twice and B is missing.

*/

// Find the repeating and missing numbers

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int[] FindMissingRepeatingNumbers1(int[] arr)
    {
        int n = arr.Length;
        int repeating = -1, missing = -1;
        
        for(int i = 1; i <= n; i++)
        {
            int count = 0;
            for(int j = 0; j < n; j++)
            {
                if(arr[j] == i)
                    count++;
            }
            
            if(count == 2)
                repeating = i;
            else if(count == 0)
                missing = i;
                
            if(repeating != -1 && missing != -1)
                break;
        }
        return new int[] {repeating, missing};
    }
    
    // Better solution
    public int[] FindMissingRepeatingNumbers2(int[] arr)
    {
        int n = arr.Length;
        int[] hash = new int[n + 1];
        int repeating = -1, missing = -1;
        
        for(int i = 0; i < n; i++)
        {
            hash[arr[i]]++;
        }
        
        for(int i = 1; i <= n; i++)
        {
            if(hash[i] == 2)
                repeating = i;
            else if(hash[i] == 0)
                missing = i;
                
            if(repeating != -1 && missing != -1)
                break;
        }
        
        return new int[] {repeating, missing};
    }
    
    // Optimal solution 1
    public int[] FindMissingRepeatingNumbers3(int[] arr)
    {
        long n = arr.Length;
        long sumN = (n * (n + 1)) / 2;
        long sumNSquare = (n * ( n + 1) * (2 * n + 1)) / 6;
        long sum = 0, sumSquare = 0;
        
        for(int i = 0; i < n; i++)
        {
            sum += arr[i];
            sumSquare += (long)arr[i] * arr[i];
        }
        
        long value1 = sum - sumN; // x - y
        long value2 = sumSquare - sumNSquare; // x^2 - y^2
        long value3 = value2 / value1; // x + y
        long repeating = (value1 + value3) / 2;
        long missing = repeating - value1;
        
        return new int[] {(int)repeating, (int)missing};
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr1 = {3, 1, 2, 5, 4, 6, 7, 5};
        int[] result1 = solution.FindMissingRepeatingNumbers1(arr1);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"Repeating number: {result1[0]}");
        Console.WriteLine($"Missing number: {result1[1]}");
        Console.WriteLine();
        
        int[] arr2 = {3, 1, 2, 5, 4, 6, 7, 5};
        int[] result2 = solution.FindMissingRepeatingNumbers2(arr2);
        Console.WriteLine("Better solution: ");
        Console.WriteLine($"Repeating number: {result2[0]}");
        Console.WriteLine($"Missing number: {result2[1]}");
        Console.WriteLine();
        
        int[] arr3 = {3, 1, 2, 5, 4, 6, 7, 5};
        int[] result3 = solution.FindMissingRepeatingNumbers3(arr3);
        Console.WriteLine("Optimal solution1: ");
        Console.WriteLine($"Repeating number: {result3[0]}");
        Console.WriteLine($"Missing number: {result3[1]}");
        Console.WriteLine();
    }
}

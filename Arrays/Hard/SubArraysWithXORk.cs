/*

Brute force solution: 
The number of sub arrays with XOR k: 4

Better solution: 
The number of sub arrays with XOR k: 4

Optimal solution: 
The number of sub arrays with XOR k: 4

Problem Statement: Given an array of integers A and an integer B. Find the total number of subarrays having bitwise XOR of all elements equal to k.

*/

// Count the number of subarrays with given xor K

using System;
using System.Collections.Generic;

public class Solution
{
    public int SubArraysWithXORk1(int[] arr, int k)
    {
        int n = arr.Length;
        int count = 0;
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i; j < n; j++)
            {
                int xor = 0;
                for(int m = i; m <= j; m++)
                {
                    xor = xor ^ arr[m];
                }
                
                if(xor == k)
                    count++;
            }
        }
        
        return count;
    }
    
    public int SubArraysWithXORk2(int[] arr, int k)
    {
        int n = arr.Length;
        int count = 0;
        
        for(int i = 0; i < n; i++)
        {
            int xor = 0;
            for(int j = i; j < n; j++)
            {
                xor = xor ^ arr[j];
                
                if(xor == k)
                    count++;
            }
        }
        
        return count;
    }
    
    public int SubArraysWithXORk3(int[] arr, int k)
    {
        int n = arr.Length;
        int count = 0;
        int xr = 0;
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        mapping[xr] = 1;
        
        for(int i = 0; i < n; i++)
        {
            xr = xr ^ arr[i];
            int x = xr ^ k;
            if(mapping.ContainsKey(x))
            {
                count += mapping[x];
            }
            
            if(mapping.ContainsKey(xr))
            {
                mapping[xr]++;
            }
            else
            {
                mapping[xr] = 1;
            }
        }
        
        return count;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] arr = new int[] { 4, 2, 2, 6, 4 };
        int k = 6;
        
        int result1 = solution.SubArraysWithXORk1(arr, k);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"The number of sub arrays with XOR k: {result1}");
        Console.WriteLine();
        
        int result2 = solution.SubArraysWithXORk2(arr, k);
        Console.WriteLine("Better solution: ");
        Console.WriteLine($"The number of sub arrays with XOR k: {result2}");
        Console.WriteLine();
        
        int result3 = solution.SubArraysWithXORk3(arr, k);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The number of sub arrays with XOR k: {result3}");
        Console.WriteLine();
    }
}

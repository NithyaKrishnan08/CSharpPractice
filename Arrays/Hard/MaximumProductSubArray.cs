/*

Brute force solution: 
Maximum Product Subarray: 20

Better solution: 
Maximum Product Subarray: 20

Optimal solution: 
Maximum Product Subarray: 20

Problem Statement: Given an array that contains both negative and positive integers, find the maximum product subarray.

*/

// Maximum Product Subarray in an Array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int MaximumProductSubArray1(int[] arr)
    {
        int n = arr.Length;
        int maxProduct = Int32.MinValue;
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                int product = 1;
                for(int k = i; k <= j; k++)
                {
                    product *= arr[k];
                }
                maxProduct = Math.Max(product, maxProduct);
            }
        }
        
        return maxProduct;
    }
    
    // Better solution
    public int MaximumProductSubArray2(int[] arr)
    {
        int n = arr.Length;
        int maxProduct = arr[0];
        
        for(int i = 0; i < n; i++)
        {
            int product = arr[i];
            for(int j = i + 1; j < n; j++)
            {
                maxProduct = Math.Max(product, maxProduct);
                product *= arr[j];
            }
            maxProduct = Math.Max(product, maxProduct);
        }
        
        return maxProduct;
    }
    
    // Optimal solution
    public int MaximumProductSubArray3(int[] arr)
    {
        int n = arr.Length;
        int maxProduct = Int32.MinValue;
        int prefixProduct = 1, suffixProduct = 1;
        
        for(int i = 0; i < n; i++)
        {
            if (prefixProduct == 0)
                prefixProduct = 1;
            if (suffixProduct == 0)
                suffixProduct = 1;
                
            prefixProduct *= arr[i];
            suffixProduct *= arr[n - i - 1];
            maxProduct = Math.Max(Math.Max(prefixProduct, suffixProduct), maxProduct);
        }
        
        return maxProduct;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr1 = {1,2,-3,0,-4,-5};
        int result1 = solution.MaximumProductSubArray1(arr1);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"Maximum Product Subarray: {result1}");
        Console.WriteLine();
        
        int[] arr2 = {1,2,-3,0,-4,-5};
        int result2 = solution.MaximumProductSubArray2(arr2);
        Console.WriteLine("Better solution: ");
        Console.WriteLine($"Maximum Product Subarray: {result2}");
        Console.WriteLine();
        
        int[] arr3 = {1,2,-3,0,-4,-5};
        int result3 = solution.MaximumProductSubArray3(arr3);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"Maximum Product Subarray: {result3}");
        Console.WriteLine();
    }
}

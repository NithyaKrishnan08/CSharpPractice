/*

Iterative solution: 
21 is not present in the array

Iterative solution: 
21 is not present in the array

Iterative solution: 
Target is in index: 2

Iterative solution: 
Target is in index: 2

Problem statement: You are given a sorted array of integers and a target, your task is to search for the target in the given array. Assume the given array does not contain any duplicate numbers.

*/

// Binary search - Find a target element in a sorted array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Iterative solution
    public int FindIndexOfTarget1(int[] arr, int target)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
                return mid;
            else if (target > arr[mid])
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
    
    // Recursive solution
    public int BinarySearch(int[] arr, int low, int high, int target)
    {
        int n = arr.Length;
        if (low > high)
            return -1;
            
        int mid = (low + high) / 2;
        if (arr[mid] == target)
            return mid;
        else if (target > arr[mid])
            return BinarySearch(arr, mid + 1, high, target);
            
        return BinarySearch(arr, low, mid - 1, target);
    }
    
    public int FindIndexOfTarget2(int[] arr, int target)
    {
        return BinarySearch(arr, 0, arr.Length - 1, target);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {3, 4, 6, 7, 9, 12, 16, 17};
        int target = 6;
        
        int result1 = solution.FindIndexOfTarget1(arr, target);
        Console.WriteLine("Iterative solution: ");
        if (result1 == -1)
            Console.WriteLine($"{target} is not present in the array");
        else
            Console.WriteLine($"Target is in index: {result1}");
        Console.WriteLine();
        
        int result2 = solution.FindIndexOfTarget2(arr, target);
        Console.WriteLine("Iterative solution: ");
        if (result2 == -1)
            Console.WriteLine($"{target} is not present in the array");
        else
            Console.WriteLine($"Target is in index: {result2}");
        Console.WriteLine();
    }
}

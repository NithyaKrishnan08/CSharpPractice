/*

Brute Force solution: 
The missing number: 5

Brute Force solution: 
The missing number: 5

Problem Statement: You are given a strictly increasing array ‘vec’ and a positive integer 'k'. Find the 'kth' positive integer missing from 'vec'.

*/

// Kth Missing Positive Number

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute Force solution
    public int MissingK1(int[] arr, int k)
    {
        int n = arr.Length;
        
        for(int i = 0; i < n; i++)
        {
            if(arr[i] <= k)
                k++;
            else
                break;
        }
        return k;
    }
    
    // Optimal solution
    public int MissingK2(int[] arr, int k)
    {
        int n = arr.Length;
        
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int missing = arr[mid] - (mid + 1);
            if(missing < k)
                low = mid + 1;
            else
                high = mid - 1;
        }
        
        return k + low;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {4, 7, 9, 10};
        int k = 4;
        
        int result1 = solution.MissingK1(arr, k);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"There is no missing number");
        else
            Console.WriteLine($"The missing number: {result1}");
        Console.WriteLine();
        
        int result2 = solution.MissingK2(arr, k);
        Console.WriteLine("Brute Force solution: ");
        if (result2 == -1)
            Console.WriteLine($"There is no missing number");
        else
            Console.WriteLine($"The missing number: {result2}");
        Console.WriteLine();
    }
}

/*

Optimal solution: 
The 5th element of two sorted array: 6

Problem Statement: Given two sorted arrays of size m and n respectively, you are tasked with finding the element that would be at the kth position of the final sorted array.

*/
// K-th Element of two sorted arrays

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Optimal solution using binary search
    public int KthElementOfTwoSortedArrays(int[] a, int[] b, int k)
    {
        int m = a.Length;
        int n = b.Length;
        
        // Always apply binary search on the smaller array
        if (m > n)
            return KthElementOfTwoSortedArrays(b, a, k);
            
        int left = k;
        
        int low = Math.Max(0, k - n), high = Math.Min(k, m);
        
        while (low <= high)
        {
            int mid1 = (low + high) >> 1;
            int mid2 = left - mid1;
            
            int l1 = Int32.MinValue, l2 = Int32.MinValue;
            int r1 = Int32.MaxValue, r2 = Int32.MaxValue;
            
            if (mid1 < m) r1 = a[mid1];
            if (mid2 < n) r2 = b[mid2];
            if (mid1 - 1 >= 0) l1 = a[mid1 - 1];
            if (mid2 - 1 >= 0) l2 = b[mid2 - 1];
                
            if (l1 <= r2 && l2 <= r1)
            {
                return Math.Max(l1, l2);
            }
            else if (l1 > r2)
                high = mid1 - 1;
            else
                low = mid1 + 1;
        }
        
        return 0;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] a = {2, 3, 6, 7, 9};
        int[] b = {1, 4, 8, 10};
        int k = 5;
        
        int result = solution.KthElementOfTwoSortedArrays(a, b, k);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The {k}th element of two sorted array: {result}");
        Console.WriteLine();
    }
}

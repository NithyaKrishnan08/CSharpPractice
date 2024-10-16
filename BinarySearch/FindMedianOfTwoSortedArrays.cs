/*

Brute Force solution: 
The median of two sorted array: 6

Better solution: 
The median of two sorted array: 6

Optimal solution: 
The median of two sorted array: 6

Problem Statement: Given two sorted arrays arr1 and arr2 of size m and n respectively, return the median of the two sorted arrays. The median is defined as the middle value of a sorted list of numbers. In case the length of the list is even, the median is the average of the two middle elements.

*/
// Median of Two Sorted Arrays of different sizes

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute Force solution
    public double FindMedianOfTwoSortedArrays1(int[] a, int[] b)
    {
        int n1 = a.Length;
        int n2 = b.Length;
        int i = 0, j = 0;
        List<int> list = new List<int>();
        
        // Merge the two arrays into a single sorted array
        while (i < n1 && j < n2)
        {
            if (a[i] < b[j])
                list.Add(a[i++]);
            else
                list.Add(b[j++]);
        }
        
        while (i < n1)
            list.Add(a[i++]);
        
        while (j < n2)
            list.Add(b[j++]);
            
        int n = n1 + n2;
        int[] c = list.ToArray();

        // Return the median based on whether the total number of elements is odd or even
        if (n % 2 == 1)
            return (double)c[n / 2];
        else
            return (double)((double)c[n / 2] + (double)c[(n / 2) - 1]) / 2.0;  // Fix for even length arrays
    }
    
    // Better solution using two pointers to track indices
    public double FindMedianOfTwoSortedArrays2(int[] a, int[] b)
    {
        int n1 = a.Length;
        int n2 = b.Length;
        int n = n1 + n2;
        int index2 = n / 2;
        int index1 = index2 - 1;
        
        int i = 0, j = 0;
        int count = 0;
        int element1 = -1, element2 = -1;
        
        while (i < n1 && j < n2)
        {
            if (a[i] < b[j])
            {
                if (count == index1) element1 = a[i];
                if (count == index2) element2 = a[i];
                count++;
                i++;
            }
            else
            {
                if (count == index1) element1 = b[j];
                if (count == index2) element2 = b[j];
                count++;
                j++;
            }
        }
        
        // If remaining elements in array a
        while (i < n1)
        {
            if (count == index1) element1 = a[i];
            if (count == index2) element2 = a[i];
            count++;
            i++;
        }
        
        // If remaining elements in array b
        while (j < n2)
        {
            if (count == index1) element1 = b[j];
            if (count == index2) element2 = b[j];
            count++;
            j++;
        }
            
        // If odd number of elements, return the middle one
        if (n % 2 == 1)
            return (double)element2;
        else
            return ((double)element1 + (double)element2) / 2.0;
    }
    
    // Optimal solution using binary search
    public double FindMedianOfTwoSortedArrays3(int[] a, int[] b)
    {
        int n1 = a.Length;
        int n2 = b.Length;
        
        // Always apply binary search on the smaller array
        if (n1 > n2)
            return FindMedianOfTwoSortedArrays3(b, a);
            
        int n = n1 + n2;
        int left = (n + 1) / 2;  // Find the partition on the left half
        
        int low = 0, high = n1;
        
        while (low <= high)
        {
            int mid1 = (low + high) >> 1;
            int mid2 = left - mid1;
            
            int l1 = Int32.MinValue, l2 = Int32.MinValue;
            int r1 = Int32.MaxValue, r2 = Int32.MaxValue;
            
            if (mid1 < n1) r1 = a[mid1];
            if (mid2 < n2) r2 = b[mid2];
            if (mid1 - 1 >= 0) l1 = a[mid1 - 1];
            if (mid2 - 1 >= 0) l2 = b[mid2 - 1];  // Fixed from b[mid2 + 1] to b[mid2 - 1]
                
            if (l1 <= r2 && l2 <= r1)
            {
                // If total number of elements is odd
                if (n % 2 == 1)
                    return Math.Max(l1, l2);
                else
                    return ((double)(Math.Max(l1, l2) + Math.Min(r1, r2))) / 2.0;
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
        
        int[] a = {1, 4, 7, 10, 12};
        int[] b = {2, 3, 6, 15};
        
        double result1 = solution.FindMedianOfTwoSortedArrays1(a, b);
        Console.WriteLine("Brute Force solution: ");
        Console.WriteLine($"The median of two sorted array: {result1}");
        Console.WriteLine();
        
        double result2 = solution.FindMedianOfTwoSortedArrays2(a, b);
        Console.WriteLine("Better solution: ");
        Console.WriteLine($"The median of two sorted array: {result2}");
        Console.WriteLine();
        
        double result3 = solution.FindMedianOfTwoSortedArrays3(a, b);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The median of two sorted array: {result3}");
        Console.WriteLine();
    }
}

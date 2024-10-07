/*

Brute Force Solution
Merged Arrays are: 
arr1[] = [ 1 2 3 4 ]
arr2[] = [ 8 9 10 ]

Optimal Solution - 1
Merged Arrays are: 
arr1[] = [ 1 2 3 4 ]
arr2[] = [ 8 9 10 ]

Optimal Solution - 2 (Gap method)
Merged Arrays are: 
arr1[] = [ 1 2 3 4 ]
arr2[] = [ 8 9 10 ]

Problem statement: Given two sorted arrays arr1[] and arr2[] of sizes n and m in non-decreasing order. Merge them in sorted order. Modify arr1 so that it contains the first N elements and modify arr2 so that it contains the last M elements.

*/

// Merge two Sorted Arrays Without Extra Space

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public void MergeSortedArrays1(long[] arr1, long[] arr2)
    {
        int n = arr1.Length;
        int m = arr2.Length;
        
        // Declare a third array and two pointers
        long[] arr3 = new long[n + m];
        int left = 0, right = 0, index = 0;
        
        while(left < n && right < m)
        {
            if(arr1[left] < arr2[right])
            {
                arr3[index] = arr1[left];
                left++;
                index++;
            }
            else 
            {
                arr3[index] = arr2[right];
                right++;
                index++;
            }
        }
        
        // when arr2 is exhausted
        while(left < n)
        {
            arr3[index++] = arr1[left++];
        }
        
        // when arr1 is exhausted
        while(right < m)
        {
            arr3[index++] = arr2[right++];
        }
        
        for(int i = 0; i < n + m; i++)
        {
            if(i < n)
                arr1[i] = arr3[i];
            else
                arr2[i - n] = arr3[i];
        }
        
        
        Console.WriteLine("Brute Force Solution");
        // Print the merged arrays
        Console.WriteLine("Merged Arrays are: ");
        
        Console.Write("arr1[] = [ ");
        for(int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
        
        Console.Write("arr2[] = [ ");
        for(int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
    
    // Optimal solution - 1
    public void MergeSortedArrays2(long[] arr1, long[] arr2)
    {
        int n = arr1.Length;
        int m = arr2.Length;
        
        long[] arr3 = new long[n + m];
        int left = n -1, right = 0;
        
        while(left >= 0 && right < m)
        {
            if(arr1[left] > arr2[right])
            {
                long temp = arr1[left];
                arr1[left] = arr2[right];
                arr2[right] = temp;
                left--;
                right++;
            }
            else 
            {
                break;
            }
        }
        
        Array.Sort(arr1);
        Array.Sort(arr2);
        
        Console.WriteLine("Optimal Solution - 1");
        // Print the merged arrays
        Console.WriteLine("Merged Arrays are: ");
        
        Console.Write("arr1[] = [ ");
        for(int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
        
        Console.Write("arr2[] = [ ");
        for(int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
    
    // Optimal solution - 2 (Gap mathod using Shell Sort method)
    public void SwapIfGreater(long[] arr1, long[] arr2, int ind1, int ind2)
    {
        if(arr1[ind1] > arr2[ind2])
        {
            long temp = arr1[ind1];
            arr1[ind1] = arr2[ind2];
            arr2[ind2] = temp;
        }
    }
    
    public void MergeSortedArrays3(long[] arr1, long[] arr2)
    {
        int n = arr1.Length;
        int m = arr2.Length;
        int len = n + m;
        int gap = (len / 2) + (len % 2);
        
        while(gap > 0)
        {
            int left = 0;
            int right = left + gap;
            while(right < len)
            {
                // Case 1: left in arr1[] & right in arr2[]
                if(left < n && right >= n)
                    SwapIfGreater(arr1, arr2, left, right - n);
                // case 2: both pointers in arr2[]
                else if(left >= n)
                    SwapIfGreater(arr2, arr2, left - n, right - n);
                // case 3: both pointers in arr1[]
                else
                    SwapIfGreater(arr1, arr1, left, right);
                    
                left++;
                right++;
            }
            
            if(gap == 1)
            break;
        
            gap = (gap / 2) + (gap % 2);
        }
        
        Console.WriteLine("Optimal Solution - 2 (Gap method)");
        // Print the merged arrays
        Console.WriteLine("Merged Arrays are: ");
        
        Console.Write("arr1[] = [ ");
        for(int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
        
        Console.Write("arr2[] = [ ");
        for(int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        long[] arr1 = {1, 4, 8, 10};
        long[] arr2 = {2, 3, 9};
        solution.MergeSortedArrays1(arr1, arr2);
        Console.WriteLine();
        
        long[] arr3 = {1, 4, 8, 10};
        long[] arr4 = {2, 3, 9};
        solution.MergeSortedArrays2(arr3, arr4);
        Console.WriteLine();
        
        long[] arr5 = {1, 4, 8, 10};
        long[] arr6 = {2, 3, 9};
        solution.MergeSortedArrays3(arr5, arr6);
        Console.WriteLine();
    }
}

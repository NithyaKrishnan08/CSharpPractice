/*

Brute Force solution: 
The median of two sorted array: 6

Better solution: 
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
        int  i = 0, j = 0;
        List<int> list = new List<int>();
        
        while(i < n1 && j < n2)
        {
            if(a[i] < b[j])
                list.Add(a[i++]);
            else
                list.Add(b[j++]);
        }
        
        while(i < n1)
            list.Add(a[i++]);
        
        while(j < n2)
            list.Add(b[j++]);
            
        int n = n1 + n2;
        int[] c = list.ToArray();
        if(n % 2 == 1)
            return (double)c[n / 2];
        else
            return (double)((double)c[n / 2] + (double)c[(n / 2) + 1]);
    }
    
    // Better solution
    public double FindMedianOfTwoSortedArrays2(int[] a, int[] b)
    {
        int n1 = a.Length;
        int n2 = b.Length;
        int n = n1 + n2;
        int index2 = n / 2;
        int index1 = index2 - 1;
        
        int  i = 0, j = 0;
        int count = 0;
        int element1 = -1, element2 = -1;
        
        while(i < n1 && j < n2)
        {
            if(a[i] < b[j])
            {
                if(count == index1)
                    element1 = a[i];
                if(count == index2)
                    element2 = a[i];
                count++;
                i++;
            }
            else
            {
                if(count == index1)
                    element1 = b[j];
                if(count == index2)
                    element2 = b[j];
                count++;
                j++;
            }
        }
        
        while(i < n1)
        {
            if(count == index1)
                    element1 = a[i];
            if(count == index2)
                element2 = a[i];
            count++;
            i++;
        }
        
        while(j < n2)
        {
            if(count == index1)
                    element1 = b[j];
            if(count == index2)
                element2 = b[j];
            count++;
            j++;
        }
            
        if(n % 2 == 1)
            return (double)element2;
        else
            return (double)(((double)element1 + (double)element2) / 2.0);
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
    }
}

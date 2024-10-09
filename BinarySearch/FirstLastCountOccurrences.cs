/*

The first occurrence of 8 in the array: 3
The first occurrence of 8 in the array: 5
The count of occurrences of 8 in the array: 3

Given a sorted array of N integers, write a program to find the index of the last occurrence of the target key. If the target is not found then return -1.

Problem Statement: You are given a sorted array containing N integers and a number X, you have to find the occurrences of X in the given array.

*/

// First, Last and Count the number of occurences

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // First Occurrence
    public int FirstOccurrence(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int first = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == x)
            {
                first = mid;
                high = mid - 1;
            }
            else if (arr[mid] < x)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return first;
    }
    
    // Last Occurrence
    public int LastOccurrence(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int last = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == x)
            {
                last = mid;
                low = mid + 1;
            }
            else if (arr[mid] < x)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return last;
    }
    
    public int[] FirstAndLastOccurrence(int[] arr, int x)
    {
        int first = FirstOccurrence(arr, x);
        if(first == -1)
            return new int[] {-1, -1};
        int last = LastOccurrence(arr, x);
        
        return new int[] {first, last};
    }
    
    public int CountOccurrences(int[] arr, int x)
    {
        int[] result = FirstAndLastOccurrence(arr, x);
        if(result[0] == -1)
            return 0;
        return (result[1] - result[0] + 1);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {2, 4, 6, 8, 8, 8, 11, 13};
        int x = 8;
        
        int first = solution.FirstOccurrence(arr, x);
        if(first == -1)
            Console.WriteLine($"No {x} exists in the array.");
        else
            Console.WriteLine($"The first occurrence of {x} in the array: {first}");
        
        int last = solution.LastOccurrence(arr, x);
        if(last == -1)
            Console.WriteLine($"No {x} exists in the array.");
        else
            Console.WriteLine($"The first occurrence of {x} in the array: {last}");
            
        int count = solution.CountOccurrences(arr, x);
        Console.WriteLine($"The count of occurrences of {x} in the array: {count}");
    }
}

/*

Brute force solution
The peak element is at index: 7
Optimal solution
The peak element is at index: 7

Problem Statement: Given an array of length N. Peak element is defined as the element greater than both of its neighbors. Formally, if 'arr[i]' is the peak element, 'arr[i - 1]' < 'arr[i]' and 'arr[i + 1]' < 'arr[i]'. Find the index(0-based) of a peak element in the array. If there are multiple peak numbers, return the index of any peak number.

Note: For the first element, the previous element should be considered as negative infinity as well as for the last element, the next element should be considered as negative infinity. 

*/

// Peak element in Array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int FindPeakElement1(int[] arr)
    {
        int n = arr.Length;
            
        for(int i = 0; i < n; i++)
        {
            if((i == 0 || arr[i-1] < arr[i]) && (i == n-1 || arr[i] > arr[i+1]))
                return i;
        }
        return -1;
    }
    
    public int FindPeakElement2(int[] arr)
    {
        int n = arr.Length;
        if(n == 0)
            return -1;
            
        if(n == 1)
            return 0;
            
        if(arr[0] > arr[1])
            return 0;
            
        if(arr[n-1] > arr[n-2])
            return n-1;
            
        int low = 1, high = n - 2;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            // If arr[mid] is the peak element
            if((arr[mid - 1] < arr[mid]) && (arr[mid] > arr[mid + 1]))
                return mid;
                
            // We are in left array 
            if(arr[mid] > arr[mid - 1])
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 5, 1};
        
        Console.WriteLine("Brute force solution");
        int result1 = solution.FindPeakElement1(arr);
        if(result1 == -1)
            Console.WriteLine("There is no peak element in the array");
        else
            Console.WriteLine($"The peak element is at index: {result1}");
            
        Console.WriteLine("Optimal solution");
        int result2 = solution.FindPeakElement2(arr);
        if(result2 == -1)
            Console.WriteLine("There is no peak element in the array");
        else
            Console.WriteLine($"The peak element is at index: {result2}");
    }
}

/*

The single element in the array: 4

Problem Statement: Given an array of N integers. Every number in the array except one appears twice. Find the single number in the array. 

*/

// Search Single Element in a sorted array

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int SingleNonDuplicate(int[] arr)
    {
        int n = arr.Length;
        if(n == 0)
            return -1;
            
        if(n == 1)
            return arr[0];
            
        if(arr[0] != arr[1])
            return arr[0];
            
        if(arr[n-1] != arr[n-2])
            return arr[n-1];
            
        int low = 1, high = n - 2;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            // If arr[mid] is the single element
            if((arr[mid] != arr[mid + 1]) && (arr[mid] != arr[mid-1]))
                return arr[mid];
                
            // We are in left array 
            if( ((mid % 2 == 1) && (arr[mid - 1] == arr[mid])) || ((mid % 2 == 0) && (arr[mid] == arr[mid + 1])))
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
        
        int[] arr = {1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6};
        
        int result = solution.SingleNonDuplicate(arr);
        if(result != -1)
            Console.WriteLine($"The single element in the array: {result}");
        else
            Console.WriteLine("There is no single element in the array");
    }
}

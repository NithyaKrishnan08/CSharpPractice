/*

Input: {3,2,1}
The next greater permutation: 
1 2 3 

Input: {1,3,2}
The next greater permutation: 
2 1 3 

*/

// To generate next greater permutation

using System;
using System.Collections.Generic;

public class Solution
{
    // To swap elements
    void SwapElements(int[] arr, int x, int y)
    {
        int temp = arr[x];
        arr[x] = arr[y];
        arr[y] = temp;
    }
    
    // To reverse an array
    void ReverseArray(int[] arr, int start, int end)
    {
        while(start < end)
        {
            SwapElements(arr, start, end);
            start++;
            end--;
        }
    }
    
    // To generate next greater permutation
    public int[] NextGreaterPermutation(int[] arr)
    {
        int n = arr.Length;

        // Step1: Find the break-point -> index
        int index = -1;
        for(int i = n-2; i >= 0; i--)
        {
            if(arr[i] < arr[i+1])
            {
                index = i;
                break;
            }
        }
        
        // Edge case: If break-point does not exist, reverse the array
        if(index == -1)
        {
            ReverseArray(arr, 0, n-1);
            return arr;
        }
        
        //Step 2: Find the next greater element and swap it with arr[index]
        for(int i = n-1; i > index; i--)
        {
            if(arr[i] > arr[index])
            {
                SwapElements(arr, i , index);
                break;
            }
        }
        
        // Step 3: Reverse the right half
        ReverseArray(arr, index + 1, n-1);
        
        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {1,3,2};
        
        int[] result = solution.NextGreaterPermutation(arr);
        
        Console.WriteLine("The next greater permutation: ");
        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
        Console.WriteLine();
    }
}

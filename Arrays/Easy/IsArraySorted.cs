
/*

The given array is sorted

*/

// To check if the array is sorted

using System;
using System.Collections.Generic;

public class Solution
{
    public bool IsSorted(int[] arr, int n)
    {
        for(int i = 1; i < n; i++)
        {
            if(arr[i] < arr[i-1])
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 4, 14, 22, 40, 99 };

        if(solution.IsSorted(inputArray, inputArray.Length))
        {
            Console.WriteLine("The given array is sorted");
        } else {
            Console.WriteLine("The given array is not sorted");
        }
    }
}

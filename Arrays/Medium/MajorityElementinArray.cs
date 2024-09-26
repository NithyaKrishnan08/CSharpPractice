/*

The element that occurs majority of the time: 4

*/

// To find the majority of element in an array using Moores Voting Algorithm

using System;
using System.Collections.Generic;

public class Solution
{
    public int MajorityElement(int[] arr)
    {
        int n = arr.Length;
        
        int count = 0;
        int element = 0;
        
        for(int i = 0; i< n; i++)
        {
            if(count == 0)
            {
                element = arr[i];
                count = 1;
            }
            else if(arr[i] == element)
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        
        int countMajority = 0;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] == element)
            {
                countMajority++;
            }
        }
        
        if(countMajority > (n / 2))
        {
            return element;
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {4,4,2,4,3,4,4,3,2,4};
        
        int result = solution.MajorityElement(arr);
        
        if(result == -1)
        {
            Console.WriteLine("No majority element exists in the array");
        }
        else
        {
            Console.WriteLine($"The element that occurs majority of the time: {result}");
        }
    }
}

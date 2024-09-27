/*

The leader elements in the array in sorted order: 
0 1 7

*/

// To get the superior or leader element in an array

using System;
using System.Collections.Generic;

public class Solution
{
    public int[] SuperiorElements(int[] arr)
    {
        int n = arr.Length;

        List<int> superiorList = new List<int>();
        int maximum = Int32.MinValue;
        
        for(int i = n-1; i >= 0; i--)
        {
            if(arr[i] > maximum)
            {
              superiorList.Add(arr[i]);
            }
            maximum = Math.Max(maximum, arr[i]);
        }
        superiorList.Sort(); 
        return superiorList.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {4, 7, 1, 0};
        
        int[] result = solution.SuperiorElements(arr);
        
        Console.WriteLine("The leader elements in the array in sorted order: ");
        for(int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
        Console.WriteLine();
    }
}

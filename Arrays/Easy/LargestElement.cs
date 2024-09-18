
/*

Largest Element: 52

*/

// Largest element in the array

using System;
using System.Collections.Generic;

public class Solution
{
    public int LargestElement(int[] arr, int n)
    {
        int largest = arr[0];
        for(int i = 0; i < n; i++)
        {
            if(arr[i] > largest)
            {
                largest = arr[i];
            }
        }
        return largest;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 13, 46, 24, 52, 20, 9 };

        int largest = solution.LargestElement(inputArray, inputArray.Length - 1);

        // Print sorted array
        Console.WriteLine("Largest Element: " + largest);
    }
}

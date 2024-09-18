
/*

Second Largest Element: 46
Second Smallest Element: 13

*/

// Second largest element and second smallest element in the array

using System;
using System.Collections.Generic;

public class Solution
{
    public int SecondLargest(int[] arr, int n)
    {
        if(n < 2)
        {
            throw new Exception("Small Array");
        }
        
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] > largest)
            {
                secondLargest = largest;
                largest = arr[i];
            } else if (arr[i] != largest && arr[i] > secondLargest)
            {
                secondLargest = arr[i];
            }
        }
        return secondLargest;
    }
    
    public int SecondSmallest(int[] arr, int n)
    {
        if(n < 2)
        {
            throw new Exception("Small Array");
        }
        
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = arr[i];
            } else if (arr[i] != smallest && arr[i] < secondSmallest)
            {
                secondSmallest = arr[i];
            }
        }
        return secondSmallest;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 13, 46, 24, 52, 20, 9 };

        int secondLargest = solution.SecondLargest(inputArray, inputArray.Length);
        
        int secondSmallest = solution.SecondSmallest(inputArray, inputArray.Length);

        Console.WriteLine("Second Largest Element: " + secondLargest);
        Console.WriteLine("Second Smallest Element: " + secondSmallest);
    }
}

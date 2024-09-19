
/*

Input: 1 4 14 22 40 99
Output: 4 14 22 40 99 1

*/

// To left rotate the array by one place

using System;
using System.Collections.Generic;

public class Solution
{
    public int[] RotateArray(int[] arr, int n)
    {
        int temp = arr[0];
        for(int i = 1; i < n; i++)
        {
            arr[i - 1] = arr[i];
        }
        arr[n - 1] = temp;
        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 4, 14, 22, 40, 99 };
        
        int[] resultArray = solution.RotateArray(inputArray, inputArray.Length);

        for(int i = 0; i < inputArray.Length; i++)
        {
            Console.Write(resultArray[i] + " ");
        }
    }
}

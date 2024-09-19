/*

Input: 1, 4, 14, 22, 40, 99
d = 2
Output: 14 22 40 99 1 4

*/

// To left rotate array by d places

using System;

public class Solution
{
    public int[] LeftRotateArray(int[] arr, int n, int d)
    {
        // Reverse first d elements
        Array.Reverse(arr, 0, d);
        // Reverse the rest of the elements
        Array.Reverse(arr, d, n - d);
        // Reverse the entire array
        Array.Reverse(arr, 0, n);

        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 4, 14, 22, 40, 99 };
        
        int d = 2; // Number of places to rotate
        
        d = d % inputArray.Length;
        
        int[] resultArray = solution.LeftRotateArray(inputArray, inputArray.Length, d);

        for(int i = 0; i < resultArray.Length; i++)
        {
            Console.Write(resultArray[i] + " ");
        }
    }
}

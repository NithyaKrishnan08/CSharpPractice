/*

4 is found at index 2

*/

// LinearSearch

using System;

public class Solution
{
    public int LinearSearch(int[] arr, int n, int num)
    {
        for(int i = 0; i < n; i++)
        {
            if(arr[i] == num)
            {
                return i;
            }
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 2, 4, 5, 8 };
        int num = 4;
        
        int result = solution.LinearSearch(inputArray, inputArray.Length, num);

        Console.WriteLine($"{num} is found at index {result}");
    }
}

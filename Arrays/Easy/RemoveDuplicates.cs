/*

Number of unique elements: 3
1 2 3

*/

using System;

public class Solution
{
    public int RemoveDuplicates(int[] arr, int n)
    {
        if (n == 0)
        {
            return 0;
        }

        int i = 0;
        for (int j = 1; j < n; j++)
        {
            if (arr[i] != arr[j])
            {
                i++;
                arr[i] = arr[j];
            }
        }
        return i + 1;  // The number of unique elements
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 1, 2, 2, 2, 3, 3 };

        // Call the function with the full length of the array
        int result = solution.RemoveDuplicates(inputArray, inputArray.Length);

        Console.WriteLine("Number of unique elements: " + result);

        // Print the unique elements
        for (int i = 0; i < result; i++)
        {
            Console.Write(inputArray[i] + " ");
        }
    }
}

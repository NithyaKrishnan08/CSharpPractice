/*

1 2 3 2 4 5 1 0 0 0 

*/

// To move all zeroes to the end of the array

using System;

public class Solution
{
    public int[] MoveZeroes(int[] arr, int n)
    {
        // Finding the zeroth index
        int j = -1;
        for(int i = 0; i < n; i++)
        {
            if(arr[i] == 0)
            {
                j = i;
                break;
            }
        }
        
        //Iterating and moving elements
        for(int i = j + 1; i < n; i++)
        {
            if(arr[i] != 0)
            {
                //swapping elements
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                j++;
            }
        }
        
        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray = new int[] { 1, 0, 2, 3, 2, 0, 0, 4, 5, 1 };
        
        int[] resultArray = solution.MoveZeroes(inputArray, inputArray.Length);

        for(int i = 0; i < resultArray.Length; i++)
        {
            Console.Write(resultArray[i] + " ");
        }
        Console.WriteLine();
    }
}

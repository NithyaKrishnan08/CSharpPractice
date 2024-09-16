/*

Selection Sort: 
9 13 20 24 52 46

*/

// Selection Sort

using System;
using System.Collections.Generic; 

public class Solution
{
    public void SelectionSort(int[] inputArray, int n)
    {
        for(int i = 0; i < n-2; i++)
        {
            int min = i;
            for(int j = i; j <= n-1; j++)
            {
                if(inputArray[j] < inputArray[min])
                {
                    min = j;
                }
                int temp = inputArray[min];
                inputArray[min] = inputArray[i];
                inputArray[i] = temp;
            }
        }

        Console.WriteLine($"Selection Sort: ");
        foreach (var item in inputArray)
        {
            Console.Write(item + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] inputArray = new int[] {13, 46, 24, 52, 20, 9};
        
        solution.SelectionSort(inputArray, inputArray.Length);     
        
    }
}

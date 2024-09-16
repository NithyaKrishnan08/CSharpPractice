/*

Insertion Sort: 
9 13 20 24 46 52 

*/

// Insertion Sort

using System;
using System.Collections.Generic; 

public class Solution
{
    public void InsertionSort(int[] inputArray, int n)
    {
        for(int i = 0; i <= n-1; i++)
        {
            int j = i;
            while(j > 0 && inputArray[j-1] > inputArray[j])
            {
                int temp = inputArray[j-1];
                inputArray[j-1] = inputArray[j];
                inputArray[j] = temp;
                j--;
            }
        }

        Console.WriteLine($"Insertion Sort: ");
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
        
        solution.InsertionSort(inputArray, inputArray.Length);     
        
    }
}

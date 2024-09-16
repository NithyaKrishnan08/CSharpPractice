/*

Bubble Sort: 
9 13 20 24 46 52

*/

// Bubble Sort

using System;
using System.Collections.Generic; 

public class Solution
{
    public void BubbleSort(int[] inputArray, int n)
    {
        for(int i = n-1; i >= 0; i--)
        {
            bool didSwap = false;
            for(int j = 0; j <= i-1; j++)
            {
                if(inputArray[j] > inputArray[j+1])
                {
                    int temp = inputArray[j+1];
                    inputArray[j+1] = inputArray[j];
                    inputArray[j] = temp;
                    didSwap = true;
                }
            }
            if(!didSwap)
            {
                break;
            }
        }

        Console.WriteLine($"Bubble Sort: ");
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
        
        solution.BubbleSort(inputArray, inputArray.Length);     
        
    }
}

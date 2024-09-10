/*

Input:
int[] array1 = {1, 2, 3, 4, 5};
int[] array2 = {6, 7, 8, 9, 10};
        
Output:
5 4 3 2 1 
10 9 8 7 6

*/

// To reverse an array

using System;

public class Solution
{
    public void ReverseArray2Pointer(int start, int end, int[] array)
    {
        if(start >= end) {
            return;
        }
        
        int temp = array[start];
        array[start] = array[end];
        array[end] = temp;
        
        ReverseArray2Pointer(start + 1, end - 1, array);
    }
    
    public void ReverseArray1Pointer(int start, int[] array)
    {
        int n = array.Length;
        if(start > n / 2) {
            return;
        }
        
        int temp = array[start];
        array[start] = array[n - start - 1];
        array[n - start - 1] = temp;
        
        ReverseArray1Pointer(start + 1, array);
    }
    
    public void PrintArray(int[] array) {
        for(int i = 0; i < array.Length; i++) {
            Console.Write(array[i] + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] array1 = {1, 2, 3, 4, 5};
        int[] array2 = {6, 7, 8, 9, 10};
        solution.ReverseArray2Pointer(0, array1.Length - 1, array1);
        solution.PrintArray(array1);
        
        Console.WriteLine();
        
        solution.ReverseArray1Pointer(0, array2);
        solution.PrintArray(array2);
    }
}

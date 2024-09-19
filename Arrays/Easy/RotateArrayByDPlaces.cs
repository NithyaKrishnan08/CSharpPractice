/*

Left rotated by 2 places: 
3 4 5 6 7 1 2 
Right rotated by 3 places: 
5 6 7 1 2 3 4 

*/

// To rotate array by d places - left & right

using System;

public class Solution
{
    public void ReverseArray(int[] arr, int start, int end)
    {
            while(start <= end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
    }
    
    public int[] LeftRotateArray(int[] arr, int n, int d)
    {
        // Reverse first d elements
        ReverseArray(arr, 0, d - 1);
        // Reverse the rest of the elements
        ReverseArray(arr, d, n - 1);
        // Reverse the entire array
        ReverseArray(arr, 0, n - 1);

        return arr;
    }
    
    public int[] RightRotateArray(int[] arr, int n, int d)
    {
        // Reverse first n - d elements
        ReverseArray(arr, 0, n - d - 1);
        // Reverse the last d elements
        ReverseArray(arr, n - d, n - 1);
        // Reverse the entire array
        ReverseArray(arr, 0, n - 1);

        return arr;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] inputArray1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        int[] inputArray2 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        
        int d1 = 2; // Number of places to rotate left
        int d2 = 3; // Number of places to rotate left
        
        d1 = d1 % inputArray1.Length;
        d2 = d2 % inputArray2.Length;
        
        int[] leftArray = solution.LeftRotateArray(inputArray1, inputArray1.Length, d1);

        Console.WriteLine($"Left rotated by {d1} places: ");
        for(int i = 0; i < leftArray.Length; i++)
        {
            Console.Write(leftArray[i] + " ");
        }
        Console.WriteLine();
        
        int[] rightArray = solution.RightRotateArray(inputArray2, inputArray2.Length, d2);

        Console.WriteLine($"Right rotated by {d2} places: ");
        for(int i = 0; i < rightArray.Length; i++)
        {
            Console.Write(rightArray[i] + " ");
        }
        Console.WriteLine();
    }
}

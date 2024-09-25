/*

0 0 1 1 2 2 

*/

// To sort arrays of 0s, 1s and 2s using Dutch National Flag Algorithm

using System;
using System.Collections.Generic;

public class Solution
{
    public void SwapElements(int[] arr, int x, int y)
    {
        int temp = arr[x];
        arr[x] = arr[y];
        arr[y] = temp;
    }
    
    public int[] SortArray(int[] arr)
    {
        int n = arr.Length;
        
        int low = 0, mid = 0, high = n - 1;
        
        while(mid <= high)
        {
            if(arr[mid] == 0)
            {
                SwapElements(arr, low, mid);
                low++;
                mid++;
            }
            else if(arr[mid] == 1)
            {
                mid++;
            }
            else
            {
                SwapElements(arr, mid, high);
                high--;
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
        
        int[] arr = new int[] {2,0,2,1,1,0};
        
        int[] result = solution.SortArray(arr);
        
        foreach(int i in result)
        {
            Console.Write(i + " ");
        }
    }
}

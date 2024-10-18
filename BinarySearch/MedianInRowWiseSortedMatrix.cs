/*

Brute force solution: 
The median element: 11

Optimal solution: 
The median element: 11

Problem Statement: Given a row-wise sorted matrix of size MXN, where M is no. of rows and N is no. of columns, find the median in the given matrix.

Note: MXN is odd.

*/

// Median of Row Wise Sorted Matrix

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int MedianInRowWiseSortedMatrix1(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        List<int> list = new List<int>();
        
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                list.Add(matrix[i, j]);
            }
        }
        
        list.Sort();
        list.ToArray();
        return list[(m * n) / 2];
    }
    
    // Optimal solution
    public int UpperBound(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        int answer = n;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] > x)
            {
                answer = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return answer;
    }
    
    public int[] GetRow(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        int[] row = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            row[j] = matrix[rowIndex, j];
        }
        return row;
    }
    
    public int CountSmallEqual(int[,] matrix, int x)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int count = 0;
        for(int i = 0; i < n; i++)
        {
            int[] row = GetRow(matrix, i);
            count += UpperBound(row, x);
        }
        return count;
    }
    
    public int MedianInRowWiseSortedMatrix2(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int low = Int32.MaxValue, high = Int32.MinValue;
        
        for(int i = 0; i < n; i++)
        {
            low = Math.Min(low, matrix[i, 0]);
            high = Math.Max(high, matrix[i, m - 1]);
        }
        
        int req = (n * m) / 2;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int smallEqual = CountSmallEqual(matrix, mid);
            if(smallEqual <= req)
                low = mid + 1;
            else
                high = mid - 1;
        }
        
        return low;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix = {
            {1, 2, 3, 4, 5},
            {8, 9, 11, 12, 13},
            {21, 23, 25, 27, 29}
        };
        
        int result1 = solution.MedianInRowWiseSortedMatrix1(matrix);
        Console.WriteLine("Brute force solution: ");
        if(result1 != -1)
            Console.WriteLine($"The median element: {result1}");
        else
            Console.WriteLine($"There is no median element");
        Console.WriteLine();
        
        int result2 = solution.MedianInRowWiseSortedMatrix2(matrix);
        Console.WriteLine("Optimal solution: ");
        if(result2 != -1)
            Console.WriteLine($"The median element: {result2}");
        else
            Console.WriteLine($"There is no median element");
        Console.WriteLine();
    }
}

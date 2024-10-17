/*

Brute force solution: 
The row with maximum number of 1s: 0

Optimal solution: 
The row with maximum number of 1s: 0

Problem Statement: You have been given a non-empty grid ‘mat’ with 'n' rows and 'm' columns consisting of only 0s and 1s. All the rows are sorted in ascending order.
Your task is to find the index of the row with the maximum number of ones.
Note: If two rows have the same number of ones, consider the one with a smaller index. If there's no row with at least 1 zero, return -1.

*/

// Find the row with maximum number of 1's

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int RowWithMaxOnes1(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        int countMax = 0, index = -1;
        for(int i = 0; i < n; i++)
        {
            int countOnes = 0;
            for(int j = 0; j < m; j++)
                countOnes += matrix[i, j];
            
            if(countOnes > countMax)
            {
                countMax = countOnes;
                index = i;
            }
        }
        return index;
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
    
    public int RowWithMaxOnes2(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        int countMax = 0, index = -1;
        for(int i = 0; i < n; i++)
        {
            int[] row = GetRow(matrix, i);
            int countOnes = m - UpperBound(row, 0);
            
            if(countOnes > countMax)
            {
                countMax = countOnes;
                index = i;
            }
        }
        return index;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix = {{1, 1, 1}, {0, 0, 1}, {0, 0, 0}};
        
        int result1 = solution.RowWithMaxOnes1(matrix);
        Console.WriteLine("Brute force solution: ");
        Console.WriteLine($"The row with maximum number of 1s: {result1}");
        Console.WriteLine();
        
        int result2 = solution.RowWithMaxOnes2(matrix);
        Console.WriteLine("Optimal solution: ");
        Console.WriteLine($"The row with maximum number of 1s: {result2}");
    }
}

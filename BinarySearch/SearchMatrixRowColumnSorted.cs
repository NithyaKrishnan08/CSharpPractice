/*

Brute force solution: 
The target 8 is present at (1,  2)

Better solution: 
The target 8 is present at (1,  2)

Optimal solution: 
The target 8 is present at (1,  2)

Problem Statement: You have been given a 2-D array 'mat' of size 'N x M' where 'N' and 'M' denote the number of rows and columns, respectively. The elements of each row and each column are sorted in non-decreasing order.
But, the first element of a row is not necessarily greater than the last element of the previous row (if it exists).
You are given an integer ‘target’, and your task is to find if it exists in the given 'mat' or not.

*/

// Search in a row and column-wise sorted matrix

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public int[] SearchMatrixRowColumnSorted1(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(matrix[i, j] == target)
                    return new int[] {i, j};
            }
        }
        return new int[] {-1, -1};
    }
    
    // Better solution
    public int BinarySearch(int[] arr, int target)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == target)
                return mid;
            else if (arr[mid] > target)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return -1;
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
    
    public int[] SearchMatrixRowColumnSorted2(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int col = -1;
        
        for(int i = 0; i < n; i++)
        {
            if(matrix[i, 0] <= target && target <= matrix[i, m - 1])
            {
                int[] row = GetRow(matrix, i);
                int colIndex = BinarySearch(row, target);
                if(colIndex != -1)
                    return new int[] {i, colIndex};
            }
                
        }
        return new int[] {-1, -1};
    }
    
    // Optimal solution
    public int[] SearchMatrixRowColumnSorted3(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int row = 0, col = m - 1;
        
        while(row < n && col >= 0)
        {
            if(matrix[row, col] == target)
                return new int[] {row, col};
            else if(matrix[row, col] < target)
                row++;
            else
                col--;
        }
        return new int[] {-1, -1};
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix = {
            {1, 4, 7, 11, 15},
            {2, 5, 8, 12, 19},
            {3, 6, 9, 16, 22},
            {10, 13, 14, 17, 24},
            {18, 21, 23, 26, 30}
        };
        int target = 8;
        
        int[] result1 = solution.SearchMatrixRowColumnSorted1(matrix, target);
        Console.WriteLine("Brute force solution: ");
        if(result1[0] != -1 && result1[1] != -1)
            Console.WriteLine($"The target {target} is present at ({result1[0]},  {result1[1]})");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
        
        int[] result2 = solution.SearchMatrixRowColumnSorted2(matrix, target);
        Console.WriteLine("Better solution: ");
        if(result2[0] != -1 && result2[1] != -1)
            Console.WriteLine($"The target {target} is present at ({result2[0]},  {result2[1]})");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
        
        int[] result3 = solution.SearchMatrixRowColumnSorted3(matrix, target);
        Console.WriteLine("Optimal solution: ");
        if(result3[0] != -1 && result3[1] != -1)
            Console.WriteLine($"The target {target} is present at ({result3[0]},  {result3[1]})");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
    }
}

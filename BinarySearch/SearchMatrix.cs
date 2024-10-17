/*

Brute force solution: 
The target 8 is present

Better solution: 
The target 8 is present

Better solution: 
The target 8 is present

Problem Statement: You have been given a 2-D array 'mat' of size 'N x M' where 'N' and 'M' denote the number of rows and columns, respectively. The elements of each row are sorted in non-decreasing order. Moreover, the first element of a row is greater than the last element of the previous row (if it exists). You are given an integer ‘target’, and your task is to find if it exists in the given 'mat' or not.

*/

// Search in a sorted 2D matrix

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute force solution
    public bool SearchMatrix1(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(matrix[i, j] == target)
                    return true;
            }
        }
        return false;
    }
    
    // Better solution
    public bool BinarySearch(int[] arr, int x)
    {
        int n = arr.Length;
        int low = 0, high = n - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if( arr[mid] == x)
                return true;
            else if (arr[mid] > x)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return false;
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
    
    public bool SearchMatrix2(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        for(int i = 0; i < n; i++)
        {
            if(matrix[i, 0] <= target && target <= matrix[i, m - 1])
                return BinarySearch(GetRow(matrix, i), target);
        }
        return false;
    }
    
    // Optimal Solution
    public bool SearchMatrix3(int[,] matrix, int target)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        int low = 0, high = n * m - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int row = mid / m, col = mid % m;
            
            if(matrix[row, col] == target)
                return true;
            else if (matrix[row, col] > target)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}};
        int target = 8;
        
        bool result1 = solution.SearchMatrix1(matrix, target);
        Console.WriteLine("Brute force solution: ");
        if(result1 == true)
            Console.WriteLine($"The target {target} is present");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
        
        bool result2 = solution.SearchMatrix2(matrix, target);
        Console.WriteLine("Better solution: ");
        if(result2 == true)
            Console.WriteLine($"The target {target} is present");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
        
        bool result3 = solution.SearchMatrix3(matrix, target);
        Console.WriteLine("Better solution: ");
        if(result3 == true)
            Console.WriteLine($"The target {target} is present");
        else
            Console.WriteLine($"The target {target} is not present");
        Console.WriteLine();
    }
}

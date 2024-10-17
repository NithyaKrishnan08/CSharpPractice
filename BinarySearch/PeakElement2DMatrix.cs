/*

Optimal solution: 
The peak element is present at (3,  4)

Problem Statement: To find the peak element in 2D matrix

*/

// Peak element in 2D matrix

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int FindMaxIndex(int[,] matrix, int col)
    {
        int n = matrix.GetLength(0);
        int maxValue = -1, index = -1;

        for (int i = 0; i < n; i++)
        {
            if(matrix[i, col] > maxValue)
            {
                maxValue = matrix[i, col];
                index = i;
            }
        }
        return index;
    }
    
    // Optimal solution
    public int[] PeakElement2DMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int low = 0, high = m - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int row = FindMaxIndex(matrix, mid);
            int left = (mid - 1 >= 0) ? matrix[row, mid - 1] : -1;
            int right = (mid + 1 < m) ? matrix[row, mid + 1] : -1;
            
            if(matrix[row, mid] > left && matrix[row, mid] > right)
                return new int[] {row, mid};
            else if(matrix[row, mid] > left)
                high = mid - 1;
            else
                low = mid + 1;
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
            {4, 2, 5, 1, 4, 5},
            {2, 9, 3, 2, 3, 2},
            {1, 7, 6, 0, 1, 3},
            {3, 6, 2, 3, 7, 2}
        };
        
        int[] result1 = solution.PeakElement2DMatrix(matrix);
        Console.WriteLine("Optimal solution: ");
        if(result1[0] != -1 && result1[1] != -1)
            Console.WriteLine($"The peak element is present at ({result1[0]},  {result1[1]})");
        else
            Console.WriteLine($"The peak element is not present");
        Console.WriteLine();
    }
}

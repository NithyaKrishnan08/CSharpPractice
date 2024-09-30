/*

The rotated matrix (Brute Force): 
7 4 1 
8 5 2 
9 6 3 

The rotated matrix (Optimized): 
7 4 1 
8 5 2 
9 6 3

*/

using System;

public class Solution
{
    // Brute force solution to rotate the matrix by 90 degrees clockwise
    public int[,] RotateMatrix(int[,] matrix, int n)
    {
        int[,] answer = new int[n, n];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                answer[j, n - 1 - i] = matrix[i, j];
            }
        }
        
        return answer;
    }

    // Swap elements in a 2D matrix
    public void SwapElements(int[,] matrix, int i, int j)
    {
        int temp = matrix[i, j];
        matrix[i, j] = matrix[j, i];
        matrix[j, i] = temp;
    }

    // Reverse a row of the matrix
    public void ReverseArray(int[,] matrix, int row)
    {
        int start = 0;
        int end = matrix.GetLength(1) - 1;
        
        while (start < end)
        {
            int temp = matrix[row, start];
            matrix[row, start] = matrix[row, end];
            matrix[row, end] = temp;
            start++;
            end--;
        }
    }

    // Optimized solution to rotate matrix in-place
    public int[,] RotateMatrixOptimized(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        
        // Step 1: Transpose the matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                SwapElements(matrix, i, j);
            }
        }

        // Step 2: Reverse each row of the transposed matrix
        for (int i = 0; i < n; i++)
        {
            ReverseArray(matrix, i);
        }

        return matrix;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix1 = new int[,] {
            {1, 2, 3}, 
            {4, 5, 6}, 
            {7, 8, 9}
        };
        int n1 = matrix1.GetLength(0);

        int[,] matrix2 = new int[,] {
            {1, 2, 3}, 
            {4, 5, 6}, 
            {7, 8, 9}
        };
        int n2 = matrix2.GetLength(0);
        
        // Brute force rotation
        int[,] result1 = solution.RotateMatrix(matrix1, n1);
        Console.WriteLine("The rotated matrix (Brute Force): ");
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n1; j++)
            {
                Console.Write(result1[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        // Optimized in-place rotation
        int[,] result2 = solution.RotateMatrixOptimized(matrix2);
        Console.WriteLine("The rotated matrix (Optimized): ");
        for (int i = 0; i < n2; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                Console.Write(result2[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

/*

Input matrix:
------------
{1, 1, 1}, 
{1, 0, 1}, 
{1, 1, 1}

Output matrix:
-------------
The final matrix: 
1 0 1 
0 0 0 
1 0 1 

The final matrix: 
1 0 1 
0 0 0 
1 0 1 
*/

// Set matrix 0

using System;
using System.Collections.Generic;

public class Solution
{
    public int[,] ZeroMatrix(int[,] matrix, int n, int m)
    {
        int[] row = new int[n]; // row array
        int[] col = new int[m]; // col array
        
        // Traverse the matrix
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(matrix[i, j] == 0)
                {
                    // Mark ith index of row with 1
                    row[i] = 1;
                    
                    // Mark jth index of col with 1
                    col[j] = 1;
                }
            }
        }
        
        // Finally, mark all (i, j) as 0
        //If row[i] or col[j] is marked with 1
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(row[i] == 1 || col[j] == 1)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        
        return matrix;
    }
    
    public int[,] OptimalZeroMatrix(int[,] matrix, int n, int m)
    {
        int col0 = 1;
        
        // step 1: Traverse the matrix and
        // mark 1st row & col accordingly:
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(matrix[i, j] == 0)
                {
                    // Mark ith index of row with 1
                    matrix[i, 0] = 0;
                    
                    // Mark jth index of col with 1
                    if(j != 0)
                        matrix[0, j] = 0;
                    else
                        col0 = 0;
                }
            }
        }
        
        // Step 2: Mark with 0 from (1,1) to (n-1, m-1):
        for(int i = 1; i < n; i++)
        {
            for(int j = 1; j < m; j++)
            {
                if(matrix[i, j] != 0)
                {
                    // check for col & row:
                    if(matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        
        //step 3: Finally mark the 1st col & then 1st row:
        if(matrix[0, 0] == 0)
        {
            for(int j = 0; j < m; j++)
            {
                matrix[0, j] = 0;
            }
        }
        if(col0 == 0)
        {
            for(int i = 0; i < n; i++)
            {
                matrix[i, 0] = 0;
            }
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
            {1, 1, 1}, 
            {1, 0, 1}, 
            {1, 1, 1}
        };
        int n1 = matrix1.GetLength(0);
        int m1 = matrix1.GetLength(1);
        
        int[,] matrix2 = new int[,] {
            {1, 1, 1}, 
            {1, 0, 1}, 
            {1, 1, 1}
        };
        int n2 = matrix2.GetLength(0);
        int m2 = matrix2.GetLength(1);
        
        int[,] result1 = solution.ZeroMatrix(matrix1, n1, m1);
        
        Console.WriteLine($"The final matrix: ");
        for(int i = 0; i < n1; i++)
        {
            for(int j = 0; j < m1; j++)
            {
                Console.Write(result1[i, j] + " ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
        
        int[,] result2 = solution.OptimalZeroMatrix(matrix2, n2, m2);
        
        Console.WriteLine($"The final matrix: ");
        for(int i = 0; i < n2; i++)
        {
            for(int j = 0; j < m2; j++)
            {
                Console.Write(result2[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

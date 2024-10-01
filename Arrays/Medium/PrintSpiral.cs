/*

Spiral matrix traversal: 
1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10

*/

// Spiral traverse of a matrix
using System;
using System.Collections.Generic;

public class Solution
{
    // Only optimal solution exists
    public int[] PrintSpiral(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        List<int> answer = new List<int>();
        
        int top = 0, bottom = n - 1;
        int left = 0, right = m - 1;
        
        while(top <= bottom && left <= right)
        {
            // left -> right
            for(int i = left; i <= right; i++)
            {
                answer.Add(matrix[top, i]);
            }
            top++;
            
            // top -> bottom
            for(int i = top; i <= bottom; i++)
            {
                answer.Add(matrix[i, right]);
            }
            right--;
            
            // right -> left
            if(top <= bottom)
            {
                for(int i = right; i >= left; i--)
                {
                    answer.Add(matrix[bottom, i]);
                }
                bottom--;
            }
            
            // bottom -> top
            if(left <= right)
            {
                for(int i = bottom; i >= top; i--)
                {
                    answer.Add(matrix[i, left]);
                }
                left++;
            }
        }
        
        return answer.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[,] matrix = new int[,] {
            { 1, 2, 3, 4 }, 
            { 5, 6, 7, 8 }, 
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };

        int[] result = solution.PrintSpiral(matrix);
        
        Console.WriteLine("Spiral matrix traversal: ");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }

        Console.WriteLine();
    }
}

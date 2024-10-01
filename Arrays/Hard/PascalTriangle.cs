/*

Variation 1: Given row number r and column number c. Print the element at position (r, c) in Pascal’s triangle.

Variation 2: Given the row number n. Print the n-th row of Pascal’s triangle.

Variation 3: Given the number of rows n. Print the first n rows of Pascal’s triangle.

Input Format:
 N = 5, r = 5, c = 3
Result:
 6 (for variation 1)
1 4 6 4 1 (for variation 2)

1 
1 1 
1 2 1 
1 3 3 1 
1 4 6 4 1    (for variation 3)


Output:

Varitaion 1
The element at position (5, 3) of Pascal's Triangle: 6

Varitaion 2
The 5th row elements of Pascal's Triangle: 
1 4 6 4 1 

Varitaion 3
Generating Pascal's Triangle of 5 rows:
1 
1 1 
1 2 1 
1 3 3 1 
1 4 6 4 1 

*/

// Program to generate Pascal's Triangle


using System;
using System.Collections.Generic;

public class Solution
{
    public int FindnCr(int n, int r)
    {
        long result = 1;
        
        for(int i = 0; i < r; i++)
        {
            result = result * (n - i);
            result = result / (i + 1);
        }

        return (int)result;
    }
    
    public int PascalTriangleElement(int rowNumber, int columnNumber)
    {
        int element = FindnCr(rowNumber - 1, columnNumber - 1);
        return element;
    }
    
    public void PrintNthRowPascalTriangle(int n)
    {
        long answer = 1;
        Console.Write(answer + " ");
        
        for(int i = 1; i < n; i++)
        {
            answer = answer * (n - i);
            answer = answer / i;
            Console.Write(answer + " ");
        }
        Console.WriteLine();
    }
    
    public void PrintPascalTriangle(int n)
    {
        for (int row = 1; row <= n; row++)
        {
            long element = 1;
            Console.Write(element + " ");
            for (int col = 1; col < row; col++)
            {
                element = element * (row - col) / col;
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int rowNumber = 5; // row number
        int columnNumber = 3; // column number
        
        Console.WriteLine("Varitaion 1");
        int element = solution.PascalTriangleElement(rowNumber, columnNumber);
        Console.WriteLine($"The element at position ({rowNumber}, {columnNumber}) of Pascal's Triangle: {element}");
        Console.WriteLine();
        
        Console.WriteLine("Varitaion 2");
        int nthRowNumber = 5;
        Console.WriteLine($"The {nthRowNumber}th row elements of Pascal's Triangle: ");
        solution.PrintNthRowPascalTriangle(nthRowNumber);
        Console.WriteLine();
        
        Console.WriteLine("Varitaion 3");
        int nRowNumber = 5;
        Console.WriteLine($"Generating Pascal's Triangle of {nRowNumber} rows:");
        solution.PrintPascalTriangle(nRowNumber);
        Console.WriteLine();
    }
}

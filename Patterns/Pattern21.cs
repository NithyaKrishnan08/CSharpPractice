/*

****
*  *
*  *
****

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern21(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || j == 0 || i == n - 1 || j == n - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
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
        solution.Pattern21(4);
    }
}
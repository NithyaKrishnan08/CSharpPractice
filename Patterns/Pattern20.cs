/*

*        *
**      **
***    ***
****  ****
**********
****  ****
***    ***
**      **
*        *

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern19(int n)
    {
        InvertPattern(n);
        ErectPattern(n - 1);
    }

    public void ErectPattern(int n)
    {
        int initialSpace = 2;
        for (int i = 0; i < n; i++)
        {
            //stars
            for (int j = 1; j <= n - i; j++)
            {
                Console.Write("*");
            }
            //spaces
            for (int j = 0; j < initialSpace; j++)
            {
                Console.Write(" ");
            }
            //stars
            for (int j = 1; j <= n - i; j++)
            {
                Console.Write("*");
            }
            initialSpace += 2;
            Console.WriteLine();
        }
    }

    public void InvertPattern(int n)
    {
        int initialSpace = 2 * n - 2;
        for (int i = 1; i <= n; i++)
        {
            //stars
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            //spaces
            for (int j = 0; j < initialSpace; j++)
            {
                Console.Write(" ");
            }
            //stars
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            initialSpace -= 2;
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.Pattern19(5);
    }
}

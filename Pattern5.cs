/*

* * * * *
* * * *
* * *
* *
*

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern5(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < n - i + 1; j++)
            {
                Console.Write("* ");
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
        solution.Pattern5(5);
    }
}

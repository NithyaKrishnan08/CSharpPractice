/*

E
DE
CDE
BCDE
ABCDE

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern18(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            char start = (char)('A' + n - i);
            for (int j = 1; j <= i; j++)
            {
                Console.Write(start);
                start = (char)(start + 1);
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
        solution.Pattern18(5);
    }
}

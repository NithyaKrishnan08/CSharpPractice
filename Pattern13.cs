/*

1 
2 3 
4 5 6 
7 8 9 10 
11 12 13 14 15 

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern13(int n)
    {
        int start = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(start);
                Console.Write(" ");
                start = start + 1;
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
        solution.Pattern13(5);
    }
}

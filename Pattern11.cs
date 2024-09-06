/*

1 
0 1 
1 0 1 
0 1 0 1 
1 0 1 0 1

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern11(int n)
    {
        int start = 1;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                start = 1;
            }
            else
            {
                start = 0;
            }
            for (int j = 0; j <= i; j++)
            {
                Console.Write(start);
                Console.Write(" ");
                start = 1 - start;
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
        solution.Pattern11(5);
    }
}

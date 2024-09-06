/*

1        1
12      21
123    321
1234  4321
1234554321

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern12(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            //numbers
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            //spaces
            for (int j = 1; j <= 2 * (n - i); j++)
            {
                Console.Write(" ");
            }
            //numbers
            for (int j = i; j >= 1; j--)
            {
                Console.Write(j);
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
        solution.Pattern12(5);
    }
}

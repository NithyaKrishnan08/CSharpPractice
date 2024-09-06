/*

ABCDE
ABCD
ABC
AB
A

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern15(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (char ch = 'A'; ch <= 'A' + (n - i - 1); ch++)
            {
                Console.Write(ch);
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
        solution.Pattern15(5);
    }
}

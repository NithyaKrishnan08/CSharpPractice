/*

A 
B B 
C C C 
D D D D 
E E E E E

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern16(int n)
    {
        char start = 'A';
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(start + " ");
            }
            Console.WriteLine();
            start = (char)(start + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.Pattern16(5);
    }
}

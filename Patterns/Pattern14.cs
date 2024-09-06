/*

A 
A B 
A B C 
A B C D 
A B C D E

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern14(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (char ch = 'A'; ch <= 'A' + i; ch++)
            {
                Console.Write(ch + " ");
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
        solution.Pattern14(5);
    }
}

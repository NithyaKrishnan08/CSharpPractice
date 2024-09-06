/*

*********
 ******* 
  *****  
   ***   
    *

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern8(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //space
            for (int j = 0; j < i; j++)
            {
                Console.Write(" ");
            }
            //stars
            for (int j = 0; j < 2 * n - (2 * i + 1); j++)
            {
                Console.Write("*");
            }
            //space
            for (int j = 0; j < i; j++)
            {
                Console.Write(" ");
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
        solution.Pattern8(5);
    }
}

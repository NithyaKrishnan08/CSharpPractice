/*

     A     
    ABA    
   ABCBA   
  ABCDCBA  
 ABCDEDCBA

 */

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern17(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //spaces
            for (int j = 0; j <= n - i - 1; j++)
            {
                Console.Write(" ");
            }

            //characters
            char ch = 'A';
            int breakpoint = (2 * i + 1) / 2;
            for (int j = 1; j <= 2 * i + 1; j++)
            {
                Console.Write(ch);
                if (j <= breakpoint)
                {
                    ch++;
                }
                else
                {
                    ch--;
                }
            }

            //spaces
            for (int j = 1; j <= n - i; j++)
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
        solution.Pattern17(5);
    }
}

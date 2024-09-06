/*
*
* *
* * *
* * * *
* * * * *
*/

using System;

public class Solution
{
    public void Pattern2(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
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
        solution.Pattern2(5);
    }
}
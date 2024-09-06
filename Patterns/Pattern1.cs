/*
* * * * *
* * * * *
* * * * *
* * * * *
* * * * *
*/

using System;

public class Solution
{
    public void SquarePattern(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
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
        solution.SquarePattern(5);
    }
}
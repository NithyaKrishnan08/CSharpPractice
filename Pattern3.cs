/*
1
1 2
1 2 3
1 2 3 4
1 2 3 4 5
*/

using System;

public class Solution
{
    public void Pattern3(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(j + 1);
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
        solution.Pattern3(5);
    }
}
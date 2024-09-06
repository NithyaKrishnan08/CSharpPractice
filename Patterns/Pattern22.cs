/*

66666666666
65555555556
65444444456
65433333456
65432223456
65432123456
65432223456
65433333456
65444444456
65555555556
66666666666

*/

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Solution
{
    public void Pattern22(int n)
    {
        if (n % 2 == 0)
        {
            for (int i = 0; i < (2 * n - 1); i++)
            {
                for (int j = 0; j < (2 * n - 1); j++)
                {
                    int top = i;
                    int left = j;
                    int right = (2 * n - 2) - j;
                    int bottom = (2 * n - 2) - i;
                    int value = n - Math.Min(Math.Min(top, bottom), Math.Min(left, right));
                    Console.Write(value);
                }
                Console.WriteLine();
            }
        }
        else
        {
            throw new Exception("Input number should be even");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.Pattern22(6);
    }
}
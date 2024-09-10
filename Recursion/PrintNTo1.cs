/*

Input: 5
Output: 
5
4
3
2
1

*/

// To print linearly N - 1 times

using System;
using System.Collections.Generic;

public class Solution
{
    public void PrintNTo1(int i, int n)
    {
        if(i < 1) {
            return;
        }
        Console.WriteLine(i);
        PrintNTo1(i-1, n);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.PrintNTo1(5, 5);
    }
}

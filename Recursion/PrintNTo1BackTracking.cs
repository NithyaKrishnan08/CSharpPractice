/*

Input: 5
Output: 
5
4
3
2
1

*/

// To print N - 1 times by back tracking

using System;
using System.Collections.Generic;

public class Solution
{
    public void PrintNTo1BackTracking(int i, int n)
    {
        if(i > n) {
            return;
        }
        PrintNTo1BackTracking(i+1, n);
        Console.WriteLine(i);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.PrintNTo1BackTracking(1, 5);
    }
}

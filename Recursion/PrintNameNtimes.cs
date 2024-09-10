/*

Input: 5
Output: 
Nithya Krishnan
Nithya Krishnan
Nithya Krishnan
Nithya Krishnan
Nithya Krishnan

*/

// To print names N times

using System;
using System.Collections.Generic;

public class Solution
{
    public void PrintNameNtimes(int i, int n)
    {
        if(i > n) {
            return;
        }
        Console.WriteLine("Nithya Krishnan");
        PrintNameNtimes(i+1, n);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.PrintNameNtimes(1, 5);
    }
}

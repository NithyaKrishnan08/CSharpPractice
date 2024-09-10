/*

Input: 5
Output: 
1
2
3
4
5

*/

// To print linearly 1 - N times by back tracking

using System;
using System.Collections.Generic;

public class Solution
{
    public void Print1ToNBackTracking(int i, int n)
    {
        if(i < 1) {
            return;
        }
        Print1ToNBackTracking(i-1, n);
        Console.WriteLine(i);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.Print1ToNBackTracking(5, 5);
    }
}

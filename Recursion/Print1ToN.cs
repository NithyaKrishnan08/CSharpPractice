/*

Input: 5
Output: 
1
2
3
4
5

*/

// To print linearly 1 - N times

using System;
using System.Collections.Generic;

public class Solution
{
    public void Print1ToN(int i, int n)
    {
        if(i > n) {
            return;
        }
        Console.WriteLine(i);
        Print1ToN(i+1, n);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.Print1ToN(1, 5);
    }
}

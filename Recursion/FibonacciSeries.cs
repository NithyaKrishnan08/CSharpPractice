/*

Input: 4
Output: 3

*/

// To find nth fibonacci number

using System;

public class Solution
{
    public int FibonacciSeries(int n)
    {
        if(n <= 1) {
            return n;
        }
        int last = FibonacciSeries(n - 1);
        int secondLast = FibonacciSeries(n - 2);
        return last + secondLast;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int result = solution.FibonacciSeries(3);
        Console.WriteLine(result);
    }
}

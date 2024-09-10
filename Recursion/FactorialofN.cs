/*

Input: 5
Output: 120

*/

// To find factorial of N

using System;

public class Solution
{
    public void FactorialParameter(int i, int factorial)
    {
        if(i == 1) {
            Console.WriteLine(factorial);
            return;
        }
        FactorialParameter(i-1, factorial * i);
    }
    
    public int FactorialFunction(int n)
    {
        if(n == 0) {
            return 1;
        }
        return n * FactorialFunction(n-1);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.FactorialParameter(5, 1);
        Console.WriteLine(solution.FactorialFunction(5));
    }
}

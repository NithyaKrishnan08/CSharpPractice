/*

Input: 36
Output: 1 2 3 4 6 6 9 12 18 36

Input: 144
Output: 1 2 3 4 6 8 9 12 12 16 18 24 36 48 72 144
*/

// To print all the divisors of the number

using System;
using System.Collections.Generic;

public class Solution
{
    public void PrintDivisors(int n)
    {
        if (n < 0)
        {
            throw new Exception("Negative number");
        }

        List<int> divisors = new List<int>();

        // O(sqrt(n))
        for (int i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                if (n / i != 1)
                {
                    divisors.Add(n / i);
                }
            }
        }

        // O(No. of factors * log(no. of factors)) : n is the number of factors
        divisors.Sort();

        //O(number of factors)
        divisors.ForEach(number => Console.Write(number + " "));
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.PrintDivisors(36);
        solution.PrintDivisors(144);
    }
}
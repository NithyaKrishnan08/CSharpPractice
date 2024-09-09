/*

Input: 13
Output: 13 is a prime number

*/

// To find a number whether it is prime number or not

using System;
using System.Collections.Generic;

public class Solution
{
    public void CheckPrimeNumber(int n)
    {
        if (n < 0)
        {
            throw new Exception("Negative number");
        }

        int count = 0;
        // O(sqrt(n))
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
                if (n / i != 1)
                {
                    count++;
                }
            }
        }

        if (count == 2)
        {
            Console.WriteLine(n + " is a prime number");
        }
        else
        {
            Console.WriteLine(n + " is not a prime number");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.CheckPrimeNumber(13);
    }
}
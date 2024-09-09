/*

Input: 52, 10
Output: 2

*/

// To find the GCD/HCF of two numbers

using System;
using System.Collections.Generic;

public class Solution
{
    public void FindGCDorHCF(int a, int b)
    {
        int result = 1;
        if (a < 0 || b < 0)
        {
            throw new Exception("One or more numbers are negative numbers");
        }

        while (a > 0 && b > 0)
        {
            if (a > b)
            {
                a = a % b;
            }
            else
            {
                b = b % a;
            }

            if (a == 0)
            {
                result = b;
            }
            else
            {
                result = a;
            }
        }

        Console.WriteLine(result);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.FindGCDorHCF(52, 10);
    }
}
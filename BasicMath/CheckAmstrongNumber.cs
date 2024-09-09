/*

Input: 153
Output: true

Input: 1634
Output: false

Input: 9474
Output: true

*/

// To check whether a number is Amstrong Number

using System;

public class Solution
{
    public void CheckAmstrongNumber(int n)
    {
        if (n < 0)
        {
            throw new Exception("Negative number");
        }
        int length = n.ToString().Length;
        int originalNumber = n;
        int sum = 0;

        while (n > 0)
        {
            int lastDigit = n % 10;
            sum = sum + (int)Math.Pow(lastDigit, length);
            n = n / 10;
        }

        if (originalNumber == sum)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.CheckAmstrongNumber(153);
        solution.CheckAmstrongNumber(1634);
        solution.CheckAmstrongNumber(9474);
        solution.CheckAmstrongNumber(1324);
    }
}
/*

Input: 1331
Output: true

*/

// To check whether a number is palindrome or not

using System;

public class Solution
{
    public void CheckPalindrome(int n)
    {
        if (n < 0)
        {
            throw new Exception("Negative number");
        }
        int originalNumber = n;
        int revNumber = 0;
        while (n > 0)
        {
            int lastDigit = n % 10;
            revNumber = (revNumber * 10) + lastDigit;
            n = n / 10;
        }
        if (revNumber == originalNumber)
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
        solution.CheckPalindrome(1331);
    }
}
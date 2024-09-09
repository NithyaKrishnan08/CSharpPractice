/*

Input: 7569
Output: 9657 

*/

// To reverse the digits in a number

using System;

public class Solution
{
    public void ReverseDigits(int n)
    {
        int revNumber = 0;
        while (n > 0)
        {
            int lastDigit = n % 10;
            revNumber = (revNumber * 10) + lastDigit;
            n = n / 10;
        }
        Console.WriteLine(revNumber);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.ReverseDigits(7569);
    }
}
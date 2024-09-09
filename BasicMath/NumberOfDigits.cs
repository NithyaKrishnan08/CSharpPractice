/*

Input: 156
Output: 3

Input: 7
Output: 1

*/

// To count number of digits in a number

using System;

public class Solution
{
    public void CountNumberOfDigits(int n)
    {
        int count = 0;
        while(n > 0) {
            int lastDigit = n % 10;
            count = count + 1;
            n = n / 10;
        }
        Console.WriteLine(count);
    }
    
    public void CountNumberOfDigitsUsingLog10(int n)
    {
        int count = (int)(Math.Log10(n)) + 1;
        Console.WriteLine(count);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.CountNumberOfDigits(4598);
        solution.CountNumberOfDigitsUsingLog10(4598);
    }
}

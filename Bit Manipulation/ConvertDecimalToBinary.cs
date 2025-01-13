/*

Problem Statement: Convert a decimal number to binary number
---------
Convert decimal to binary: 
Binary value of 13: 1101

*/

// Convert a decimal number to binary number

using System;
using System.Collections.Generic;

public class Solution
{
    public string ConvertDecimalToBinary(int n)
    {
        if (n == 0) return "0";
        
        string result = "";
        while(n > 0)
        {
            if (n % 2 == 1)
                result += '1';
            else
                result += '0';
            
            n = n / 2;
        }
        char[] resultArray = result.ToCharArray();
        Array.Reverse(resultArray);
        return new string(resultArray);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int n = 13;
        
        Console.WriteLine("Convert decimal to binary: ");
        string result = solution.ConvertDecimalToBinary(n);
        Console.WriteLine($"Binary value of {n}: {result}");
    }
}

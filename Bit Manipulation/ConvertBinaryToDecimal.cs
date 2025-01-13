/*

Problem Statement: Convert a binary number to decimal number
---------
Convert binary to decimal: 
Decimal value of 1101: 13

*/

// Convert a binary number to decimal number

using System;
using System.Collections.Generic;

public class Solution
{
    public int ConvertBinaryToDecimal(string binaryString)
    {
        int stringLength = binaryString.Length;
        int power2 = 1;
        int number = 0;
        
        for(int i = stringLength - 1; i >= 0; i--)
        {
            if(binaryString[i] == '1')
            {
               number = number +  power2;
            }
            power2 = power2 * 2;
        }
        
        return number;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string n = "1101";
        
        Console.WriteLine("Convert binary to decimal: ");
        int result = solution.ConvertBinaryToDecimal(n);
        Console.WriteLine($"Decimal value of {n}: {result}");
    }
}

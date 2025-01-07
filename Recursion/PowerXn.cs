/*

Problem Statement: Given a double x and integer n, calculate x raised to power n. Basically Implement pow(x, n).

Examples:

Example 1:

Input: x = 2.00000, n = 10

Output: 1024.00000

Explanation: You need to calculate 2.00000 raised to 10 which gives ans 1024.00000

Example 2:

Input: x = 2.10000, n = 3

Output: 9.26100

Explanation: You need to calculate 2.10000 raised to 3 which gives ans 9.26100
---------

Brute Force Solution
Answer : 0.0009765625
Optimal Solution
Answer : 0.0009765625

*/

// Implement Pow(x,n) | X raised to the power N

using System;
using System.Collections.Generic;

public class Solution
{
    // Brute Force Method
    public double Power1(double x, int n)
    {
        double answer = 1.0;
        int absN = Math.Abs(n);
        for(int i = 0; i < absN; i++)
        {
            answer = answer * x;
        }
        if (n < 0)
            return (1.0/answer);
        else
            return answer;
    }
    
    // Optimal Method
    public double Power2(double x, int n)
    {
        double answer = 1.0;
        long absN = Math.Abs((long)n);
        while(absN > 0)
        {
            if(absN % 2 == 1) {
                answer = answer * x;
                absN = absN - 1;
            } else {
                x = x * x;
                absN = absN / 2;
            }
        }
        if (n < 0)
            answer = (1.0/answer);
        
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        double result1 = solution.Power1(2, -10);
        Console.WriteLine("Brute Force Solution");
        Console.WriteLine($"Answer : {result1}");
        
        double result2 = solution.Power2(2, -10);
        Console.WriteLine("Optimal Solution");
        Console.WriteLine($"Answer : {result2}");
    }
}

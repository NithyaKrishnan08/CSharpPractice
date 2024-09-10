/*

Input: 5
Output: 15

*/

// To print sum of N numbers

using System;

public class Solution
{
    public void SumofNParameterWay(int i, int sum)
    {
        if(i < 1) {
            Console.WriteLine(sum);
            return;
        }
        SumofNParameterWay(i-1, sum + i);
    }
    
    public int SumofNFunctionWay(int n)
    {
        if(n == 0) {
            return 0;
        }
        return n + SumofNFunctionWay(n-1);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        solution.SumofNParameterWay(5, 0);
        Console.WriteLine(solution.SumofNFunctionWay(5));
    }
}

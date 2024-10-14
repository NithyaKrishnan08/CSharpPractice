/*

Optimal solution: 
The minimum divisor: 3

Problem Statement: You are given an array of integers 'arr' and an integer i.e. a threshold value 'limit'. Your task is to find the smallest positive integer divisor, such that upon dividing all the elements of the given array by it, the sum of the division's result is less than or equal to the given threshold value.

*/

// Find the Smallest Divisor Given a Threshold

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int SumByDivisor(int[] arr, int divisor)
    {
        int n = arr.Length;
        int sum = 0;
        
        for(int i = 0; i < n; i++)
        {
            sum += (int)Math.Ceiling(((double)arr[i] / (double)divisor));
        }
        return sum;
    }
    
    // Optimal solution
    public int SmallestDivisor(int[] arr, int threshold)
    {
        int n = arr.Length;
        
        if(n > threshold)
            return -1;

        int low = 1, high = arr.Max();
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            if(SumByDivisor(arr, mid) <= threshold)
            {
                answer = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }
        
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {1, 2, 3, 4, 5};
        int threshold = 8;
        
        int result = solution.SmallestDivisor(arr, threshold);
        Console.WriteLine("Optimal solution: ");
        if (result == -1)
            Console.WriteLine($"There is no minimum divisor");
        else
            Console.WriteLine($"The minimum divisor: {result}");
        Console.WriteLine();
    }
}

/*

Optimal solution
Koko should eat atleast 5 bananas/hour

Problem Statement: A monkey is given ‘n’ piles of bananas, whereas the 'ith' pile has ‘a[i]’ bananas. An integer ‘h’ is also given, which denotes the time (in hours) for all the bananas to be eaten.

Each hour, the monkey chooses a non-empty pile of bananas and eats ‘k’ bananas. If the pile contains less than ‘k’ bananas, then the monkey consumes all the bananas and won’t eat any more bananas in that hour.

Find the minimum number of bananas ‘k’ to eat per hour so that the monkey can eat all the bananas within ‘h’ hours.

*/

// Koko Eating Bananas

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int ComputeTotalHours(int[] arr, int hourly)
    {
        int n = arr.Length;
        int totalHours = 0;
        for(int i = 0; i < n; i++)
        {
            totalHours += (int)(Math.Ceiling((double)arr[i] / (double)hourly));
        }
        return totalHours;
    }
    
    public int FindMax(int[] arr)
    {
        int n = arr.Length;
        int maximum = Int32.MinValue;
        
        for(int i = 0; i < n; i++)
        {
            maximum = Math.Max(maximum, arr[i]);
        }
        
        return maximum;
    }
    
    public int MinimumRateToEatBananas(int[] arr, int hourly)
    {
        int low = 1, high = FindMax(arr);
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int totalHours = ComputeTotalHours(arr, mid);
            
            if(totalHours <= hourly)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return low;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {7, 15, 6, 3};
        int h = 8;
        
        Console.WriteLine("Optimal solution");
        int result = solution.MinimumRateToEatBananas(arr, h);
        Console.WriteLine($"Koko should eat atleast {result} bananas/hour");
    }
}

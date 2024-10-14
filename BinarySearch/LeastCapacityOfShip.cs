/*

Brute Force solution: 
The minimum capacity of the ship: 9

Optimal solution: 
The minimum capacity of the ship: 9

Problem Statement: You are the owner of a Shipment company. You use conveyor belts to ship packages from one port to another. The packages must be shipped within 'd' days.
The weights of the packages are given in an array 'of weights'. The packages are loaded on the conveyor belts every day in the same order as they appear in the array. The loaded weights must not exceed the maximum weight capacity of the ship.
Find out the least-weight capacity so that you can ship all the packages within 'd' days.

*/

// Least Capacity to Ship Packages within D Days

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int FindDays(int[] arr, int capacity)
    {
        int n = arr.Length;
        int days = 1;
        int load = 0;
        
        for(int i = 0; i < n; i++)
        {
            if(load + arr[i] > capacity)
            {
                days += 1;
                load = arr[i];
            }
            else
                load += arr[i];
        }
        return days;
    }
    
    // Brute Force solution
    public int LeastWeightCapacity1(int[] arr, int d)
    {
        int maximumWeight = arr.Max();
        int totalWeight = arr.Sum();
        
        for(int i = maximumWeight; i <= totalWeight; i++)
        {
            if(FindDays(arr, i) <= d)
                return i;
        }
        
        return -1;
    }
    
    // Optimal solution
    public int LeastWeightCapacity2(int[] arr, int d)
    {
        int low = arr.Max();
        int high = arr.Sum();
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            if(FindDays(arr, mid) <= d)
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
        
        int[] arr = {5, 4, 5, 2, 3, 4, 5, 6};
        int d = 5;
        
        int result1 = solution.LeastWeightCapacity1(arr, d);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"There is no least capacity");
        else
            Console.WriteLine($"The minimum capacity of the ship: {result1}");
        Console.WriteLine();
        
        int result2 = solution.LeastWeightCapacity2(arr, d);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"There is no least capacity");
        else
            Console.WriteLine($"The minimum capacity of the ship: {result2}");
        Console.WriteLine();
    }
}

/*

Brute Force solution:
The minimum of maximum distances between gas stations by placing 4 gas stations: 1

Optimal solution:
The minimum of maximum distances between gas stations by placing 4 gas stations: 1

Problem Statement: You are given a sorted array ‘arr’ of length ‘n’, which contains positive integer positions of ‘n’ gas stations on the X-axis. You are also given an integer ‘k’. You have to place 'k' new gas stations on the X-axis. You can place them anywhere on the non-negative side of the X-axis, even on non-integer positions. Let 'dist' be the maximum value of the distance between adjacent gas stations after adding k new gas stations.
Find the minimum value of ‘dist’.

Note: Answers within 10^-6 of the actual answer will be accepted. For example, if the actual answer is 0.65421678124, it is okay to return 0.654216. Our answer will be accepted if that is the same as the actual answer up to the 6th decimal place.

*/
// Minimise Maximum Distance between Gas Stations

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Brute Force solution
    public double CountPartitions(int[] arr, int k)
    {
        int n = arr.Length;
        int[] howMany = new int[n - 1];
        
        for(int gasStations = 1; gasStations <= k; gasStations++)
        {
            double maxSection = -1;
            int maxIndex = -1;
            for(int i = 0; i < n - 1; i++)
            {
                double diff = arr[i + 1] - arr[i];
                double sectionLength = diff / (double)(howMany[i] + 1);
                if(sectionLength > maxSection)
                {
                    maxSection = sectionLength;
                    maxIndex = i;
                }
            }
            howMany[maxIndex]++;
        }
        
        double maxAnswer = -1;
        for(int i = 0; i < n - 1; i++)
        {
            double diff = arr[i + 1] - arr[i];
            double sectionLength = diff / (howMany[i] + 1.0);
            maxAnswer = Math.Max(maxAnswer, sectionLength);
        }
        return maxAnswer;
    }
    
    public static int NumberOfGasStationsRequired(double dist, List<int> arr)
    {
        int n = arr.Count; // size of the array
        int cnt = 0;

        for (int i = 1; i < n; i++)
        {
            int numberInBetween = (int)((arr[i] - arr[i - 1]) / dist);
            if ((arr[i] - arr[i - 1]) == (dist * numberInBetween))
            {
                numberInBetween--;
            }
            cnt += numberInBetween;
        }

        return cnt;
    }

    // Method to minimize the maximum distance between gas stations
    public static double MinimiseMaxDistance(List<int> arr, int k)
    {
        int n = arr.Count; // size of the array
        double low = 0;
        double high = 0;

        // Find the maximum distance
        for (int i = 0; i < n - 1; i++)
        {
            high = Math.Max(high, (double)(arr[i + 1] - arr[i]));
        }

        // Apply Binary search
        double diff = 1e-6;
        while (high - low > diff)
        {
            double mid = (low + high) / 2.0;
            int cnt = NumberOfGasStationsRequired(mid, arr);

            if (cnt > k)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }

        return high;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = {1, 2, 3, 4, 5};
        int k = 4;
        
        double result1 = solution.CountPartitions(arr, k);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"{k} gas stations cannot be placed in the given array of gas stations.");
        else
            Console.WriteLine($"The minimum of maximum distances between gas stations by placing {k} gas stations: {result1}");
        Console.WriteLine();
        
        double result2 = solution.MinimiseMaxDistance(arr, k);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"{k} gas stations cannot be placed in the given array of gas stations.");
        else
            Console.WriteLine($"The minimum of maximum distances between gas stations by placing {k} gas stations: {result2}");
        Console.WriteLine();
    }
}

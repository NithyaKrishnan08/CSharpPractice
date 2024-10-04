/*

Merged Intervals: 
[ 1 6 ]
[ 8 10 ]
[ 15 18 ]

Problem Statement: Given an array of intervals, merge all the overlapping intervals and return an array of non-overlapping intervals.

*/

// Merge Overlapping Sub-intervals

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    // Optimized solution for merging overlapping intervals
    public List<List<int>> MergeOverlappingIntervals(List<List<int>> intervals)
    {
        // Sort intervals based on the starting point
        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        List<List<int>> merged = new List<List<int>>();
        
        foreach (var interval in intervals)
        {
            // If merged list is empty or the current interval doesn't overlap with the last one
            if (merged.Count == 0 || merged.Last()[1] < interval[0])
            {
                merged.Add(new List<int> { interval[0], interval[1] });
            }
            else
            {
                // There is an overlap, so we merge the intervals
                merged.Last()[1] = Math.Max(merged.Last()[1], interval[1]);
            }
        }

        return merged;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        // Example input: list of intervals
        List<List<int>> intervals = new List<List<int>> {
            new List<int> { 1, 3 },
            new List<int> { 8, 10 },
            new List<int> { 2, 6 },
            new List<int> { 15, 18 }
        };

        List<List<int>> result = solution.MergeOverlappingIntervals(intervals);
        
        Console.WriteLine("Merged Intervals: ");
        foreach (var interval in result)
        {
            Console.Write("[ ");
            foreach (var item in interval)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}

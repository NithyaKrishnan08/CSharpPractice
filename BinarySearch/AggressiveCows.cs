/*

Brute Force solution: 
The maximum possible minimum distance between the cows: 3

Optimal solution: 
The maximum possible minimum distance between the cows: 3

Problem Statement: You are given an array 'arr' of size 'n' which denotes the position of stalls.
You are also given an integer 'k' which denotes the number of aggressive cows.
You are given the task of assigning stalls to 'k' cows such that the minimum distance between any two of them is the maximum possible.
Find the maximum possible minimum distance.

*/

// Aggressive Cows : Detailed Solution

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public bool CanWePlaceCows(int[] arr, int minDistance, int noOfCows)
    {
        int n = arr.Length;
        int countCows = 1;
        int lastCowPosition = arr[0];
        
        for(int i = 0; i < n; i++)
        {
            if(arr[i] - lastCowPosition >= minDistance)
            {
                countCows++;
                lastCowPosition = arr[i];
            }
            if(countCows >= noOfCows)
                return true;
        }
        return false;
    }
    
    // Brute Force solution
    public int AggressiveCows1(int[] arr, int k)
    {
        int n = arr.Length;
        Array.Sort(arr);
        int limit = arr[n - 1] - arr[0];
        
        for(int i = 1; i <= limit; i++)
        {
            if(CanWePlaceCows(arr, i, k) == false)
                return (i - 1);
        }
        return limit;
    }
    
    // Optimal solution
    public int AggressiveCows2(int[] arr, int k)
    {
        int n = arr.Length;
        Array.Sort(arr);
        int low = 1, high = arr[n - 1] - arr[0];
        int answer = -1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            if(CanWePlaceCows(arr, mid, k) == true)
            {
                answer = mid;
                low = mid + 1;
            }
            else
                high = mid - 1;
        }
        
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr1 = {0, 3, 4, 7, 10, 9};
        int[] arr2 = {0, 3, 4, 7, 10, 9};
        int k = 4;
        
        int result1 = solution.AggressiveCows1(arr1, k);
        Console.WriteLine("Brute Force solution: ");
        if (result1 == -1)
            Console.WriteLine($"There is no maximum possible minimum distance between cows");
        else
            Console.WriteLine($"The maximum possible minimum distance between the cows: {result1}");
        Console.WriteLine();
        
        int result2 = solution.AggressiveCows1(arr2, k);
        Console.WriteLine("Optimal solution: ");
        if (result2 == -1)
            Console.WriteLine($"There is no maximum possible minimum distance between cows");
        else
            Console.WriteLine($"The maximum possible minimum distance between the cows: {result2}");
        Console.WriteLine();
    }
}

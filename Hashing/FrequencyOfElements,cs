/*

10: 3
5: 2
15: 1

*/

// To count frequency of each element in the array

using System;
using System.Collections.Generic; 

public class Solution
{
    public void Frequency(int[] inputArray, int n)
    {
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        
        for(int i = 0; i < n; i++)
        {
            if (mapping.ContainsKey(inputArray[i]))
            {
                mapping[inputArray[i]] += 1;  // Increment count if number already exists
            }
            else
            {
                mapping[inputArray[i]] = 1;  // Initialize count for new number
            }
        }
        
        foreach (var item in mapping)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] inputArray = new int[] {10, 5, 10, 15, 10, 5};
        
        solution.Frequency(inputArray, inputArray.Length);     
        
    }
}

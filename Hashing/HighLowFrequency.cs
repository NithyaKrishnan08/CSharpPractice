/*

 The highest frequency element: 10
 The lowest frequency element: 15

*/

// To find highest / lowest frequency of each element in the array

using System;
using System.Collections.Generic; 

public class Solution
{
    public void HighLowFrequency(int[] inputArray, int n)
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
        
        int maxFrequency = 0;
        int minFrequency = n;
        
        int maxElement = 0;
        int minElement = 0;
        foreach (var item in mapping)
        {
            int count = item.Value;
            int element = item.Key;
            
            if(count > maxFrequency)
            {
                maxElement = element;
                maxFrequency = count;
            }
            if(count < minFrequency)
            {
                minElement = element;
                minFrequency = count;
            }
        }
        Console.WriteLine($" The highest frequency element: {maxElement}");
        Console.WriteLine($" The lowest frequency element: {minElement}");
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

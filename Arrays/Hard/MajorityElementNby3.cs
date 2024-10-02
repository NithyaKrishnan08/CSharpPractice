/*

Brute force solution
The majority elements in the array: 
11 33 
Better solution
The majority elements in the array: 
11 33 
Optimized solution
The majority elements in the array: 
11 33

*/

// To find the elements that appears more than N/3 times in the array

using System;
using System.Collections.Generic;

public class Solution
{
    //Brute Force solution
    public int[] MajorityElement1(int[] arr)
    {
        int n = arr.Length;
        List<int> ls = new List<int>();
        
        for(int i = 0; i < n; i++)
        {
            if(ls.Count == 0 || !ls.Contains(arr[i]))
            {
                int count = 0;
                for(int j = 0; j < n; j++)
                {
                    if(arr[j] == arr[i])
                        count++;
                }
                
                if(count > (n / 3))
                    ls.Add(arr[i]);
            }
            
            if(ls.Count == 2)
                break;
        }

        return ls.ToArray();
    }
    
    //Better solution
    public int[] MajorityElement2(int[] arr)
    {
        int n = arr.Length;
        List<int> ls = new List<int>();
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        int min = (n / 3) + 1;
        
        for(int i = 0; i < n; i++)
        {
            if(mapping.ContainsKey(arr[i]))
            {
                mapping[arr[i]]++;
            }
            else
            {
                mapping[arr[i]] = 1;
            }
            
            if(mapping[arr[i]] == min && !ls.Contains(arr[i]))
            {
                ls.Add(arr[i]);
            }
            
            if(ls.Count == 2)
                break;
        }
        ls.Sort();
        return ls.ToArray();
    }
    
    // Optimal solution
    public int[] MajorityElement3(int[] arr)
    {
        int n = arr.Length;
        int count1 = 0, count2 = 0;
        int candidate1 = int.MinValue, candidate2 = int.MinValue;

        // 1st pass to find the candidates
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == candidate1)
            {
                count1++;
            }
            else if (arr[i] == candidate2)
            {
                count2++;
            }
            else if (count1 == 0)
            {
                candidate1 = arr[i];
                count1 = 1;
            }
            else if (count2 == 0)
            {
                candidate2 = arr[i];
                count2 = 1;
            }
            else
            {
                count1--;
                count2--;
            }
        }

        // 2nd pass to validate the candidates
        count1 = 0;
        count2 = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == candidate1)
                count1++;
            else if (arr[i] == candidate2)
                count2++;
        }

        List<int> result = new List<int>();
        if (count1 > n / 3)
            result.Add(candidate1);
        if (count2 > n / 3)
            result.Add(candidate2);

        result.Sort();
        return result.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        int[] arr1 = {11, 33, 33, 11, 33, 11};
        int[] result1 = solution.MajorityElement1(arr1);
        
        Console.WriteLine("Brute force solution");
        Console.WriteLine("The majority elements in the array: ");
        foreach(int element in result1)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
        
        int[] arr2 = {11, 33, 33, 11, 33, 11};
        int[] result2 = solution.MajorityElement2(arr2);
        
        Console.WriteLine("Better solution");
        Console.WriteLine("The majority elements in the array: ");
        foreach(int element in result2)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
        
        int[] arr3 = {11, 33, 33, 11, 33, 11};
        int[] result3 = solution.MajorityElement3(arr3);
        
        Console.WriteLine("Optimized solution");
        Console.WriteLine("The majority elements in the array: ");
        foreach(int element in result3)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}

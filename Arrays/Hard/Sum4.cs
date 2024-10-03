/*

Brute force solution
The sum of 4 elements equals 9 - quadruplets: 
[ 1 1 3 4 ][ 1 2 2 4 ][ 1 2 3 3 ]

Better solution
The sum of 4 elements equals 9 - quadruplets: 
[ 1 1 3 4 ][ 1 2 2 4 ][ 1 2 3 3 ]

Optimal solution
The sum of 4 elements equals 9 - quadruplets: 
[ 1 1 3 4 ][ 1 2 2 4 ][ 1 2 3 3 ]

*/

// 4 Sum
// Problem Statement: Given an array of N integers, your task is to find unique quads that add up to give a target value. In short, you need to return an array of all the unique quadruplets [arr[a], arr[b], arr[c], arr[d]] such that their sum is equal to a given target.

using System;
using System.Collections.Generic;

public class Solution
{
    //Brute Force solution
    public List<List<int>> FourSum1(int[] arr, int target)
    {
        int n = arr.Length;
        HashSet<List<int>> uniqueFourSet = new HashSet<List<int>>(new ListComparer());
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                for(int k = j + 1; k < n; k++)
                {
                    for(int l = k + 1; l < n; l++)
                    {
                        long sum = arr[i] + arr[j] + arr[k] + arr[l];
                        if(sum == target)
                        {
                            List<int> temp = new List<int> { arr[i], arr[j], arr[k], arr[l] };
                            temp.Sort();
                            uniqueFourSet.Add(temp);
                        }
                    }
                    
                }
            }
        }
        
        List<List<int>> answer = new List<List<int>>(uniqueFourSet);

        return answer;
    }
    
    // Custom comparer to ensure uniqueness in the HashSet
    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null || y == null) return false;
            if (x.Count != y.Count) return false;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }

        public int GetHashCode(List<int> obj)
        {
            int hash = 17;
            foreach (int element in obj)
            {
                hash = hash * 31 + element.GetHashCode();
            }
            return hash;
        }
    }
    
    //Better solution
    public List<List<int>> FourSum2(int[] arr, int target)
    {
        int n = arr.Length;
        HashSet<List<int>> uniqueFourSet = new HashSet<List<int>>(new ListComparer());
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                HashSet<int> hashSet = new HashSet<int>();
                for(int k = j + 1; k < n; k++)
                {
                    long sum = arr[i] + arr[j] + arr[k];
                    long fourth = target - sum;
        
                    if(hashSet.Contains((int)fourth))
                    {
                        List<int> temp = new List<int> { arr[i], arr[j], arr[k], (int)fourth };
                        temp.Sort();
                        uniqueFourSet.Add(temp);
                    }
                    hashSet.Add(arr[k]);
                }
            }
        }
        
        List<List<int>> answer = new List<List<int>>(uniqueFourSet);

        return answer;
    }
    
    // Optimal solution
    public List<List<int>> FourSum3(int[] arr, int target)
    {
        int n = arr.Length;
        List<List<int>> answer = new List<List<int>>();
        Array.Sort(arr);  // Sort the array to use the two-pointer technique
        
        for (int i = 0; i < n; i++)
        {
            // Skip duplicate elements to ensure unique triplets
            if (i > 0 && arr[i] == arr[i - 1])
                continue;
                
            for(int j = i + 1; j < n; j++)
            {
                if(j > i + 1 && arr[j] == arr[j - 1])
                    continue;
                
                int k = j + 1;
                int l = n - 1;
                
                while (k < l)
                {
                    long sum = arr[i] + arr[j] + arr[k] + arr[l];
        
                    if ((int)sum == target)
                    {
                        List<int> temp = new List<int> { arr[i], arr[j], arr[k], arr[l] };
                        answer.Add(temp);
                        k++;
                        l--;
        
                        // Skip duplicates for `k`
                        while (k < l && arr[k] == arr[k - 1])
                            k++;
                        
                        // Skip duplicates for `l`
                        while (k < l && arr[l] == arr[l + 1])
                            l--;
                    }
                    else if ((int)sum < target)
                    {
                        k++;
                    }
                    else
                    {
                        l--;
                    }
                }
            }
        }
        return answer;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        // Brute force
        int[] arr1 = {4, 3, 3, 4, 4, 2, 1, 2, 1, 1};
        int target1 = 9;
        List<List<int>> result1 = solution.FourSum1(arr1, target1);
        
        Console.WriteLine("Brute force solution");
        Console.WriteLine($"The sum of 4 elements equals {target1} - quadruplets: ");
        foreach(var element in result1)
        {
            Console.Write("[ ");
            foreach(var item in element)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
        }
        Console.WriteLine();
        Console.WriteLine();
        
        // Better solution
        int[] arr2 = {4, 3, 3, 4, 4, 2, 1, 2, 1, 1};
        int target2 = 9;
        List<List<int>> result2 = solution.FourSum2(arr2, target2);
        
        Console.WriteLine("Better solution");
        Console.WriteLine($"The sum of 4 elements equals {target2} - quadruplets: ");
        foreach(var element in result2)
        {
            Console.Write("[ ");
            foreach(var item in element)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
        }
        Console.WriteLine();
        Console.WriteLine();
        
        // Optimal solution
        int[] arr3 = {4, 3, 3, 4, 4, 2, 1, 2, 1, 1};
        int target3 = 9;
        List<List<int>> result3 = solution.FourSum3(arr3, target3);
        
        Console.WriteLine("Optimal solution");
        Console.WriteLine($"The sum of 4 elements equals {target3} - quadruplets: ");
        foreach(var element in result3)
        {
            Console.Write("[ ");
            foreach(var item in element)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

/*

Brute force solution
The sum of 3 elements equals zero - triplets: 
[ -1 0 1 ][ -1 -1 2 ]

Better solution
The sum of 3 elements equals zero - triplets: 
[ -1 0 1 ][ -1 -1 2 ]

Optimal solution
The sum of 3 elements equals zero - triplets: 
[ -1 -1 2 ][ -1 0 1 ]

*/

// 3 Sum
// Given an array of N integers, your task is to find unique triplets that add up to give a sum of zero. In short, you need to return an array of all the unique triplets [arr[a], arr[b], arr[c]] such that i!=j, j!=k, k!=i, and their sum is equal to zero.

using System;
using System.Collections.Generic;

public class Solution
{
    //Brute Force solution
    public List<List<int>> GenerateTriplet1(int[] arr, int n)
    {
        HashSet<List<int>> uniqueTripletsSet = new HashSet<List<int>>(new ListComparer());
        
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                for(int k = j + 1; k < n; k++)
                {
                    if(arr[i] + arr[j] + arr[k] == 0)
                    {
                        List<int> temp = new List<int> { arr[i], arr[j], arr[k] };
                        temp.Sort();
                        uniqueTripletsSet.Add(temp);
                    }
                }
            }
        }
        
        List<List<int>> answer = new List<List<int>>(uniqueTripletsSet);

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
    public List<List<int>> GenerateTriplet2(int[] arr, int n)
    {
        HashSet<List<int>> uniqueTripletsSet = new HashSet<List<int>>(new ListComparer());
        
        for(int i = 0; i < n; i++)
        {
            HashSet<int> hashSet = new HashSet<int>();
            for(int j = i + 1; j < n; j++)
            {
                int third = -(arr[i] + arr[j]);
                if(hashSet.Contains(third))
                {
                    List<int> temp = new List<int> { arr[i], arr[j], third };
                    temp.Sort();
                    uniqueTripletsSet.Add(temp);
                }
                hashSet.Add(arr[j]);
            }
        }
        
        List<List<int>> answer = new List<List<int>>(uniqueTripletsSet);

        return answer;
    }
    
    // Optimal solution
    public List<List<int>> GenerateTriplet3(int[] arr, int n)
    {
        List<List<int>> answer = new List<List<int>>();
        Array.Sort(arr);  // Sort the array to use the two-pointer technique
        
        for (int i = 0; i < n - 2; i++)
        {
            // Skip duplicate elements to ensure unique triplets
            if (i > 0 && arr[i] == arr[i - 1])
                continue;
            
            int j = i + 1;
            int k = n - 1;
    
            while (j < k)
            {
                int sum = arr[i] + arr[j] + arr[k];
    
                if (sum == 0)
                {
                    answer.Add(new List<int> { arr[i], arr[j], arr[k] });
                    j++;
                    k--;
    
                    // Skip duplicates for `j`
                    while (j < k && arr[j] == arr[j - 1])
                        j++;
                    
                    // Skip duplicates for `k`
                    while (j < k && arr[k] == arr[k + 1])
                        k--;
                }
                else if (sum < 0)
                {
                    j++;
                }
                else
                {
                    k--;
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
        int[] arr1 = {-1, 0, 1, 2, -1, -4};
        int n1 = arr1.Length;
        List<List<int>> result1 = solution.GenerateTriplet1(arr1, n1);
        
        Console.WriteLine("Brute force solution");
        Console.WriteLine("The sum of 3 elements equals zero - triplets: ");
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
        int[] arr2 = {-1, 0, 1, 2, -1, -4};
        int n2 = arr2.Length;
        List<List<int>> result2 = solution.GenerateTriplet2(arr2, n2);
        
        Console.WriteLine("Better solution");
        Console.WriteLine("The sum of 3 elements equals zero - triplets: ");
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
        
        // Better solution
        int[] arr3 = {-1, 0, 1, 2, -1, -4};
        int n3 = arr3.Length;
        List<List<int>> result3 = solution.GenerateTriplet3(arr3, n3);
        
        Console.WriteLine("Optimal solution");
        Console.WriteLine("The sum of 3 elements equals zero - triplets: ");
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
    }
}

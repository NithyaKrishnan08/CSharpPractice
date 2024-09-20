/*

1 2 3 4 5 6 7 8 9 10 11 12

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] FindUnion(int[] arr1, int[] arr2, int n, int m)
    {
        int i = 0, j = 0;
        List<int> unionList = new List<int>();

        while(i < n && j < m)
        {
            if(arr1[i] < arr2[j])
            {
                if(unionList.Count == 0 || unionList.LastOrDefault() != arr1[i])
                    unionList.Add(arr1[i]);
                i++;
            }
            else if(arr1[i] > arr2[j])
            {
                if(unionList.Count == 0 || unionList.LastOrDefault() != arr2[j])
                    unionList.Add(arr2[j]);
                j++;
            }
            else // arr1[i] == arr2[j], add only one and increment both
            {
                if(unionList.Count == 0 || unionList.LastOrDefault() != arr1[i])
                    unionList.Add(arr1[i]);
                i++;
                j++;
            }
        }

        // Add remaining elements of arr1
        while(i < n)
        {
            if(unionList.LastOrDefault() != arr1[i])
                unionList.Add(arr1[i]);
            i++;
        }

        // Add remaining elements of arr2
        while(j < m)
        {
            if(unionList.LastOrDefault() != arr2[j])
                unionList.Add(arr2[j]);
            j++;
        }

        return unionList.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] arr2 = new int[] { 2, 3, 4, 4, 5, 11, 12 };
        int[] resultList = solution.FindUnion(arr1, arr2, arr1.Length, arr2.Length);

        foreach(int i in resultList)
        {
            Console.Write(i + " ");
        }
    }
}


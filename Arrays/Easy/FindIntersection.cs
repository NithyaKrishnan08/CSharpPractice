/*

2 3 3 5 6

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] FindIntersection(int[] arr1, int[] arr2, int n, int m)
    {
        int i = 0, j = 0;
        List<int> intersectionList = new List<int>();

        while(i < n && j < m)
        {
            if(arr1[i] < arr2[j])
            {
                i++;
            }
            else if(arr2[j] < arr1[i])
            {
                j++;
            }
            else
            {
                intersectionList.Add(arr2[j]);
                i++;
                j++;
            }
        }
        return intersectionList.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] arr1 = new int[] { 1, 2, 2, 3, 3, 4, 5, 6 };
        int[] arr2 = new int[] { 2, 3, 3, 5, 6, 6, 7 };
        int[] resultList = solution.FindIntersection(arr1, arr2, arr1.Length, arr2.Length);

        foreach(int i in resultList)
        {
            Console.Write(i + " ");
        }
    }
}


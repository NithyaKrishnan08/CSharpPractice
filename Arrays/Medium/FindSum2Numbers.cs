/*

Array contains sum as 15? : NO
Array contains sum as 14? : YES

*/

// Find sum of two numbers equals target and return yes or no

using System;
using System.Collections.Generic;

public class Solution
{
    public string FindSum2Numbers(int[] arr, int target)
    {
        int n = arr.Length;
        
        int left = 0, right = n-1;
        Array.Sort(arr);
        
        while(left < right)
        {
            int sum = arr[left] + arr[right];
            if(sum == target)
            {
                return "YES";
            }
            else if(sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return "NO";
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        int[] arr = new int[] {2,6,5,8,11};
        int target = 14;
        
        string result = solution.FindSum2Numbers(arr, target);
        
        Console.WriteLine($"Array contains sum as {target}? : {result}");
    }
}

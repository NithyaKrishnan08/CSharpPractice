/*

Problem Statement: Given a string, find all the possible subsequences of the string.

Examples:

Example 1:
Input: str = "abc"
Output: a ab abc ac b bc c
Explanation: Printing all the 7 subsequence for the string "abc".

Example 2:
Input: str = "aa"
Output: a a aa 
Explanation: Printing all the 3 subsequences for the string "aa"
---------

Bit Manipulation Method
All possible subsequences are:
a ab abc ac b bc c 
Recursion Method (With Backtracking)
All possible subsequences are:
abc ab ac a bc b c 

*/

// Power Set: Print all the possible subsequences of the String

using System;
using System.Collections.Generic;

public class Solution
{
    // Bit Manipulation Method
    public List<string> AllPossibleStrings(string s)
    {
        int n = s.Length;
        List<string> ans = new List<string>();
        
        for (int num = 0; num < (1 << n); num++)
        {
            string sub = "";
            for (int i = 0; i < n; i++)
            {
                // Check if the ith bit is set or not
                if ((num & (1 << i)) != 0)
                {
                    sub += s[i];
                }
            }
            if (sub.Length > 0)
            {
                ans.Add(sub);
            }
        }
        
        ans.Sort();
        return ans;
    }
    
    // Recursion Method (With Backtracking)
    public void Solve(int i, string s, string f)
    {
        if (i == s.Length)
        {
            Console.Write(f + " ");
            return;
        }
        
        // Picking the character
        f += s[i];
        Solve(i + 1, s, f);
        
        // Popping out while backtracking
        f = f.Substring(0, f.Length - 1);
        Solve(i + 1, s, f);
    }
}

class Program
{
    static void Main()
    {
        string s = "abc";
        Solution solution = new Solution();
        
        Console.WriteLine("Bit Manipulation Method");
        List<string> ans = solution.AllPossibleStrings(s);
        
        // Printing all the subsequences
        Console.WriteLine("All possible subsequences are:");
        foreach (var it in ans)
        {
            Console.Write(it + " ");
        }
        
        Console.WriteLine();
        Console.WriteLine("Recursion Method (With Backtracking)");
        string f = "";
        Console.WriteLine("All possible subsequences are:");
        solution.Solve(0, s, f);
    }
}


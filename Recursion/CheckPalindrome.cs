/*

Input:
MADAM
LEVEL
TWO
        
Output:
True
True
False

*/

// To check a string is palindrome

using System;

public class Solution
{
    public bool CheckPalindrome(int start, string word)
    {
        int n = word.Length;
        if(start >= n / 2) {
            return true;
        }
        
        if(word[start] != word[n - start - 1]) {
            return false;
        }
        
        return CheckPalindrome(start + 1, word);
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string arrayString = "MADAM";
        bool result = solution.CheckPalindrome(0, arrayString);
        Console.WriteLine(result);
    }
}

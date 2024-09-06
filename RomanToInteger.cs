public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> romanToIntDict = new Dictionary<char, int>() 
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int total = 0;
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            int value = romanToIntDict[s[i]];

            if(i + 1 < n && romanToIntDict[s[i + 1]] > value)
                total -= value;
            else
                total += value;
        }

        return total;
    }
}
public class Solution {
    public bool IsPalindrome(int x) {
        if(x < 0)
        {
            return false;
        }

        int reversedNo = 0;
        int originalNo = x;

        while(x != 0)
        {
            int digit = x % 10;
            reversedNo = reversedNo * 10 + digit;
            x /= 10;
        }

        return originalNo == reversedNo;
    }
}
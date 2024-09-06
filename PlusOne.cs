public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;

        // Traverse the array from the end to the beginning
        for (int i = n - 1; i >= 0; i--) {
            if (digits[i] < 9) {
                digits[i]++;
                return digits;
            }
            
            digits[i] = 0; // Reset current digit to 0
        }

        // If we exit the loop, it means we have a carry over
        int[] newDigits = new int[n + 1];
        newDigits[0] = 1; // Set the most significant digit to 1
        return newDigits;
    }
}
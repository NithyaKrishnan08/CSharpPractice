public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1) {
            return 1;
        }

        int oneBefore = 1;
        int twoBefore = 1;
        int total = 0;

        for(int i = 2; i < n+1; i++){
            total = oneBefore + twoBefore;
            twoBefore = oneBefore;
            oneBefore = total;
        }

        return total;
    }
}

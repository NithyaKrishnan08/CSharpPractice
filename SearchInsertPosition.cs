public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int targetPosition = 0;
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] ==  target) {
                targetPosition = i;
            }
            else if (nums[i] < target){
                targetPosition = i + 1;
            }
        }
        return targetPosition;
    }
}
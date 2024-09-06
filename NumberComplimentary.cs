public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> numIndex = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int complement  = target - num;

            if(numIndex.ContainsKey(complement))
            {
                return new int[] {numIndex[complement], i};
            }
            numIndex[num] = i;
        }
        throw new ArgumentException("No two sum solution");
    }
}
public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = nums[0];
        int sum = 0;
        
        for(int i=0; i<nums.Length; i++) {
            sum = Math.Max(sum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, sum);
        }
        
        return maxSum;
    }
}
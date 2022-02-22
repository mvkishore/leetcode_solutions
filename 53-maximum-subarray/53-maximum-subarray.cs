public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = int.MinValue, n = nums.Length;
        int sum = 0;
        for(int i=0; i<n; i++){
            sum = Math.Max(nums[i], nums[i] + sum);
            maxSum = Math.Max(sum, maxSum);
        }
        return maxSum;
    }
}
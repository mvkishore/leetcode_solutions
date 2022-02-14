public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = int.MinValue, sum = 0;
        
        for(int i=0; i<nums.Length;i++){
            sum = Math.Max(nums[i], sum + nums[i]);
            max = Math.Max(max, sum);
        }
        return max;
    }
}
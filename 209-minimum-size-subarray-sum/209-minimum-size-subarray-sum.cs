public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int min = int.MaxValue, n = nums.Length, left =0, right = 0;
        int sum = 0;
        while(right < n){
            sum += nums[right];
            right++;
            
            while(sum >= target){
                min = Math.Min(min, right - left);
                sum -= nums[left];
                left++;
            }
        }
        
        return min == int.MaxValue ? 0 : min;
    }
}
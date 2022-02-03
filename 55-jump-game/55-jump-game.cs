public class Solution {
    public bool CanJump(int[] nums) {
        int n = nums.Length;
        int max = 0;
        for(int i=0; i <= max; i++){
            max = Math.Max(max, i + nums[i]);
            if(max >= n - 1) return true;
        }
        return false;
    }
}
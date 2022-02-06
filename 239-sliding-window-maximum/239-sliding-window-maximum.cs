public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] left_max = new int[n], right_max = new int[n];
        
        left_max[0] = nums[0];
        right_max[n-1] = nums[n-1];
        
        for(int i=1; i < n; i++){
            left_max[i] = i % k == 0 ? nums[i] : Math.Max(left_max[i-1], nums[i]);
            
            int j = n - i - 1;
            right_max[j] = j % k == 0 ? nums[j] : Math.Max(right_max[j + 1], nums[j]);
        }
        
        int[] res = new int[n - k + 1];
        for(int i=0; i<res.Length; i++){
            res[i] = Math.Max(right_max[i], left_max[i + k - 1]);
        }
        return res;
    }
}
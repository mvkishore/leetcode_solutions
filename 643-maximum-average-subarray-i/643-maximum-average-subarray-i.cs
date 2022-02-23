public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        int l = 0, r = 0, sum = 0, n = nums.Length;
        double max = double.MinValue;
        
        while(r < k){
            sum += nums[r++];
        }
        while(r < n){
            max = Math.Max(max, (sum*1.0) / k);
            sum -= nums[l++];
            sum += nums[r++];
        }
        max = Math.Max(max, (sum*1.0) / k);
        return max;
    }
}
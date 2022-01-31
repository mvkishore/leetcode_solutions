public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        return NumberOfSubarraysAtMost(nums, k) - NumberOfSubarraysAtMost(nums, k-1);
    }
    
    private int NumberOfSubarraysAtMost(int[] nums, int k){
        int l = 0, r = 0, count =0, n = nums.Length;
        
        while(r < n){
            if(nums[r++] % 2 == 1)
                k--;
            while(k < 0){
                if(nums[l++] % 2 == 1)
                    k++;
            }
            
            count += r - l;
        }
        return count;
    }
}
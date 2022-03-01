public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        return GetAtleastKSubArrays(nums, k) - GetAtleastKSubArrays(nums, k - 1);
    }
    
    
    private int GetAtleastKSubArrays(int[] nums, int k){
        int l = 0, r = 0, res = 0, n = nums.Length, count = 0;
        
        while(r < n){
            if(nums[r] % 2 == 1)
               count++;
            r++;
            
            while(count > k){
                if(nums[l] % 2 == 1) count--;
                l++;
            }
            res += (r - l);
        }
        return res;
    }
    
}

 
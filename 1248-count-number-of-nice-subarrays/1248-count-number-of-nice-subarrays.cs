public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        int l=0, r=0, count =0, n = nums.Length, res = 0;
        
        while(r < n){
            if(nums[r++] % 2 == 1){
                k--;
                count = 0;
            }
            
            while(k == 0){
                count++;
                if(nums[l++] % 2 == 1){
                    k++;
                }
            }
            res += count;
        }
        return res;
    }
}
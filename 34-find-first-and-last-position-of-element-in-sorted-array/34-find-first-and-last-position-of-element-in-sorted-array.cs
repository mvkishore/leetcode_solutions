public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int n = nums.Length, low = 0, hi = n - 1;
        if(n == 0)
            return new int[]{-1 , -1};
        
        int[] res = new int[2];
        
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            if(nums[mid] >= target)
                hi = mid;
            else
                low = mid + 1;
        }
        if(nums[low] != target)
            return new int[]{-1 , -1};
        
        res[0] = low;
        
        hi = n - 1;
        while(low < hi){
            int mid = hi - (hi - low) / 2;
            
            if(nums[mid] <= target)
                low = mid;
            else
                hi = mid - 1;
        }
        
        res[1] = low;
        return res;
    }
}
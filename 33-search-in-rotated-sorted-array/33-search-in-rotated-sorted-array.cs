public class Solution {
    public int Search(int[] nums, int target) {
        int n = nums.Length, low = 0, hi = n - 1;
        
        while(low <= hi){
            int mid = low + (hi - low) / 2;
            
            if(nums[mid] == target) return mid;
            
            if(nums[low] <= nums[mid]){
                if(nums[low] <= target && target < nums[mid])
                    hi = mid -1;
                else low = mid + 1;
            }else {
                if(nums[hi] >= target && target > nums[mid])
                    low = mid + 1;
                else hi = mid -1;
            }
        }
        return -1;
    }
}
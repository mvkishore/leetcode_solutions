public class Solution {
    public int FindPeakElement(int[] nums) {
        int n = nums.Length, low = 0, hi = n -1;
        
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            if(mid > 0 && nums[mid - 1] > nums[mid])
                hi = mid - 1;
            else if(mid < n && nums[mid] < nums[mid + 1])
                low = mid + 1;
            else return mid;
        }
        return low;
    }
}
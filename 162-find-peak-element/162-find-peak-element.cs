public class Solution {
    public int FindPeakElement(int[] nums) {
        int n = nums.Length, lo = 0, hi = n -1;
        while(lo <= hi){
            int mid = lo + (hi - lo) / 2;
            
            if(mid > 0 && nums[mid - 1] > nums[mid])
                hi = mid - 1;
            else if(mid < n - 1 && nums[mid + 1] > nums[mid])
                lo = mid + 1;
            else return mid;
        }
        
        return lo;
    }
}
public class Solution {
    public int FindMin(int[] nums) {
        int lo = 0, n = nums.Length, hi = n - 1;
        
        while(lo < hi){
            int mid = lo + (hi - lo) /2;
            if((nums[0] < nums[mid] || mid == 0) && (nums[mid] > nums[n - 1] || mid == n -1))
                lo = mid + 1;
            else
                hi = mid;
        }
        return nums[lo];
    }
}
public class Solution {
    public int FindPeakElement(int[] nums) {
        int l = 0, h = nums.Length - 1;
        
        while(l <= h){
            int m = l + (h - l)/2;
            if(m > 0 && nums[m] < nums[m - 1])
                h = m - 1;
            else if(m + 1 < nums.Length && nums[m] < nums[m+1])
                l = m + 1;
            else return m;
        }
        return -1;
    }
}
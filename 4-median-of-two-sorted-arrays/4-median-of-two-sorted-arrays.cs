public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        if(n < m)
            return FindMedianSortedArrays(nums2, nums1);
        
        int lo = 0, hi = m;
        
        while(lo <= hi){
            int nums1Mid = (lo + hi) / 2;
            int nums2Mid = (m + n + 1) / 2 - nums1Mid;
            
            int nums1LeftMax = nums1Mid == 0 ? int.MinValue : nums1[nums1Mid - 1];
            int nums1RightMin = nums1Mid == m ? int.MaxValue : nums1[nums1Mid];
            
            int nums2LeftMax = nums2Mid == 0 ? int.MinValue : nums2[nums2Mid - 1];
            int nums2RightMin = nums2Mid == n ? int.MaxValue : nums2[nums2Mid];
            
            if(nums1LeftMax <= nums2RightMin && nums2LeftMax <= nums1RightMin){
                if((m+n) % 2 == 0)
                    return (Math.Max(nums1LeftMax, nums2LeftMax) + Math.Min(nums1RightMin, nums2RightMin)) / 2.0;
                return Math.Max(nums1LeftMax, nums2LeftMax);
            }
            else if(nums1LeftMax > nums2RightMin)
                hi = nums1Mid - 1;
            else
                lo = nums1Mid + 1;
        }
        
        return -1;
    }
}
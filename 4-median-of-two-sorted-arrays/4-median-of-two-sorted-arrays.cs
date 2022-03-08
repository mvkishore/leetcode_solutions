public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        if(n < m)
            return FindMedianSortedArrays(nums2, nums1);
        
        int lo = 0, hi = m;
        while(lo <= hi){
            int mid1 = (lo + hi) / 2;
            int mid2 = (m + n + 1) / 2 - mid1;
            
            int lp1 = mid1 == 0 ? int.MinValue : nums1[mid1 - 1];
            int lp2 = mid2 == 0 ? int.MinValue : nums2[mid2 - 1];
            
            int rp1 = mid1 == m ? int.MaxValue : nums1[mid1];
            int rp2 = mid2 == n ? int.MaxValue : nums2[mid2];
            
            if(lp1 <= rp2 && lp2 <= rp1){
                if((m + n) % 2 == 0)
                    return (Math.Max(lp1, lp2) + Math.Min(rp1, rp2)) / 2.0;
                return Math.Max(lp1, lp2);
            }else if(lp1 > rp2)
                hi = mid1 - 1;
            else
                lo = mid1 + 1;
        }
        return -1;
    }
}
/*
lp1      rp1
[X X X X | X X X X X]
lp2     rp2
[X X X | X X X ]
  */  
  
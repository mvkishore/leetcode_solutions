public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        int lo = 0, hi = ribbons.Max();
        while(lo < hi){
            int mid = hi - (hi - lo) / 2;
            
            int r = GetRibbons(ribbons, mid);
            if(r < k)
                hi = mid - 1;
            else 
                lo = mid;
        }
        return lo;
    }
    
    private int GetRibbons(int[] ribbons, int length){
        int count = 0;
        foreach(var ribbon in ribbons){
            count += ribbon / length;
        }
        return count;
    }
}
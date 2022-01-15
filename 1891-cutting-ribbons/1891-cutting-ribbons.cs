public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        int low = 0, hi = (int) 1e5, n = ribbons.Length;
        
        while(low < hi)
        {
            int mid = hi - (hi - low) / 2;
            
            int count = GetRibbonCount(ribbons, mid);
            
            if(count >= k)
                low = mid;
            else
                hi = mid - 1;
        }
        
        return hi;
    }
    
    private int GetRibbonCount(int[] ribbons, int length)
    {
        int count = 0;
        foreach(var ribbon in ribbons)
            count += ribbon / length;
        
        return count;
    }
}
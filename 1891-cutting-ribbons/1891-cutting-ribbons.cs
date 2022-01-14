public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        int n = ribbons.Length;
        
        int low = 0, hi = (int) 1e5;
     
        while(low < hi){
            int mid = hi - (hi - low) / 2;
            
            int r = TotalRibbons(mid, ribbons);
            if(r >= k)
                low = mid;
            else
                hi = mid - 1;
        }
        return low;
    }
    
    public int TotalRibbons(int size, int[] ribbons)
    {
        int count = 0;
        foreach(var ribbon in ribbons)
            count += ribbon/size;
        return count;
    }
}
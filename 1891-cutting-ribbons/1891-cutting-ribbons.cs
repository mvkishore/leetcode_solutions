public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        int n = ribbons.Length;
        
        int low = 1, hi = (int) 1e5 + 1;
     
        while(low < hi){
            int mid = low + (hi - low) / 2;
            
            int r = TotalRibbons(mid, ribbons);
            if(r >= k)
                low = mid + 1;
            else
                hi = mid;
        }
        return low - 1;
    }
    
    public int TotalRibbons(int size, int[] ribbons)
    {
        int count = 0;
        foreach(var ribbon in ribbons)
            count += ribbon/size;
        return count;
    }
}
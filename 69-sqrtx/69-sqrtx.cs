public class Solution {
    public int MySqrt(int x) {
        if(x == 0)
            return 0;
        
        int lo = 1, hi = x /2;
        while(lo < hi){
            int mid = hi - (hi - lo) / 2;
            long s = (long)mid * mid;
            
            if(s > x){
                hi = mid -1;
            }else{
                lo = mid;
            }
        }
        return lo;
    }
}
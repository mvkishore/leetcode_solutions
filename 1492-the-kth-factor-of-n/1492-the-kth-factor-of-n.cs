public class Solution {
    public int KthFactor(int n, int k) {
        int lo = 1, hi = n;
        int[] memo = new int[n+1];
        
        while(lo <= hi){
            int mid = lo + (hi - lo) / 2;//1+9-1/2=>5
            
            int p = GetPosition(n, mid, memo);
            if(k == p && n % mid == 0)
                return mid;
            
            if(p < k)
                lo = mid + 1;
            else
                hi = mid -1;
        }
        return -1;
    }
    
    private int GetPosition(int n, int mid, int[] memo){
        if(mid == 0)
            return 0;
        
        if(memo[mid] > 0)
            return memo[mid];
        
        int count = n % mid == 0 ? 1 : 0;//0
        count += GetPosition(n, mid-1, memo);
        
        return memo[mid] = count;
    }
}
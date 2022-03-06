public class Solution {
    int MOD = 1000000007;
    public int CountOrders(int n) {
        long[,] memo = new long[n+1, n+1];
        return (int)GetTotalWays(n, n, memo);
    }
    
    private long GetTotalWays(int unpicked, int undelivered, long[,] memo){
        if(unpicked == 0 && undelivered == 0)
            return 1;
        
        if(unpicked < 0 || undelivered < 0 || unpicked > undelivered)
            return 0;
        
        if(memo[unpicked, undelivered] != 0)
            return memo[unpicked, undelivered];
        
        long total = 0;
        
        total += unpicked * GetTotalWays(unpicked - 1, undelivered, memo);
        
        total %= MOD;
        
        total += (undelivered - unpicked) * GetTotalWays(unpicked, undelivered - 1, memo);
        
        total %= MOD;
        return memo[unpicked, undelivered] = total;
    }
}

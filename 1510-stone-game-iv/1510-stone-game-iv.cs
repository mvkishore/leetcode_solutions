  

public class Solution {
    public bool WinnerSquareGame(int n) {
        bool?[] dp = new bool?[n+1];
        dp[0] = false;
        return CanWin(n, dp).Value;
    }
    
    private bool? CanWin(int n, bool?[] dp)
    {
        if(dp[n] != null)
            return dp[n];
        if(n == 1)
            return dp[n] = true;
        int sqr = (int) Math.Sqrt(n);
        for(int i=1; i <= sqr; i++){
            if(!CanWin(n - i*i, dp).Value)
                return dp[n] = true;
        }
        return dp[n] = false;
    }
}
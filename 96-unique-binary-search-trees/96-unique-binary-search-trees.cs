using System;

public class Solution {
    public int NumTrees(int n) {
        int[] memo = new int[n+1];
        return NumTrees(n, memo);
    }
    
    private int NumTrees(int n, int[] memo)
    {
        if(n <= 1)
            return 1;
        
        if(memo[n] != 0) return memo[n];
        
        int total = 0;
        for(int i=1; i<=n; i++){
            total += NumTrees(i-1, memo) * NumTrees(n-i, memo);
        }
        
        return memo[n] = total;
    }
}

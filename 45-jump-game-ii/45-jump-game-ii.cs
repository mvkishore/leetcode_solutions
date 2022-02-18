public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[n-1] = 0;
        for(int i=n-2; i>=0;i--){
            dp[i] = int.MaxValue-1;
            for(int x=nums[i]; x >= 1; x--){
                if(i+x < n) {
                    dp[i] = Math.Min(dp[i], 1 + dp[i + x]);
                }else{
                    dp[i] = 1;
                }
            }
        }
        return dp[0];
    }
}
/*
a[i] >= (n - i)
    
    
    dp[i] = min steps needed for reaching last
    
    dp[i] = min(dp[i+x]), for x = a[i] -> 1
    
    dp[0]; 

O(n^2)*/
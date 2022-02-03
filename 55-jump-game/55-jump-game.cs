public class Solution {
    public bool CanJump(int[] nums) {
        int n = nums.Length;
        bool[] dp = new bool[n];
        dp[n - 1] = true;
        
        for(int i=n-2; i >= 0; i--){
            bool canReach = false;
            for(int x = 1; x <= nums[i] && i+x < n && !canReach; x++){
                canReach = canReach || dp[i+x];
            }
            dp[i] = canReach;
        }
        
        return dp[0];
    }
}

// [2,3,1,1,4]
// 1 - 3 - 4 
//     -2 - 1-4
// 2
    
// [4] = true
// [1, ]
    
//  dp(i) = nums[i] > 0 && dp[i+x] for x = 1 to nums[i]
//  dp(0)
// dp(n-1) = true;
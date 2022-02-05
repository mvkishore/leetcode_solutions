public class Solution {
    public int Rob(int[] nums) {
        int?[] memo = new int?[nums.Length];
        return Rob(nums, 0, memo).Value;
    }
    
    private int? Rob(int[] nums, int cur, int?[] memo)
    {
        if(cur >= nums.Length)
            return 0;
        
        if(memo[cur] != null)
            return memo[cur];
        
        int money1 = nums[cur] + Rob(nums, cur + 2, memo).Value;
        int money2 = Rob(nums, cur + 1, memo).Value;
        
        return memo[cur] = Math.Max(money1, money2);
    }
}
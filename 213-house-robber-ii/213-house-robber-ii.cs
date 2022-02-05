public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n < 3)
            return nums.Max();
        
        int?[] memo = new int?[n];
        int withFirst = Rob(nums, 0, n - 1, memo).Value;
        
        memo = new int?[n];
        int withLast = Rob(nums, 1, n, memo).Value;
        
        return Math.Max(withFirst, withLast);
    }
    
    public int? Rob(int[] nums, int start, int last, int?[] memo)
    {
        if(start >= last)
            return 0;
        
        if(memo[start] != null)
            return memo[start];
        
        int money1 = nums[start] + Rob(nums, start + 2, last, memo).Value;
        int money2 = Rob(nums, start + 1, last, memo).Value;
        
        return memo[start] = Math.Max(money1, money2);
    }
}
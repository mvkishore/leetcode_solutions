public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        int[] memo = new int[n+1];
        foreach(var num in nums)
            memo[num]++;
        for(int i=1; i<=n; i++)
            if(memo[i] == 0)
                return i;
        return 0;
    }
}
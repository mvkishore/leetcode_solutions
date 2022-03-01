public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        var sum = nums.Sum();
        return n * (n + 1) / 2 - sum;
    }
}
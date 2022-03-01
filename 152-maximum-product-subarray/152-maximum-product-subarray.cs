public class Solution {
    public int MaxProduct(int[] nums) {
        int max = nums[0], min = nums[0];
        int result = max;
        for(int i=1; i<nums.Length; i++){
            int cur = nums[i];

            var candidates = new []{cur,  max * cur, min * cur};
            max = candidates.Max();
            min = candidates.Min();
            
            result = Math.Max(result, max);
        }
        return result;
    }
}
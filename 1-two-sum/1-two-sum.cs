public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> seen = new Dictionary<int, int>();
        for(int i=0; i<nums.Length; i++){
            int comp = target - nums[i];
            if(seen.ContainsKey(comp)){
                return new int[] {seen[comp], i};
            }
            if(!seen.ContainsKey(nums[i]))
                seen.Add(nums[i], i);
        }
        return new int[0];
    }
}
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int small = 1;
        HashSet<int> seen = new HashSet<int>();
        for(int i=0; i<nums.Length; i++){
            if(nums[i] == small)
            {
                small++;
                while(seen.Contains(small))
                    small++;
            }
            seen.Add(nums[i]);
        }
        return small;
    }
}
public class Solution {
    public int MajorityElement(int[] nums) {
        int count = 1, candidate = nums[0];
        for(int i=1; i<nums.Length; i++){
            if(count == 0)
                candidate = nums[i];
            count += (nums[i] == candidate) ? 1 : -1;
        }
        return candidate;
    }
}
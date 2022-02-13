public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int j=0;
        for(int i=0;i<nums.Length; i++){
            if(i > 0 && nums[i-1] == nums[i]) continue;
            nums[j++] = nums[i];
        }
        return j;
    }
}
public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        int count = 0;
        int sum = 0;
        
        for(int i=2; i<nums.Length; i++){
            if(nums[i] - nums[i-1] == nums[i-1] - nums[i - 2]){
                count = 1 + count;
                sum += count;
            }else
                count = 0;
        }
        return sum;
    }
}
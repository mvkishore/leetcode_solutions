public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int k=1, n = nums.Length; 
        int count = 1;
        for(int i=1; i<n; i++){
            if(nums[i-1] == nums[i] && count < 2){
                nums[k++] = nums[i];
                count++;
            }
            else if(nums[i-1] != nums[i]) {
                nums[k++] = nums[i];
                count = 1;
            }
        }
        return k;
    }
}
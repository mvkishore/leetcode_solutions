public class Solution {
    public void SortColors(int[] nums) {
        int l=0, r=nums.Length-1;
        int cur = 0;
        while(cur <= r){
            if(nums[cur] == 0) swap(nums, cur++, l++);
            else if(nums[cur] == 2) swap(nums, cur, r--);
            else if(nums[cur] == 1) cur++;
        }
    }
    
    public void swap(int[] nums, int i, int j){
        int a = nums[i];
        nums[i] = nums[j];
        nums[j] = a;
    }
}
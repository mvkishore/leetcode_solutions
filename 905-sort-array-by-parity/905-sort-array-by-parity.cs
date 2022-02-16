public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int n = nums.Length;
        int left = 0, right = n -1;
        while(left < right){
            while(left < n && nums[left] % 2 == 0)
                left++;
            while(right >= 0 && nums[right]%2 != 0)
                right--;
            
            if(left < right){
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }
        return nums;
    }
}
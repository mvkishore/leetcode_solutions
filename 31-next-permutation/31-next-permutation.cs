public class Solution {
    public void NextPermutation(int[] nums) {
        int explore = -1;
        int n = nums.Length;
        for(int i= n - 2; i >= 0; i--){
            if(nums[i] < nums[i+1])
            {
                explore = i;
                break;
            }
        }
        
        if(explore >=0){
            int next = explore + 1;
            for(int i= next; i < n; i++){
                if(nums[i] > nums[explore] && nums[next] >= nums[i])
                {
                    next = i;
                }
            }
            Swap(nums, explore, next);
        }
        Reverse(nums, explore + 1);
    }
    
    public void Swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    private void Reverse(int[] nums, int start){
        int end = nums.Length - 1;
        while(start < end){
            Swap(nums, start++, end--);
        }
    }
    
}

public class Solution {
    public void NextPermutation(int[] nums) {
        int expl = -1;
        int n = nums.Length;
        for(int i=n-2; i >= 0; i--){
            if(nums[i] < nums[i + 1]){
                expl = i;
                break;
            }
        }
        
        if(expl >= 0){
            int next = expl + 1;
            for(int i=next; i < n; i++){
                if(nums[i] > nums[expl] && nums[next] >= nums[i])
                    next = i;
            }
            
            Swap(nums, expl, next);
        }
        Reverse(nums, expl + 1);
    }
    
    private void Swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    
    private void Reverse(int[] nums, int start){
        int end = nums.Length - 1;
        while(start < end)
            Swap(nums, start++, end--);
    }
}
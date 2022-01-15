public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        
        int explorePos = n - 2;
        while(explorePos >= 0 && nums[explorePos + 1] <= nums[explorePos])
            explorePos--;
        
        if(explorePos >= 0){
            int nextPos = explorePos + 1;
            while(nextPos < n && nums[nextPos] > nums[explorePos])
                nextPos++;
            
            Swap(nums, explorePos, nextPos - 1);
        }
        Reverse(nums, explorePos + 1, n-1);
    }
    
    private void Reverse(int[] nums, int start, int end)
    {
        while(start < end){
            Swap(nums, start++, end--);
        }
    }
    
    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
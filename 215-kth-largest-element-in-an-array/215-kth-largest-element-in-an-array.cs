public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int n = nums.Length;
        
        return QuickSelect(nums, 0, n-1, n - k);
    }
    
    private int QuickSelect(int[] nums, int left, int right, int k)
    {
        if(left == right)
            return nums[left];
        
        int n = nums.Length;
        
        var pos = Partition(nums, left, right);
        
        if(pos == k)
            return nums[pos];
        if(pos < k){
            return QuickSelect(nums, pos + 1, right, k);
        }
        return QuickSelect(nums, left, pos - 1, k);
    }
    
    private int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        
        int i = left;
        for(int j = left; j < right; j++){
            if(nums[j] < pivot){
                Swap(nums, j, i++);
            }
        }
        
        Swap(nums, i, right);
        return i;
    }
    
    private void Swap(int[] nums, int i, int j){
        if(i != j){
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
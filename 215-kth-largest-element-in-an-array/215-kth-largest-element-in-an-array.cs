public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int n = nums.Length;
        return QuickSelect(nums, 0, n-1, n - k);
    }
    
    private int QuickSelect(int[] nums, int left, int right, int k)
    {
        if(left == right)
            return nums[left];
        
        int p = Partition(nums, left, right);
        if(p == k)
            return nums[p];
        else if(p < k)
            return QuickSelect(nums, p + 1, right, k);
        return QuickSelect(nums, left, p - 1, k);
    }
    
    private int Partition(int[] nums, int left, int right){
        int pivot = nums[right];
        
        int p = left;
        for(int i=left; i < right; i++){
            if(nums[i] < pivot){
                Swap(nums, i, p++);
            }
        }
        
        Swap(nums, p, right);
        return p;
    }
    
    private void Swap(int[] nums, int i, int j){
        if(i != j){
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
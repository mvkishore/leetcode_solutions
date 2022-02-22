public class Solution {
    public int MaxSubArray(int[] nums) {
        return MaxSubArray(nums, 0, nums.Length - 1);
    }
    
    private int MaxSubArray(int[] nums, int left, int right)
    {
        if(left > right){
            return int.MinValue;
        }
        
        int mid = left + (right - left ) / 2;
        int sum = 0;
        int maxLeftSum = 0;
        
        for(int i=mid - 1; i>= left; i--){
            sum += nums[i];
            maxLeftSum = Math.Max(maxLeftSum, sum);
        }
        
        sum = 0;
        int maxRightSum = 0;
        
        for(int i=mid+1; i <= right; i++){
            sum += nums[i];
            maxRightSum = Math.Max(maxRightSum, sum);
        }
        
        int combinedSum = maxLeftSum + nums[mid] + maxRightSum;
        
        int leftSide = MaxSubArray(nums, left, mid -1);
        int rightSide = MaxSubArray(nums, mid + 1, right);
        
        return Math.Max(combinedSum, Math.Max(leftSide, rightSide));
    }
}
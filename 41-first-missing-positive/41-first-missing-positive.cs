public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        bool oneExist = false;
        foreach(var num in nums){
            if(num == 1){
                oneExist = true;
                break;
            }
        }
        
        if(!oneExist) return 1;
        
        for(int i=0; i<n; i++){
            if(nums[i] <= 0 || nums[i] > n)
                nums[i] = 1;
        }
        
        for(int i=0; i<n; i++){
            int val = Math.Abs(nums[i]);
            
            if(val == n)
                nums[0] = - Math.Abs(nums[0]);
            else nums[val] = - Math.Abs(nums[val]);
        }
        
        
        for(int i=1; i<n; i++)
            if(nums[i] > 0)
                return i;
        
         if(nums[0] > 0)
            return n;
        
        return n + 1;    
    }
}                               
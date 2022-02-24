public class Solution {
    public bool CanJump(int[] nums) {
        int curMaxIndx = 0, nextMaxIndx = 0;
        int n = nums.Length;
        
        curMaxIndx = nums[0];
        
        if(n == 1)
            return true;
        
        for(int i=1; i < n; i++){
            nextMaxIndx = Math.Max(nextMaxIndx, i + nums[i]);
            
            if(curMaxIndx >= n - 1){
                return true;
            } else if(curMaxIndx == i){
                curMaxIndx = nextMaxIndx;
                nextMaxIndx = 0;
            }
        }
        return false;
    }
}
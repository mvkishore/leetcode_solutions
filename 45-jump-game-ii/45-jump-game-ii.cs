public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length;
        int maxJump = 0, curMaxJump = 0, jump = 0;
        for(int i=0; i < n-1; i++){
            maxJump = Math.Max(maxJump, i + nums[i]);
            
            if(i == curMaxJump){
                jump++;
                curMaxJump = maxJump;
            }
        }
        return jump;
    }
}
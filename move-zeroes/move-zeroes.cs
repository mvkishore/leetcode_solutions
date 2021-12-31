public class Solution {
    public void MoveZeroes(int[] nums) {
        int totalZeros = 0;
        int n = nums.Length;
        
        foreach(var num in nums)
            if(num == 0)
                totalZeros++;
        int ptr = 0;
        for(int i=0; i < n - totalZeros; i++)
        {
            while(ptr < n && nums[ptr] == 0)
                ptr++;
            nums[i] = nums[ptr++];
        }
        
        ptr = n - totalZeros;
        while(ptr < n && totalZeros > 0){
            nums[ptr++] = 0;
        }
    }
}
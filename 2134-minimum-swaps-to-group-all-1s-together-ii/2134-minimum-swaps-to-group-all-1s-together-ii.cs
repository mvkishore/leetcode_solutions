public class Solution {
    public int MinSwaps(int[] nums) {
        int left = 0, right = 0, ones = nums.Count(x=>x == 1),
        n = nums.Length, min = n, count = 0;
        
        for(left=0; left < n; left++){
            while(right - left < ones)
                count += (nums[right++ % n] == 1) ? 1 : 0;
            
            min = Math.Min(min, ones - count);
            count -= (nums[left] == 1) ? 1 : 0;
        }
        return min;
    }
}
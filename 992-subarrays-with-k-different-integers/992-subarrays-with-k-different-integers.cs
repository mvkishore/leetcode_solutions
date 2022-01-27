public class Solution {
    public int SubarraysWithKDistinct(int[] nums, int k) {
        return SubArraysWithAtMostKDistinct(nums, k) - SubArraysWithAtMostKDistinct(nums, k - 1);
    }
    
    private int SubArraysWithAtMostKDistinct(int[] nums, int k)
    {
        Dictionary<int, int> seenNums = new Dictionary<int, int>();
        
        int l =0,r=0, n = nums.Length;
        int count = 0;
        while(r < n){
            int cur = nums[r];
            if(!seenNums.ContainsKey(cur)){
                seenNums.Add(cur, 0);
            }
            seenNums[cur]++;
            r++;
            while(seenNums.Count > k){
                cur = nums[l];
                seenNums[cur]--;
                if(seenNums[cur] == 0){
                    seenNums.Remove(cur);
                }
                l++;
            }
            count += r - l;
        }
        return count;
    }
}
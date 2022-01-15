public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        if(n == 1)
            return false;
        
        int sum = 0;
        Dictionary<int, int> mods = new Dictionary<int, int>();
        mods.Add(0, -1);
        
        for(int i = 0; i<n; i++){
            sum += nums[i];
            
            if(k != 0)
                sum %= k;
           
            if(mods.ContainsKey(sum))
            {
                if(i - mods[sum] > 1) return true;
            }else mods[sum] = i;
        }
        return false;
    }
}

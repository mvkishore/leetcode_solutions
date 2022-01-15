public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int count = 0, n = nums.Length;
        int sum = 0;
        Dictionary<int, int> seenSums = new Dictionary<int, int>();
        seenSums.Add(0, 1);
        
        for(int i=0; i<n; i++){
            sum += nums[i];
            if(seenSums.ContainsKey(sum - k))
            {
                count += seenSums[sum - k];
            }
            if(!seenSums.ContainsKey(sum))
                seenSums[sum] = 1;
            else seenSums[sum]++;
        }
        
        return count;
    }
}
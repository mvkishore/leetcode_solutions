public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int n = nums.Length, sum = 0, count = 0;
        Dictionary<int, int> seenSums = new Dictionary<int, int>();
        seenSums.Add(0, 1);
        for(int i=0; i<n; i++){
            sum += nums[i];
            if(seenSums.ContainsKey(sum - k))
                count += seenSums[sum - k];
            
            if(!seenSums.ContainsKey(sum))
                seenSums.Add(sum, 0);
            
            seenSums[sum]++;
        }
        return count;
    }
}
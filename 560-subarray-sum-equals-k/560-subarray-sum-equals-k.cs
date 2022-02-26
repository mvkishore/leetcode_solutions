public class Solution {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int, int> seenSums = new Dictionary<int, int>();
        int sum = 0, n = nums.Length, count = 0;
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
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        int sum = 0;
        Dictionary<int, int> seenSums = new Dictionary<int, int>();
        seenSums.Add(0, -1);
        
        for(int i=0; i< n; i++){
            sum += nums[i];
            sum = sum %k;
            if(seenSums.ContainsKey(sum)){
                var prev = seenSums[sum];
                if(i - prev > 1)
                    return true;
            }else seenSums.Add(sum, i);
        }
        return false;
    }
}
    
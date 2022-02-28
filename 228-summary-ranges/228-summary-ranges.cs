public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        IList<string> res = new List<string>();
        if(nums.Length == 0)
            return res;
        int min = nums[0], cur = min + 1, i = 1, n = nums.Length;
        
        while(i < n){
            if(cur != nums[i]) {
                if(min == nums[i-1])
                    res.Add($"{min}");
                else
                    res.Add($"{min}->{nums[i-1]}");
                cur = nums[i];
                min = nums[i];
            }
            cur++;
            i++;
        }
        
        if(min == nums[i-1])
            res.Add($"{min}");
        else
            res.Add($"{min}->{nums[i-1]}");
        
        return res;
    }
}
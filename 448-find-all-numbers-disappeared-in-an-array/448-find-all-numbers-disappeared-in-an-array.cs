public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        IList<int> res = new List<int>();
        int n = nums.Length;
        for(int i=0; i<n ; i++){
            var j = Math.Abs(nums[i]) -1;
            if(nums[j] > 0)
                nums[j] *= -1;
        }
        
        for(int i=0; i<n; i++){
            if(nums[i] > 0)
                res.Add(i+1);
        }
        return res;
    }
}
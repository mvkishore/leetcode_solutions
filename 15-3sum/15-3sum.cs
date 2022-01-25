public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        int n = nums.Length;
        if(n < 3)
            return new List<IList<int>>();
        
        Array.Sort(nums);
        IList<IList<int>> res = new List<IList<int>>();
        
        for(int i=0; i<n; i++){
            int a = nums[i];
            TwoSum(nums, a, res, i+1);
            while(i+1 < n && nums[i+1] == nums[i])
                i++;
        }
        return res;
    }
    
    private void TwoSum(int[] nums, int a, IList<IList<int>> res, int start)
    {
        int l=start, n = nums.Length, r = n - 1;
        while(l < r){
            int b = nums[l], c = nums[r];
            int sum = a + b + c;
            if( sum == 0){
                res.Add(new List<int>(){ a, b, c});
                while(l+1 < n && nums[l+1] == nums[l])
                    l++;
                l++; r--;
            }else if(sum < 0){
                 l++;
            }else {
                 r--;
            }
        }
    }
}
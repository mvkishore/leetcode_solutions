public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        int n = nums.Length;
        if(n < 3)
            return res;
        
        Array.Sort(nums);
        
        for(int i=0; i<n; i++){
            CheckSum(nums, i, res);
            while(i + 1<n && nums[i] == nums[i + 1])
                i++;
        }
        return res;
    }
    
    private void CheckSum(int[] nums, int i, IList<IList<int>> res)
    {
        int n = nums.Length, j = i+1, k = n -1;
        while(j < k){
            int sum = nums[i] + nums[j] + nums[k];
            if(sum == 0){
                res.Add(new List<int>{nums[i], nums[j], nums[k]});
                
                while(j + 1 < n && nums[j] == nums[j + 1])
                    j++;
                
                while(k - 1 >= 0 && nums[k] == nums[k - 1])
                    k--;
                j++;
                k--;
            }else if(sum < 0){
                while(j + 1 < n && nums[j] == nums[j + 1])
                    j++;
                j++;
            }else {
                while(k - 1 >= 0 && nums[k] == nums[k - 1])
                    k--;
                k--;
            }
        }
    }
}
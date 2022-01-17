public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        int n = nums.Length;
        IList<IList<int>> result = new List<IList<int>>();
        
        if(n < 3)
            return result;
        
        Array.Sort(nums);
        
        for(int i=0; i<n; i++){
            TwoSum(nums, i + 1, nums[i], result);
            
            //Skip duplicate number
            while(i+1 < n && nums[i+1] == nums[i])
                i++;
        }
        return result;
    }
    
    
    public void TwoSum(int[] nums, int start, int target, IList<IList<int>> result)
    {
        int l = start, r = nums.Length-1;
        while(l < r){
            int sum = target + nums[l] + nums[r];
            
            if(sum == 0){
                var triple = new List<int>(){ target, nums[l++], nums[r--]};
                result.Add(triple);
                
                //Skip duplicate number
                while(l < r && nums[l] == nums[l-1])
                    l++;
            }
            else if(sum < 0) l++;
            else r--;
        }
    }
}
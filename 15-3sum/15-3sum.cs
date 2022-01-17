/*

sort = N LOGN

x + y + z = 0



x + y = -z ==> O(N)

*/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        int n = nums.Length;
        IList<IList<int>> result = new List<IList<int>>();
        if(n < 3)
            return result;
        Array.Sort(nums);
        
        for(int i=0; i<n; i++){
            var triples = TwoSum(nums, i + 1, -nums[i]);
            if(triples.Count > 0){
                foreach(var list in triples)
                    result.Add(list);
            }
            //Skip duplicate number
            while(i+1 < n && nums[i+1] == nums[i])
                i++;
        }
        return result;
    }
    
    
    public IList<IList<int>> TwoSum(int[] nums, int start, int target)
    {
        int l = start, r = nums.Length-1;
        IList<IList<int>> res = new List<IList<int>>();
        while(l < r){
            int sum = nums[l] + nums[r];
            if(sum == target){
                var triple = new List<int>();
                triple.Add(-target);
                triple.Add(nums[l]);
                triple.Add(nums[r]);
                
                res.Add(triple);
                l++;r--;
                //Skip duplicate number
                while(l < r && nums[l] == nums[l-1])
                    l++;
            }
            else if(sum < target) l++;
            else r--;
        }
        return res;
    }
}
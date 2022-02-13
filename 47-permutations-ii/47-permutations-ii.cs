public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> permutation = new List<int>();
        bool[] used = new bool[nums.Length];
        Array.Sort(nums);
        Generate(nums, permutation, res, 0, used);
        return res;
    }
    
    private void Generate(int[] nums, IList<int> permutation, IList<IList<int>> res, int index, bool[] used)
    {
        if(nums.Length == permutation.Count)
        {
            res.Add(new List<int>(permutation));
            return;
        }
        
        for(int i=0; i < nums.Length; i++){
            //skip already used and repeated numbers
            if(used[i] || (i > 0 && nums[i] == nums[i-1] && !used[i-1])) continue;

            used[i] = true;
            permutation.Add(nums[i]);
            
            Generate(nums, permutation, res, i, used);
            
            used[i] = false;
            permutation.RemoveAt(permutation.Count - 1);
        }
    }
}
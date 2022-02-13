public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> permutation = new List<int>();
        
        Generate(nums, permutation, res);
        return res;
    }
    
    private void Generate(int[] nums, IList<int> permutation, IList<IList<int>> res)
    {
        if(nums.Length == permutation.Count){
            res.Add(new List<int>(permutation));
            return;
        }
        
        for(int i=0; i<nums.Length; i++){
            if(permutation.Contains(nums[i])) continue;
            permutation.Add(nums[i]);
            Generate(nums, permutation, res);
            permutation.RemoveAt(permutation.Count - 1);
        }
    }
}
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> subset = new List<int>();
        
        Generate(nums, 0, subset, res);
        return res;
    }
    
    private void Generate(int[] nums, int index, IList<int> subset, IList<IList<int>> res)
    {
        res.Add(new List<int>(subset));
        
        for(int i=index; i<nums.Length; i++){
            subset.Add(nums[i]);
            Generate(nums, i+1, subset, res);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
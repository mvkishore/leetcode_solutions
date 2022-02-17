public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> combo = new List<int>();
        Array.Sort(candidates);
        
        Generate(candidates, 0, target, combo, res);
        return res;
    }
    
    private void Generate(int[] cands, int cur, int target, IList<int> combo, IList<IList<int>> res)
    {
        int n = cands.Length;
        if(cur >= n || target < 0)
            return;
        
        if(target == 0)
            res.Add(new List<int>(combo));
        
        for(int i=cur; i<n && cands[i] <= target; i++){
            int val = cands[i];
            combo.Add(val);
            Generate(cands, i, target - val, combo, res);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
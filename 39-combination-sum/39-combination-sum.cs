public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(candidates);
        Combination(candidates, 0, target, new List<int>(), res);
        return res;
    }
    
    private void Combination(int[] candidates, int cur, int target, IList<int> list, IList<IList<int>> res)
    {
        int n = candidates.Length;
        if(target < 0 || cur >= n)
            return;
        if(target == 0){
            res.Add(new List<int>(list));
            return;
        }
        
        for(int i=cur; i < n && candidates[i] <= target; i++){
            int val = candidates[i];

            list.Add(val);
            Combination(candidates, i, target - val, list, res);
            list.RemoveAt(list.Count - 1);
        }
    }
}
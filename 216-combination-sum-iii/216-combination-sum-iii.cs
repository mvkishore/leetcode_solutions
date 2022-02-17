public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> combo = new List<int>();
        
        Generate(k, n, 1, 0, combo, res);
        return res;
    }
    
    private void Generate(int k, int n, int num, int sum, IList<int> combo, IList<IList<int>> res)
    {
        if(sum > n || k < 0)
            return;
        
        if(k == 0){
            if(n == sum)
                res.Add(new List<int>(combo));
            return;
        }
        
        for(int i=num; i<= 9; i++){
            combo.Add(i);
            Generate(k - 1, n, i + 1, sum + i, combo, res);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}



    

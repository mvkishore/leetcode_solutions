public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res = new List<IList<int>>();
        if(numRows >= 1)
            res.Add(new List<int>(){1});
        
        if(numRows >= 2)
            res.Add(new List<int>(){1, 1});
        
        if(numRows > 2){
            int j=2;
            while(j < numRows) {
                var cur = res[j-1];
                var list = new List<int>();
                list.Add(1);
                for(int i=1; i<cur.Count; i++){
                    list.Add(cur[i-1] + cur[i]);
                }
                list.Add(1);
                res.Add(list);
                j++;
            }
        }
        return res;
    }
}
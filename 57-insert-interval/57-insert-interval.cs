public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int start = newInterval[0];
        int n = intervals.Length;
        int i=0;
        
        IList<int[]> res = new List<int[]>();
        while(i < n){
            int curEnd = intervals[i][1];
            if(curEnd >= start)
                break;
            res.Add(intervals[i++]);
        }
        
        for(int j=i; j < n; j++){
            if(IsOvralap(newInterval, intervals[j])){
                newInterval = merge(newInterval, intervals[j]);
            } else {
                res.Add(newInterval);
                newInterval = intervals[j];
            }
        }
        
        res.Add(newInterval);
        return res.ToArray();
    }
    
    private bool IsOvralap(int[] x, int[] y){
        return x[0] <= y[1] && y[0] <= x[1];
    }
    
    private int[] merge(int[] x, int[] y){
        return new int[]{ Math.Min(x[0], y[0]), Math.Max(x[1], y[1])};
    }
}
public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a,b) => a[0] - b[0]);
        
        var prev = intervals[0];
        var list = new List<int[]>();
        
        for(int i=1; i<intervals.Length; i++){
            var cur = intervals[i];
            if(IsOverlap(prev, cur)){
                prev = Merge(cur, prev);
            }else{
                list.Add(prev);
                prev = cur;
            }
        }
        
        list.Add(prev);
        return list.ToArray();
    }
    
    private bool IsOverlap(int[] a, int[] b){
        return b[0] <= a[1];
    }
    
    private int[] Merge(int[] a, int[] b){
        return new []{ Math.Min(a[0], b[0]), Math.Max(a[1], b[1])};
    }
}
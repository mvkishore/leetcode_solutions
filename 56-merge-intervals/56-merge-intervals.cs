public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        var prev = intervals[0];
        List<int[]> result = new List<int[]>();
            
        for(int i=1; i < intervals.Length; i++){
            var cur = intervals[i];
            if(IsOverlap(prev, cur))
                prev = Merge(prev, cur);
            else{
                result.Add(prev);
                prev = cur;
            }
        }
        result.Add(prev);
        return result.ToArray();
    }
    
    private bool IsOverlap(int[] a, int[] b)
    {
        return a[0] <= b[1] && b[0] <= a[1];
    }
    
    private int[] Merge(int[] a, int[] b)
    {
        return new int[]{ Math.Min(a[0], b[0]), Math.Max(a[1], b[1])};
    }
}
public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> list = new List<int[]>();
        int n = intervals.Length;

        int i =0;
        while(i < n && intervals[i][1] < newInterval[0]){
            list.Add(intervals[i]);
            i++;
        }
        
        var prev = newInterval;
        while(i < n){
            var cur = intervals[i];
            if(IsOverlap(prev, cur)){
                prev = Merge(prev, cur);
            }else{
                list.Add(prev);
                prev = cur;
            }
            i++;
        }
        
        list.Add(prev);
        return list.ToArray();
    }
    
    private bool IsOverlap(int[] a, int[] b){
        return a[0] <= b[1] && b[0] <= a[1];
    }
    
    private int[] Merge(int[] a, int[] b){
        return new int[]{Math.Min(a[0], b[0]), Math.Max(a[1], b[1])};
    }
}
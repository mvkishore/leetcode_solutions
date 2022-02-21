public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        int n = intervals.Length;
        Array.Sort(intervals, (a, b) => b[0] == a[0] ? b[1] - a[1] : a[0] - b[0]);
        int count = 1;
        var prev = intervals[0];
        for(int i = 1; i<n;i++){
            if(!IsCovered(prev, intervals[i]))
            {
                count++;
                prev = intervals[i];
            }
        }
        return count;
    }
    private bool IsCovered(int[] a, int[] b){
        return a[0] <= b[0] && a[1] >= b[1];
    }
}
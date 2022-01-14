public class Solution {
    public int FindMinArrowShots(int[][] points) {
        int n = points.Length;
        Array.Sort(points, (a, b) => {return a[1] < b[1] ? -1 : a[1] > b[1] ? 1 : 0;});

        int arrowCount = 1, curEnd = points[0][1];
        foreach(var p in points){
            int start = p[0];
            int end = p[1];
            
            if(curEnd < start){
                arrowCount++;
                curEnd = end;
            }
        }
        
        return arrowCount;
    }
}
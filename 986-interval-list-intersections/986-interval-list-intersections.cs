public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        int left = 0, right = 0;
        int m = firstList.Length, n = secondList.Length;
        List<int[]> res = new List<int[]>();
        
        while(left < m && right < n){
            if(IsOverlap(firstList[left], secondList[right])){
                var merge = Merge(firstList[left], secondList[right]);
                res.Add(merge);
            }
            
            if(firstList[left][1] < secondList[right][1])
                left++;
            else 
                right++;
        }
        return res.ToArray();
    }
    
    private bool IsOverlap(int[] a, int[] b){
        return a[0] <= b[1] && b[0] <= a[1];
    }
    
    private int[] Merge(int[] a, int[] b){
        return new int[]{ Math.Max(a[0], b[0]), Math.Min(b[1], a[1])};
    }
}
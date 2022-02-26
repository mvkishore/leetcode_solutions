public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int[], double> queue = new PriorityQueue<int[], double>
            (Comparer<double>.Create((a, b) => b.CompareTo(a)));
        int n = points.Length;
        
        for(int i=0; i<n; i++){
            var point = points[i];
            double distance = GetDistance(point);
            
            if(queue.Count == k)
            {
                if(GetDistance(queue.Peek()) > distance)
                    queue.Dequeue();
                else continue;
            }
            
            queue.Enqueue(point, distance);
        }
        int l = queue.Count;
        int[][] res = new int[l][];
        
        for(int i=0; i < l; i++)
            res[i] = queue.Dequeue();
        return res;
    }
    
    private double GetDistance(int[] point){
        int x = point[0], y = point[1];
        return Math.Sqrt(x*x + y*y);
    }
}
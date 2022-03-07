public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        
        for(int i=0; i< points.Length; i++){
            var point = points[i];
            int d = GetDistance(point);
            
            if(queue.Count == k){
                if(GetDistance(points[queue.Peek()]) < d){
                    continue;
                }
                queue.Dequeue();
            }
            
            queue.Enqueue(i, d);
        }
        
        int[][] results = new int[queue.Count][];
        int c = 0;
        while(queue.Count > 0){
            results[c++] = points[queue.Dequeue()];
        }
        
        return results;
    }
    
    private int GetDistance(int[] point){
        return point[0] * point[0] + point[1] * point[1];
    }
}
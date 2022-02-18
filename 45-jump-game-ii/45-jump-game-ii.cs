public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length;
        if(n == 1)
            return 0;
        
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        
        int steps = 0;
        queue.Enqueue(0);
        visited[0] = true;
        
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                for(int j=1; j<=nums[cur]; j++){
                    var nextPos = cur + j;
                    if(nextPos >= n - 1)
                        return steps + 1;
                    if(!visited[nextPos]){
                        visited[nextPos] = true;
                        queue.Enqueue(nextPos);
                    }
                }
            }
            steps++;
        }
        return 0;
        
    }
}
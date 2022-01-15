public class Solution {
    public int MinJumps(int[] arr) {
        int n = arr.Length;
        Dictionary<int, List<int>> canJumps = new Dictionary<int, List<int>>();
        for(int i=0; i<n; i++){
            if(!canJumps.ContainsKey(arr[i]))
                canJumps.Add(arr[i], new List<int>());
            
            canJumps[arr[i]].Add(i);
        }
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = true;
        int count = 0;
        while(queue.Count > 0){
            for(int i = queue.Count - 1; i >= 0 ; i--){
                var cur = queue.Dequeue();
                
                if(cur == n - 1)
                    return count;
                
                var nextJumps = canJumps[arr[cur]];
                nextJumps.Add(cur + 1);
                nextJumps.Add(cur - 1);
                
                foreach(var next in nextJumps){
                    if(next >= 0&& next < n && !visited[next]){
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
                canJumps[arr[cur]].Clear();
            }
            count++;
        }
        
        return 0;
    }
}
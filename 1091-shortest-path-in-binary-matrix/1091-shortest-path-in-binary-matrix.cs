public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        if(grid[0][0] != 0)
            return -1;
        
        int n = grid.Length;
        Queue<int[]> queue = new Queue<int[]>();
        bool[,] visited = new bool[n, n];
        
        queue.Enqueue(new []{0, 0});
        visited[0, 0] = true;
        int path = 1;
        
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                
                if(cur[0] == n - 1 && cur[1] == n - 1)
                    return path;
                
                foreach(var nei in GetNeibors(cur, n))
                {
                    int nextRow = nei[0], nextCol = nei[1];
                    if(nextRow == n - 1 && nextCol == n - 1 && grid[nextRow][nextCol] != 1)
                        return 1 + path;
                    
                    if(!visited[nextRow, nextCol] && grid[nextRow][nextCol] != 1){
                        visited[nextRow, nextCol] = true;
                        queue.Enqueue(new[]{nextRow, nextCol});
                    }
                }
            }
            path++;
        }
        
        return -1;
    }
    
    private IList<int[]> GetNeibors(int[] cur, int n){
        var dirs = new int[][] {
            new []{0, 1},
            new []{1, 0},
            new []{0, -1},
            new []{-1, 0},
            new []{1, 1},
            new []{-1, -1},
            new []{1, -1},
            new []{-1, 1},
        };
        var neibors = new List<int[]>();
        foreach(var dir in dirs){
            int nextRow = cur[0] + dir[0];
            int nextCol = cur[1] + dir[1];
            
            if(nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n)
                neibors.Add(new []{ nextRow, nextCol });
        }
        return neibors;
    }
}
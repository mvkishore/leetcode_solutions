public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int n = grid.Length;
        
        if(grid[0][0] != 0)
            return -1;
        
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[]{0, 0});
        grid[0][0] = 1;
        
        int len = 1;
        while(queue.Count > 0)
        {
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                
                if(cur[0] == n-1 && cur[1] == n-1)
                    return len;
                
                foreach(var nei in GetNieghbors(cur[0], cur[1], n)){
                    int nextRow = nei[0], nextCol = nei[1];
                    if(grid[nextRow][nextCol] == 0){
                        if(nextRow == n -1 && nextCol == n - 1)
                            return len + 1;
                        
                        grid[nextRow][nextCol] = 1;
                        queue.Enqueue(nei);
                    }
                }
            }
            len++;
        }
        
        return -1;
    }
    private List<int[]> GetNieghbors(int row, int col, int size)
    {
        var dirs = new int[][] {new []{1, 0}, new []{-1, 0}
                                , new []{0, 1}, new []{0, -1}
                                , new []{1,-1}, new []{-1, 1}
                                , new []{1, 1}, new []{-1, -1}};
        var list = new List<int[]>();
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow >= 0 && nextRow < size && nextCol >= 0 && nextCol < size)
                list.Add(new int[]{ nextRow, nextCol});
        }
        return list;
    }
}
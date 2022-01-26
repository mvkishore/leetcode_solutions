public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        bool[,] visited = new bool[rows, cols];
        int countFreshOranges = 0;
        for(int row=0; row < rows; row++){
            for(int col=0; col < cols; col++){
                if(grid[row][col] == 2)
                    queue.Enqueue(new int[]{row, col});
                else if(grid[row][col] == 1)
                    countFreshOranges++;
            }
        }
        if(countFreshOranges == 0)
            return 0;
        
        int minutes = -1;
        while(queue.Count > 0){
            int size = queue.Count;
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                if(visited[cur[0], cur[1]]) continue;
                
                visited[cur[0], cur[1]] = true;
                
                foreach(var nei in GetValidNeighbors(grid, cur[0], cur[1])){
                    if(!visited[nei[0], nei[1]] && grid[nei[0]][nei[1]] == 1){
                        queue.Enqueue(nei);
                        grid[nei[0]][nei[1]] = 2;
                        countFreshOranges--;
                    }
                }
            }
            minutes++;
        }
        return countFreshOranges == 0 ? minutes : -1;
    }
    
    private List<int[]> GetValidNeighbors(int[][] grid, int row, int col)
    {
        var dirs = new int[][]{new []{0, 1},new []{1, 0},new []{0, -1},new []{-1, 0}};
        List<int[]> neighbors = new List<int[]>();
        int rows = grid.Length;
        int cols = grid[0].Length;
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols && grid[nextRow][nextCol] != 0){
                neighbors.Add(new int[]{nextRow, nextCol});
            }
        }
        
        return neighbors;
    }
}
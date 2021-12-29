public class Solution {
    public int ShortestDistance(int[][] grid) {
        int houses = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        int minDist = int.MaxValue;
        
        for(int row=0; row<rows; row++){
            for(int col=0; col<cols; col++){
                if(grid[row][col] == 1)
                    houses++;
            }
        }
        
        for(int row=0; row<rows; row++){
            for(int col=0; col<cols; col++){
                if(grid[row][col] == 0){
                    minDist = Math.Min(minDist, GetDistance(grid, row, col, houses));
                }
            }
        }
        
        if(minDist == int.MaxValue) return -1;
        
        return minDist;
        
    }
    
    private int GetDistance(int[][] grid, int row, int col, int houses){
        int rows = grid.Length;
        int cols = grid[0].Length;
        var dirs = new int[][] { new []{1, 0}, new []{-1, 0},new []{0, 1}, new []{0, -1}};
        int dist = 0;
        int totalDistance = 0;
        int reachedHouses = 0;
        
        bool[,] visited = new bool[rows, cols];
        Queue<int[]> queue = new Queue<int[]>();
        
        visited[row, col] = true;
        queue.Enqueue(new int[]{ row, col});

        while(queue.Count > 0){
            int size = queue.Count;
            
            for(int i=0; i<size; i++){
                var curCell = queue.Dequeue();
                row = curCell[0];
                col = curCell[1];
                
                if(grid[row][col] == 1){
                    reachedHouses++;
                    totalDistance+=dist;
                    continue;
                }
                
                foreach(var dir in dirs){
                    var nextRow = row + dir[0];
                    var nextCol = col + dir[1];
                    
                    if(nextRow < rows && nextCol < cols && nextRow >= 0 && nextCol >= 0
                       && !visited[nextRow, nextCol] && grid[nextRow][nextCol] != 2){
                        visited[nextRow, nextCol] = true;
                        queue.Enqueue(new int[]{ nextRow, nextCol});
                    }
                }
            }
            dist++;
        }
        
        if(houses != reachedHouses){
            for(row=0; row<rows; row++){
                for(col=0; col<cols; col++){
                    if(visited[row, col] && grid[row][col] == 0)
                        grid[row][col] = 2;
                }
            }
            return int.MaxValue;
        }
        
        return totalDistance;
    }
}
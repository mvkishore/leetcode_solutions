public class Solution {
    public int ShortestDistance(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        int minDist = int.MaxValue;
        int houses = 0;
        
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(grid[row][col] == 1)
                    houses++;
            }
        }
        
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(grid[row][col] == 0){
                    minDist = Math.Min(minDist, GetMinDistance(grid, row, col, houses));
                }
            }
        }
        
        if(minDist == int.MaxValue) return -1;
        
        return minDist;
    }
    
    private int GetMinDistance(int[][] grid, int row, int col, int houses)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int[][] dirs = new int[][]{new []{0, 1}, new[]{0, -1}, new []{1, 0}, new[]{-1, 0}};
        int visitedHouses = 0, distance = 0, totalDist = 0;
        
        Queue<int[]> queue = new Queue<int[]>();
        bool[,] visited = new bool[rows, cols];
        visited[row, col] = true;
        queue.Enqueue(new []{row, col});
        
        while(queue.Count > 0){
            int size = queue.Count;
            
            for(int i=0; i<size; i++){
                var cur = queue.Dequeue();
                row = cur[0];
                col = cur[1];
                if(grid[row][col] == 1){
                    visitedHouses++;
                    totalDist += distance;
                    if(visitedHouses == houses)
                        return totalDist;
                    continue;
                }
                
                 foreach(var dir in dirs){
                    int nextRow = row + dir[0], nextCol = col + dir[1];
                    if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols
                      && !visited[nextRow, nextCol] && grid[nextRow][nextCol] != 2){
                         queue.Enqueue(new[]{nextRow, nextCol});
                        visited[nextRow, nextCol] = true;
                    }
                }
            }
            distance++;
        }
        
        if(visitedHouses != houses){
            for(row = 0; row < rows; row++){
                for(col = 0; col < cols; col++){
                    if(grid[row][col] == 0 && visited[row, col]){
                        grid[row][col] = 2;
                    }
                }
            }
            return int.MaxValue;
        }
        return totalDist;
    }
}
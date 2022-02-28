public class Solution {
    public int LargestIsland(int[][] grid) {
        int maxArea = 0;
        int rows = grid.Length, cols = grid[0].Length;
        Dictionary<int, int> areas = new Dictionary<int, int>();
        bool[,] visited = new bool[rows, cols];
        int color = 2;
        
        for(int row=0; row<rows; row++){
            for(int col=0; col<cols; col++){
                if(grid[row][col] == 1 && !visited[row, col]){
                    int area = GetArea(grid, row, col, color, visited);
                    areas.Add(color, area);
                    maxArea = Math.Max(maxArea, area);
                    color++;
                }
            }
        }
        int[][] dirs = new int[][]{new []{0, 1}, new[]{0, -1}, new []{1, 0}, new[]{-1, 0}};
        
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(grid[row][col] == 0){
                    int area = 1;
                    HashSet<int> seenColors = new HashSet<int>();
                    
                    foreach(var dir in dirs){
                        var nextRow = row + dir[0];
                        var nextCol = col + dir[1];
                        
                        if(Valid(nextRow, nextCol, grid)){
                            color = grid[nextRow][nextCol];
                            if(areas.ContainsKey(color) && !seenColors.Contains(color)){
                                area += areas[color];
                                seenColors.Add(color);
                            }
                        }
                    }
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }
        return maxArea;
    }
    
    private int GetArea(int[][] grid, int row, int col, int color, bool[, ] visited)
    {
        
        visited[row, col] = true;
        grid[row][col] = color;
        
        int area = 1;
        int[][] dirs = new int[][]{new []{0, 1}, new[]{0, -1}, new []{1, 0}, new[]{-1, 0}};
        foreach(var dir in dirs){
            var nextRow = row + dir[0];
            var nextCol = col + dir[1];
            if(Valid(nextRow, nextCol, grid) && !visited[nextRow, nextCol] && grid[nextRow][nextCol] == 1){
                area += GetArea(grid, nextRow, nextCol, color, visited);
                
            }
        }
        return area;
    }
    
    private bool Valid(int row, int col, int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        return row < rows && row >= 0 && col >=0 && col < cols;
    }
}
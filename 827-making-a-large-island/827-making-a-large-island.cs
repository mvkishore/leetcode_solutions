public class Solution {
    public int LargestIsland(int[][] grid) {
        int n = grid.Length, color = 2;
        Dictionary<int, int> areas = new Dictionary<int, int>();
        int maxArea = 0;
        
        bool[,] visited = new bool[n, n];
        for(int row=0; row<n; row++){
            for(int col=0; col<n; col++){
                if(grid[row][col] == 1 && !visited[row, col]){
                    var area = GetAreaAndPaint(grid, row, col, color, visited);
                    areas.Add(color++, area);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }
        
        for(int row=0; row<n; row++){
            for(int col=0; col<n; col++){
                if(grid[row][col] == 0){
                    int area = 1;
                    HashSet<int> seenColor = new HashSet<int>();
                    foreach(var next in GetNext(row, col, n))
                    {
                        color = grid[next.row][next.col];
                        if(color > 1 && !seenColor.Contains(color)){
                            area += areas[color];
                            seenColor.Add(color);
                        }
                    }
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }
        
        return maxArea;
    }
    
    private int GetAreaAndPaint(int[][] grid, int row, int col, int color, bool[,] visited)
    {
        int area = 1;
        visited[row, col] = true;
        int n = grid.Length;
        grid[row][col] = color;
        foreach(var next in GetNext(row, col, n))
        {
            if(grid[next.row][next.col] == 1 && !visited[next.row, next.col])
                area += GetAreaAndPaint(grid, next.row, next.col, color, visited);
        }
        
        return area;
    }
    
    private List<(int row, int col)> GetNext(int row, int col, int n)
    {
        var nextPos = new List<(int x, int y)>();
        var dirs = new int[][]{new int[]{1, 0}, new int[]{-1, 0},new int[]{0, 1},new int[]{0, -1}};
        
        foreach(var dir in dirs){
            int nextRow = row + dir[0];
            int nextCol = col + dir[1];
            
            if(nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n)
                nextPos.Add((nextRow, nextCol));
        }
        return nextPos;
    }
}
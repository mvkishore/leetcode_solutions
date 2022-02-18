public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] cache = new int[m, n];
        
        return MinPathSum(grid, 0, 0, cache);
    }
    
    private int MinPathSum(int[][] grid, int row, int col, int[,] cache)
    {
        int m = grid.Length, n = grid[0].Length;
        if(row < 0 || row >= m || col < 0 || col >= n)
            return int.MaxValue;
        
        if(cache[row, col] != 0)
            return cache[row, col];
        
        int sum = grid[row][col];
        
        var rightPathSum = MinPathSum(grid, row, col + 1, cache);
        var downPathSum = MinPathSum(grid, row + 1, col, cache);
        
        var minPathSum = Math.Min(rightPathSum, downPathSum) == int.MaxValue ? 0 : Math.Min(rightPathSum, downPathSum);
        
        return cache[row, col] = sum + minPathSum;
    }
}
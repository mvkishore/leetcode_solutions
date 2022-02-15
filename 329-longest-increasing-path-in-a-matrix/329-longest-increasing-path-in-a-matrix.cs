public class Solution {
    int[][] dirs = new int[][]{new []{1,0}, new[]{0,1}, new[]{-1, 0}, new[]{0,-1}};
    public int LongestIncreasingPath(int[][] matrix) {
        int maxPath = 0;
        
        int rows = matrix.Length, cols = matrix[0].Length;
        int[,] cache = new int[rows, cols];
        
        for(int row = 0; row < rows; row++){
            for(int col=0; col< cols; col++) {
                int len = GetLengthOfIncreasingPath(matrix, row, col, cache);
                maxPath = Math.Max(len, maxPath);
            }
        }
        
        return maxPath;
    }
    private int GetLengthOfIncreasingPath(int[][] matrix, int row, int col, int[,] cache){
        if(cache[row, col] > 0) return cache[row, col];
        
        int m = matrix.Length, n = matrix[0].Length;
        foreach(var dir in dirs){
            int nextRow = row + dir[0], nextCol = col + dir[1];
            if(nextRow >=0 && nextRow < m && nextCol >=0 && nextCol < n 
               && matrix[nextRow][nextCol] > matrix[row][col])
                cache[row, col] = Math.Max(cache[row, col], GetLengthOfIncreasingPath(matrix, nextRow, nextCol, cache));
        }
        
        return cache[row, col] = 1 + cache[row, col];
    }
    
}
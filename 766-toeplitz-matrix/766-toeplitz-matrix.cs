public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        for(int row = 0; row < rows; row++)
            if(!ValidDiagonal(row, 0, matrix, matrix[row][0]))
                return false;
        
        for(int col = 1; col < cols; col++)
            if(!ValidDiagonal(0, col, matrix, matrix[0][col]))
                return false;
        
        return true;
    }
    
    private bool ValidDiagonal(int row, int col, int[][] matrix, int target)
    {
        int rows = matrix.Length, cols = matrix[0].Length;
        while(row < rows && col < cols){
            if(matrix[row][col] != target)
                return false;
            row = row + 1;
            col = col + 1;
        }
        return true;
    }
    
    
}
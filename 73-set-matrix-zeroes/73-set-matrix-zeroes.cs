public class Solution {
    public void SetZeroes(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        bool isColReset = false;
        
        for(int row=0; row < rows; row++){
            if(matrix[row][0] == 0)
                isColReset = true;
            
            for(int col = 1; col< cols; col++){
                if(matrix[row][col] == 0)
                    matrix[row][0] = matrix[0][col] = 0;
            }
        }
        
        for(int row=1; row<rows; row++){
            for(int col=1; col < cols; col++){
                if(matrix[row][0] == 0 || matrix[0][col] == 0)
                    matrix[row][col] = 0;
            }
        }
        
        if(matrix[0][0] == 0){
            for(int col=1; col < cols; col++)
                matrix[0][col] = 0;
        }
        
        if(isColReset){
            for(int row=0; row < rows; row++)
                matrix[row][0] = 0;
        }
    }
}
public class Solution {
    public void Rotate(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        
        for(int row = 0; row < (rows + 1) / 2; row++) {
            for(int col = 0; col < cols / 2; col++) {
                //top
                int temp = matrix[row][col];
                
                //top <- left
                matrix[row][col] = matrix[cols - col - 1][row];
                
                //left<- down
                matrix[cols - col - 1][row] = matrix[rows - row - 1][cols - col - 1];
                
                //down<- right
                matrix[rows - row - 1][cols - col - 1] = matrix[col][rows - row - 1];
                    
                //right<- top
                matrix[col][rows - row - 1] = temp;
            }
        }
    }
}
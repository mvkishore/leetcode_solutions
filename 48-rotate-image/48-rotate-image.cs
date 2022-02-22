public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        
        for(int row = 0; row < (n + 1) / 2; row++){
            for(int col = 0; col < n / 2; col++){
                //top
                int temp = matrix[row][col];
                
                //top <- left
                matrix[row][col] = matrix[n - col - 1][row];
                
                //left <- down
                matrix[n - col - 1][row] = matrix[n - row - 1][n - col - 1];
                
                //down <- right
                matrix[n - row - 1][n - col - 1] = matrix[col][n - row -1];
                        
                //right <- top
                matrix[col][n - row  - 1] = temp;
            }
        }
    }
}
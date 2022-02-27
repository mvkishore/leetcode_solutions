public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        int dir = 1, row = 0, col = 0, i = 0;
        int rows = mat.Length, cols = mat[0].Length;
        int[] res = new int[rows * cols];
        
        while(i < rows * cols){
            res[i] = mat[row][col];
            
            if(dir == 1 && col == cols - 1){
                dir = -dir;
                row++;
            }else if(dir == 1 && row == 0){
                dir = -dir;
                col++;
            } else if(dir == -1 && row == rows - 1){
                dir = -dir;
                col++;
            } else if(dir == -1 && col == 0){
                dir = -dir;
                row++;
            } else {
                row = row - dir;
                col = col + dir;
            }
            
            i++;
        }
        return res;
    }
}
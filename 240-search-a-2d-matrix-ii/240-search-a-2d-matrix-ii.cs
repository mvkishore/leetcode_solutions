public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length, row = m - 1, col = 0;
        
        while(row >= 0 && col < n){
            if(matrix[row][col] < target)
                col++;
            else if(matrix[row][col] > target)
                row--;
            else return true;
        }
        return false;
    }
}
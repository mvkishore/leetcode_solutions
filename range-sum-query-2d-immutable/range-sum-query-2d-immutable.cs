public class NumMatrix {
    int[,] dp;
    public NumMatrix(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        dp = new int[m + 1, n + 1];
        
        for(int r=0; r<m; r++){
            for(int c=0; c<n; c++){
                dp[r+1, c+1] = dp[r, c+1] + dp[r+1, c] - dp[r, c] + matrix[r][c];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int oa = dp[row1, col1];
        int ob = dp[row1, col2 + 1];
        int oc = dp[row2 + 1, col1];
        int od = dp[row2 + 1 , col2 + 1];
        
        return od - ob - oc + oa;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */